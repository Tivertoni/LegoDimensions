// Licensed to Laurent Ellerbach and contributors under one or more agreements.
// Laurent Ellerbach and contributors license this file to you under the MIT license.

using LegoDimensions.Portal;
using LegoDimensions.Tag;
using LibUsbDotNet;
using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LegoDimensions;

/// <summary>
/// Instance of a Lego Dimensions Portal.
/// </summary>
public class LegoPortal : IDisposable, ILegoPortal
{
    // Constants
    private const int PRODUCT_ID = 0x0241;
    private const int VENDOR_ID = 0x0E6F;
    private const int READ_WRITE_TIMEOUT = 1000;
    private const int RECEIVE_TIMEOUT = 2000;

    // This needs to be static to keep the context otherwise, the app will close it
    private static UsbContext? _context = null;

    // Class variables
    private readonly IUsbDevice _portal;
    private readonly UsbEndpointReader _endpointReader;
    private readonly UsbEndpointWriter _endpointWriter;
    private byte _messageId;
    private readonly Thread _readThread;
    private readonly CancellationTokenSource _cancelThread;
    private readonly List<PresentTag> _presentTags = [];
    private bool _nfcEnabled = true;

    // We do have only 3 Pads
    // This one is to store the last message ID request for details
    private readonly List<PadTag> _padTag = [];
    private readonly List<CommandId> _commandId = [];

    /// <summary>
    /// Gets the first of default Lego Dimensions Portal.
    /// </summary>
    /// <returns>A Lego Dimensions Portal</returns>
    public static LegoPortal GetFirstPortal()
    {
        IUsbDevice[] portals = GetPortals();

        if (portals.Length == 0)
        {
            throw new Exception("No Lego Dimensions Portal found.");
        }

        return new LegoPortal(portals[0]);
    }

    /// <summary>
    /// Gets all the available USB device that matches the Lego Dimensions Portal.
    /// </summary>
    /// <returns>Array of USB devices.</returns>
    public static IUsbDevice[] GetPortals()
    {
        _context ??= new UsbContext();
#if DEBUG
        _context.SetDebugLevel(LogLevel.Info);
#else
            context.SetDebugLevel(LogLevel.Error);
#endif
        //Get a list of all connected devices
        UsbDeviceCollection? usbDeviceCollection = _context.List();

        //Narrow down the device by vendor and pid
        IEnumerable<IUsbDevice> selectedDevice = usbDeviceCollection.Where(d => d.ProductId == PRODUCT_ID && d.VendorId == VENDOR_ID);

        return selectedDevice.ToArray();
    }

    /// <inheritdoc/>
    public event EventHandler<LegoTagEventArgs>? LegoTagEvent;

    /// <summary>
    /// Gets the list of present tags.
    /// </summary>
    public IEnumerable<PresentTag> PresentTags => _presentTags;

    /// <inheritdoc/>
    public bool NfcEnabled
    {
        get => _nfcEnabled;
        set
        {
            _nfcEnabled = value;
            Message message = new(MessageCommand.ConfigActive);
            message.AddPayload(_nfcEnabled);
            SendMessage(message);
        }
    }

    /// <inheritdoc/>
    public bool GetTagDetails { get; set; } = true;

    /// <summary>
    /// Gets the ID.
    /// </summary>
    public int Id { get; internal set; }

    /// <summary>
    /// Gets the underlying USB device.
    /// </summary>
    public IUsbDevice UsbDevice => _portal;

    public byte[] SerialNumber { get; internal set; }

    /// <summary>
    /// Creates a new instance of a Lego Dimensions Portal.
    /// </summary>
    /// <param name="device">A valid Lego Dimensions instance.</param>
    /// <param name="id">An ID for this device, can be handy if you manage multiple ones.</param>
    public LegoPortal(IUsbDevice device, int id = 0)
    {
        _portal = device;
        Id = id;
        //Open the device
        _portal.Open();

        // Non Windows OS need to detach the kernel driver
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Imports.SetAutoDetachKernelDriver(_portal.DeviceHandle, 1);
        }

        //Get the first config number of the interface
        _portal.ClaimInterface(_portal.Configs[0].Interfaces[0].Number);

        //Open up the endpoints
        _endpointWriter = _portal.OpenEndpointWriter(WriteEndpointID.Ep01);
        _endpointReader = _portal.OpenEndpointReader(ReadEndpointID.Ep01);

        // Read the first 32 bytes
        byte[] readBuffer = new byte[32];
        _endpointReader.Read(readBuffer, READ_WRITE_TIMEOUT, out int bytesRead);

        // Start the read thread
        _cancelThread = new CancellationTokenSource();
        _readThread = new Thread(ReadThread);
        _readThread.Start();
        // WakeUp the portal
        WakeUp();
    }

    /// <inheritdoc/>
    public void WakeUp()
    {
        Message message = new(MessageCommand.Wake);
        message.AddPayload("(c) LEGO 2014");
        _messageId = 0;
        ManualResetEvent getSerial = new(false);
        SerialNumber = [];
        CommandId commandId = new(SendMessage(message), MessageCommand.Wake, getSerial);
        _commandId.Add(commandId);

        getSerial.WaitOne(RECEIVE_TIMEOUT, true);

        if (commandId.Result != null)
        {
            SerialNumber = (byte[])commandId.Result;
        }

        _commandId.Remove(commandId);
        // TODO: investigate seeding
        //message = new Message(MessageCommand.Seed);
        //message.AddPayload(new byte[] { 0xaa, 0x6F, 0xC8, 0xCD, 0x21, 0x1E, 0xF8, 0xCE });
        //SendMessage(message);
    }

    /// <inheritdoc/>
    public void SetColor(Pad pad, Color color)
    {
        Message message = new(MessageCommand.Color);
        message.AddPayload(pad, color);
        SendMessage(message);
    }

    /// <inheritdoc/>
    public Color GetColor(Pad pad)
    {
        Message message = new(MessageCommand.GetColor);
        message.AddPayload(pad);
        ManualResetEvent getColor = new(false);
        CommandId commandId = new(SendMessage(message), MessageCommand.GetColor, getColor);
        _commandId.Add(commandId);
        // In case we won't get any color, use the default black one
        Color padColor = Color.Black;
        // Wait maximum 2 seconds
        getColor.WaitOne(RECEIVE_TIMEOUT, true);

        if (commandId.Result != null)
        {
            padColor = (Color)commandId.Result;
        }

        _commandId.Remove(commandId);

        return padColor;
    }

    /// <inheritdoc/>
    public void SetColorAll(Color padCenter, Color padLeft, Color padRight)
    {
        Message message = new(MessageCommand.ColorAll);
        message.AddPayload(true, padCenter, true, padLeft, true, padRight);
    }

    /// <inheritdoc/>
    public void SwitchOffAll()
    {
        Message message = new(MessageCommand.ColorAll);
        message.AddPayload(false, Color.Black, false, Color.Black, false, Color.Black);
        SendMessage(message);
    }

    /// <inheritdoc/>
    public void Flash(Pad pad, FlashPad flashPad)
    {
        Message message = new(MessageCommand.Flash);
        message.AddPayload(pad, flashPad.TickOn, flashPad.TickOff, flashPad.TickCount, flashPad.Color);
        SendMessage(message);
    }

    /// <inheritdoc/>
    public void FlashAll(FlashPad flashPadCenter, FlashPad flashPadLeft, FlashPad flashPadRight)
    {
        Message message = new(MessageCommand.FlashAll);
        message.AddPayload(flashPadCenter.Enabled, flashPadCenter.TickOn, flashPadCenter.TickOff, flashPadCenter.TickCount, flashPadCenter.Color);
        message.AddPayload(flashPadLeft.Enabled, flashPadLeft.TickOn, flashPadLeft.TickOff, flashPadLeft.TickCount, flashPadLeft.Color);
        message.AddPayload(flashPadRight.Enabled, flashPadRight.TickOn, flashPadRight.TickOff, flashPadRight.TickCount, flashPadRight.Color);
        SendMessage(message);
    }

    /// <inheritdoc/>
    public void Fade(Pad pad, FadePad fadePad)
    {
        Message message = new(MessageCommand.Fade);
        message.AddPayload(pad, fadePad.TickTime, fadePad.TickCount, fadePad.Color);
        SendMessage(message);
    }

    /// <inheritdoc/>
    public void FadeAll(FadePad fadePadCenter, FadePad fadePadLeft, FadePad fadePadRight)
    {
        Message message = new(MessageCommand.FadeAll);
        message.AddPayload(fadePadCenter.Enabled, fadePadCenter.TickTime, fadePadCenter.TickCount, fadePadCenter.Color);
        message.AddPayload(fadePadLeft.Enabled, fadePadLeft.TickTime, fadePadLeft.TickCount, fadePadLeft.Color);
        message.AddPayload(fadePadRight.Enabled, fadePadRight.TickTime, fadePadRight.TickCount, fadePadRight.Color);
        SendMessage(message);
    }

    /// <inheritdoc/>
    public void FadeRandom(Pad pad, byte tickTime, byte tickCount)
    {
        Message message = new(MessageCommand.FadeRandom);
        message.AddPayload(pad, tickTime, tickCount);
        SendMessage(message);
    }

    /// <summary>
    /// Read 16 bytes from a tag.
    /// </summary>
    /// <param name="index">The tag index to read.</param>
    /// <param name="page">The page to read.</param>
    /// <returns>A byte array of 16 bytes in case of success.</returns>
    public byte[] ReadTag(byte index, byte page)
    {
        Message message = new(MessageCommand.Read);
        message.AddPayload(index, page);
        ManualResetEvent getRead = new(false);
        CommandId commandId = new(SendMessage(message), MessageCommand.Read, getRead);
        _commandId.Add(commandId);
        // In case we won't get any color, use the default black one
        byte[] readBytes = [];
        // Wait maximum 2 seconds
        getRead.WaitOne(RECEIVE_TIMEOUT, true);

        if (commandId.Result != null)
        {
            readBytes = (byte[])commandId.Result;
        }

        _commandId.Remove(commandId);

        return readBytes;
    }

    /// <summary>
    /// Write 4 bytes to a tag.
    /// </summary>
    /// <param name="index">The tag index to write.</param>
    /// <param name="page">The page to write.</param>
    /// <param name="bytes">An array of 4 bytes to write.</param>
    /// <returns>True if success.</returns>
    public bool WriteTag(byte index, byte page, byte[] bytes)
    {
        if (bytes.Length != 4)
        {
            throw new ArgumentException("Write to card must be 4 bytes.");
        }

        Message message = new(MessageCommand.Write);
        message.AddPayload(index, page, bytes);
        ManualResetEvent getWrite = new(false);
        CommandId commandId = new(SendMessage(message), MessageCommand.Write, getWrite);
        _commandId.Add(commandId);
        // In case we won't get any color, use the default black one
        bool success = false;
        // Wait maximum 2 seconds
        getWrite.WaitOne(RECEIVE_TIMEOUT, true);

        if (commandId.Result != null)
        {
            success = (bool)commandId.Result;
        }

        _commandId.Remove(commandId);

        return success;
    }

    /// <summary>
    /// Read 8 bytes from a tag at page 0x24 and 0x25.
    /// </summary>
    /// <param name="encryoptedIndex">The tag index to read encrypted on 8 bytes.</param>
    /// <returns>A byte array of 8 bytes in case of success.</returns>
    public byte[] GetTagInformation(byte[] encryoptedIndex)
    {
        Message message = new(MessageCommand.Model);
        message.AddPayload(encryoptedIndex);
        ManualResetEvent getRead = new(false);
        CommandId commandId = new(SendMessage(message), MessageCommand.Model, getRead);
        _commandId.Add(commandId);
        // In case we won't get any color, use the default black one
        byte[] readBytes = [];
        // Wait maximum 2 seconds
        getRead.WaitOne(RECEIVE_TIMEOUT, true);

        if (commandId.Result != null)
        {
            readBytes = (byte[])commandId.Result;
        }

        _commandId.Remove(commandId);

        return readBytes;
    }

    /// <summary>
    /// Get a challenge from the portal.
    /// </summary>
    /// <returns>A byte array of 8 bytes in case of success.</returns>
    public byte[] GetChallenge()
    {
        Message message = new(MessageCommand.Challenge);
        ManualResetEvent getChallenge = new(false);
        CommandId commandId = new(SendMessage(message), MessageCommand.Challenge, getChallenge);
        _commandId.Add(commandId);
        // In case we won't get any color, use the default black one
        byte[] readBytes = [];
        // Wait maximum 2 seconds
        getChallenge.WaitOne(RECEIVE_TIMEOUT, true);

        if (commandId.Result != null)
        {
            readBytes = (byte[])commandId.Result;
        }

        _commandId.Remove(commandId);

        return readBytes;
    }

    public IEnumerable<PresentTag> ListTags()
    {
        Message message = new(MessageCommand.TagList);
        ManualResetEvent getTagList = new(false);
        CommandId commandId = new(SendMessage(message), MessageCommand.TagList, getTagList);
        _commandId.Add(commandId);
        while (!getTagList.WaitOne(RECEIVE_TIMEOUT))
        { }

        // We don't do anything as we manage the result globally
        _commandId.Remove(commandId);

        return _presentTags;
    }

    /// <summary>
    /// Sets the tag password behavior.
    /// </summary>
    /// <param name="password">The desired state, Automatic is the default value.</param>
    /// <param name="index">The tag index.</param>
    /// <param name="newPassword">The new 4 bytes password if any.</param>
    public void SetTagPassword(PortalPassword password, byte index, byte[]? newPassword = null)
    {
        newPassword ??= new byte[4];

        if (password == PortalPassword.Custom && newPassword.Length != 4)
        {
            throw new ArgumentException("New password must be 4 bytes");
        }

        Message message = new(MessageCommand.ConfigPassword);
        message.AddPayload((byte)password, index, newPassword);
        SendMessage(message);
    }

    /// <summary>
    /// Sends a message.
    /// </summary>
    /// <param name="message">The message to send.</param>
    /// <param name="messageId">The message ID, leave to 0 to use the internal message count.</param>
    /// <returns>The message ID for the request.</returns>
    public byte SendMessage(Message message, byte messageId = 0)
    {
        byte[] bytes = message.GetBytes(messageId == 0 ? IncreaseMessageId() : messageId);
        _endpointWriter.Write(bytes, READ_WRITE_TIMEOUT, out int numBytes);
        // Assume it's awake if we send 32 bytes properly
        Debug.WriteLine($"SND: {BitConverter.ToString(bytes)}");
        return messageId == 0 ? _messageId : messageId;
    }

    private void ReadThread(object? obj)
    {
        // Read is always 32 bytes
        byte[] readBuffer = new byte[32];

        while (!_cancelThread.IsCancellationRequested)
        {
            try
            {
                _endpointReader.Read(readBuffer, READ_WRITE_TIMEOUT, out int bytesRead);
                if (bytesRead > 0)
                {
                    Debug.WriteLine($"REC: {BitConverter.ToString(readBuffer)}");
                }

                if (bytesRead == 32)
                {
                    Message message = Message.CreateFromBuffer(readBuffer, MessageSource.Portal);
                    if (message.MessageType == MessageType.Event)
                    {
                        // In the case of an event the Message Type event, all is in the payload
                        byte pad = message.Payload[0];
                        if (pad < 1 || pad > 3)
                        {
                            // Not a valid message
                            continue;
                        }

                        bool present = message.Payload[3] == 0;
                        TagType tadType = (TagType)message.Payload[1];
                        byte[] uuid = new byte[7]; //TODO: It's an UID not a UUID!
                        Array.Copy(message.Payload, 4, uuid, 0, uuid.Length);
                        // Find the tage if existing in the list
                        PadTag? legoTag = _padTag.FirstOrDefault(m => m.CardUid.SequenceEqual(uuid));
                        byte padIndex = message.Payload[2];
                        if (present)
                        {

                            if (legoTag == null)
                            {
                                _presentTags.Add(new PresentTag((Pad)pad, tadType, padIndex, uuid));
                                legoTag = new PadTag { Pad = (Pad)pad, TagIndex = padIndex, Present = present, CardUid = uuid, TagType = tadType };
                                _padTag.Add(legoTag);

                                if (GetTagDetails)
                                {
                                    // Ask for more with the read command for 0x24
                                    Message msgToSend = new(MessageCommand.Read);
                                    msgToSend.AddPayload(padIndex, (byte)0x24);
                                    legoTag.LastMessageId = SendMessage(msgToSend);
                                    _commandId.Add(new CommandId(legoTag.LastMessageId, MessageCommand.Read, null));
                                }
                                else
                                {
                                    // Directly raise the event
                                    LegoTagEvent?.Invoke(this, new LegoTagEventArgs(legoTag));
                                }
                            }
                            else
                            {
                                legoTag.Present = present;
                            }
                        }
                        else
                        {
                            if (legoTag != null)
                            {
                                legoTag.Present = present;
                                LegoTagEvent?.Invoke(this, new LegoTagEventArgs(legoTag));
                                PresentTag? presentTag = _presentTags.FirstOrDefault(m => m.Pad == legoTag.Pad && m.Index == legoTag.TagIndex);
                                if (presentTag != null)
                                {
                                    _presentTags.Remove(presentTag);
                                }

                                _padTag.Remove(legoTag);
                            }
                        }
                    }
                    else if (message.MessageType == MessageType.Normal)
                    {
                        // In case the payload is 17, then we do have a response to a read command
                        CommandId? cmdId = _commandId.FirstOrDefault(m => m.MessageId == _messageId);
                        if (message.MessageCommand == MessageCommand.None && cmdId is { MessageCommand: MessageCommand.Read })
                        {
                            // In this case the request is coming from the event
                            if (cmdId.ManualResetEvent == null)
                            {
                                PadTag? legoTag = _padTag.FirstOrDefault(m => m.LastMessageId == message.MessageId);
                                if (legoTag == null)
                                {
                                    continue;
                                }

                                // We should have our 0x24
                                if (LegoTag.IsVehicle(message.Payload.AsSpan(9, 4).ToArray()))
                                {
                                    ushort vecId = LegoTag.GetVehicleId(message.Payload.AsSpan(1, 4).ToArray());
                                    Vehicle? vec = Vehicle.Vehicles.FirstOrDefault(m => m.Id == vecId);
                                    legoTag.LegoTag = vec;

                                }
                                else
                                {
                                    ushort carId = LegoTag.GetCharacterId(legoTag.CardUid, message.Payload.AsSpan(1, 8).ToArray());
                                    Character? car = Character.Characters.FirstOrDefault(m => m.Id == carId);
                                    legoTag.LegoTag = car;
                                }

                                LegoTagEvent?.Invoke(this, new LegoTagEventArgs(legoTag));
                            }
                            else
                            {
                                // This case is a normal read, and we will set the buffer
                                if (message.Payload[0] == 0)
                                {
                                    // if no error, we set the result
                                    cmdId.Result = message.Payload[1..];
                                }

                                cmdId.ManualResetEvent.Set();
                            }
                        }
                        else if (message.MessageCommand == MessageCommand.None && cmdId != null && cmdId.MessageCommand == MessageCommand.GetColor)
                        {
                            cmdId.Result = Color.FromArgb(message.Payload[0], message.Payload[1], message.Payload[2]);
                            cmdId.ManualResetEvent?.Set();
                        }
                        else if (message.MessageCommand == MessageCommand.None && cmdId != null && cmdId.MessageCommand == MessageCommand.Model)
                        {
                            if (message.Payload[0] == 0)
                            {
                                // if no error, we set the result
                                cmdId.Result = message.Payload[1..];
                            }

                            cmdId.ManualResetEvent?.Set();
                        }
                        else if (message.MessageCommand == MessageCommand.None && cmdId != null && cmdId.MessageCommand == MessageCommand.Write)
                        {
                            cmdId.Result = message.Payload[0] == 0;
                            cmdId.ManualResetEvent?.Set();
                        }
                        else if (message.MessageCommand == MessageCommand.None && cmdId != null && cmdId.MessageCommand == MessageCommand.Wake)
                        {
                            cmdId.Result = message.Payload[10..];
                            cmdId.ManualResetEvent?.Set();
                        }
                        else if (message.MessageCommand == MessageCommand.None && cmdId != null && cmdId.MessageCommand == MessageCommand.Challenge)
                        {
                            cmdId.Result = message.Payload;
                            cmdId.ManualResetEvent?.Set();
                        }
                        else if (message.MessageCommand == MessageCommand.None && cmdId != null && cmdId.MessageCommand == MessageCommand.TagList)
                        {
                            _presentTags.Clear();
                            for (int i = 0; i < message.Payload.Length / 2; i++)
                            {
                                byte index = (byte)(message.Payload[i * 2] & 0xF);
                                byte[] uid = _padTag.FirstOrDefault(x => x.TagIndex == index)?.CardUid ?? [];
                                PresentTag presentTag = new((Pad)(message.Payload[i * 2] >> 4), (TagType)message.Payload[i * 2 + 1], index, uid);
                                _presentTags.Add(presentTag);
                            }

                            cmdId.ManualResetEvent?.Set();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex}");
            }
        }
    }

    private byte IncreaseMessageId()
    {
        _messageId = (byte)(_messageId == 255 ? 1 : ++_messageId);
        return _messageId;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        _cancelThread.Cancel();
        // Make sure the thread is stopped
        _readThread.Join();
        _portal.ReleaseInterface(_portal.Configs[0].Interfaces[0].Number);
        _portal.Close();
        _portal.Dispose();
    }
}