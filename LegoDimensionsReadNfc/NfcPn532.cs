using Iot.Device.Card.Ultralight;
using Iot.Device.Pn532;
using Iot.Device.Pn532.ListPassive;
using LegoDimensions.Tag;
using System.Diagnostics;
using Iot.Device.Rfid;
using Terminal.Gui;

namespace LegoDimensionsReadNfc;

public class NfcPn532
{
    private static string _device;
    private static Pn532 _pn532;
    private static byte[] _currentCardUid = [];
    private static UltralightCard _ultralight;
    private static DisplayInfo _displayInfo;

    public static void OpenComPort(string device)
    {
        _device = device;
        _pn532 = new Pn532(_device);
    }

    public static void ErraseTag()
    {
        bool reselected = false;
        bool stopped = false;

        Application.Init();
        _displayInfo = new DisplayInfo();
        _displayInfo.Label.Text = "Erase Tag: place an empty tag on the reader to erase it.";
        _displayInfo.View.Text = string.Empty;
        _displayInfo.ButtonClose.Clicked += () =>
        {
            stopped = true;
            Application.RequestStop();
        };

        new Thread(() => Application.Run(_displayInfo)).Start();

        Reselect:
        _currentCardUid = [];
        GetUltralightCard();
        Debug.WriteLine($"Type: {_ultralight.UltralightCardType}, Ndef capacity: {_ultralight.NdefCapacity}");

        if (reselected)
        {
            byte[] passwd = LegoTag.GenerateCardPassword(_ultralight.SerialNumber);
            if (!_ultralight.ProcessAuthentication(passwd))
            {
                _displayInfo.View.Text += "Failed to authenticate the card.\r\n";
                return;
            }
        }

        // Try to read the car on 0x24 just to see if we need the password
        if (!ReadBlock(0x24))
        {
            if (!reselected)
            {
                reselected = true;
                goto Reselect;
            }

            if (!ReadBlock(0x24))
            {
                _displayInfo.View.Text += "Failed to read data block 0x24, can't erase the card.\r\n";
                return;
            }
        }

        bool erased = true;
        for (int i = 0; i < 4; i++)
        {
            if (!WriteAndCheck((byte)(0x24 + i), new byte[4]))
            {
                _displayInfo.View.Text += $"Error erasing block 0x{0x24 + i:X2}.\r\n";
                erased = false;
            }
        }

        if (erased)
        {
            _displayInfo.View.Text += "Card erased.\r\n";
        }
        else
        {
            _displayInfo.View.Text += "Card may not have been erased properly.\r\n";
        }

        Application.DoEvents();

        while (!stopped)
        {
            Thread.Sleep(100);
        }

        Application.Shutdown();
    }

    public static void WriteEmptyTag(ushort id, bool character)
    {
        bool reselected = false;
        bool stopped = false;

        Application.Init();
        _displayInfo = new DisplayInfo();
        _displayInfo.Label.Text = "Write Tag: place an empty tag on the reader to write it.";
        _displayInfo.View.Text = string.Empty;
        _displayInfo.ButtonClose.Clicked += () =>
        {
            stopped = true;
            Application.RequestStop();
        };

        new Thread(() => Application.Run(_displayInfo)).Start();

        Reselect:
        _currentCardUid = [];
        GetUltralightCard();
        Debug.WriteLine($"Type: {_ultralight.UltralightCardType}, Ndef capacity: {_ultralight.NdefCapacity}");

        // First step: change the password
        // Process the password
        byte[] passwd = LegoTag.GenerateCardPassword(_ultralight.SerialNumber);
        _displayInfo.View.Text += $"Card {BitConverter.ToString(_ultralight.SerialNumber)}, generated password: {BitConverter.ToString(passwd)}\r\n";

        if (reselected)
        {
            if (!_ultralight.ProcessAuthentication(passwd))
            {
                _displayInfo.View.Text += "Failed to authenticate the card.\r\n";
                Application.RequestStop();
                return;
            }
        }

        // Try to read the car on 0x24 just to see if we need the password

        if (!ReadBlock(0x24))
        {
            if (!reselected)
            {
                reselected = true;
                goto Reselect;
            }

            if (_ultralight.RunUltralightCommand() < 0)
            {
                _displayInfo.View.Text += "Failed to read data block 0x24, can't erase the card.\r\n";
                Application.RequestStop();
                return;
            }
        }

        if (!reselected)
        {
            // 0x2B for NTAG213
            if (_ultralight.UltralightCardType == UltralightCardType.UltralightNtag213)
            {
                _ultralight.BlockNumber = 0x2B;
            }
            else if (_ultralight.UltralightCardType == UltralightCardType.UltralightNtag215)
            {
                _ultralight.BlockNumber = 0x85;
            }
            else if (_ultralight.UltralightCardType == UltralightCardType.UltralightNtag216)
            {
                _ultralight.BlockNumber = 0xE5;
            }
            else
            {
                _displayInfo.View.Text += $"Not a supported NTAG card, only 213, 215 and 216 ar supported. Current detected type: {_ultralight.UltralightCardType}.\r\n";
                Application.RequestStop();
                return;
            }

            _ultralight.Command = UltralightCommand.Write4Bytes;
            _ultralight.Data = passwd;
            if (_ultralight.RunUltralightCommand() < 0)
            {
                _displayInfo.View.Text += "Failed to write new password\r\n";
                Application.RequestStop();
                return;
            }

            _displayInfo.View.Text += "New password set.\r\n";
        }
        else
        {
            _displayInfo.View.Text += "Password already set\r\n";
        }

        int retry = 0;
        // Second step: write the data
        if (character)
        {
            // Get the encrypted character ID
            byte[] car = LegoTag.EncrypCharactertId(_ultralight.SerialNumber, id);

            if (!WriteAndCheck(0x24, car.AsSpan(0, 4).ToArray()))
            {
                _displayInfo.View.Text += "Most likely failed to write character as can't check block 0x24.\r\n";
            }

            if (!WriteAndCheck(0x25, car.AsSpan(4, 4).ToArray()))
            {
                _displayInfo.View.Text += "Most likely failed to write character as can't check block 0x25.\r\n";
            }
        }
        else
        {

            // Get the encrypted vehicle ID
            byte[] vec = LegoTag.EncryptVehicleId(id);
            if (!WriteAndCheck(0x24, vec))
            {
                _displayInfo.View.Text += "Most likely failed to write vehicle as can't check block 0x24.\r\n";
            }

            // Then write it's a vehicle
            if (!WriteAndCheck(0x26, [0x00, 0x01, 0x00, 0x00]))
            {
                _displayInfo.View.Text += "Most likely failed to write vehicle as can't check block 0x26.\r\n";
            }
        }

        _displayInfo.View.Text += "Setup for the new card done.\r\n";

        Application.DoEvents();

        while (!stopped)
        {
            Thread.Sleep(100);
        }

        Application.Shutdown();
    }

    public static void ReadLegoTag(bool dump)
    {
        bool stopped = false;

        Application.Init();
        _displayInfo = new DisplayInfo();
        _displayInfo.Label.Text = "Write Tag: place an empty tag on the reader to write it.";
        _displayInfo.View.Text = string.Empty;
        _displayInfo.ButtonClose.Clicked += () =>
        {
            stopped = true;
            Application.RequestStop();
        };

        new Thread(() => Application.Run(_displayInfo)).Start();            

        try
        {
            _currentCardUid = [];
            GetUltralightCard();

            Debug.WriteLine($"Type: {_ultralight.UltralightCardType}, Ndef capacity: {_ultralight.NdefCapacity}");

            // For debug purposes, you can uncomment
            if (dump)
            {
                DisplayVersion();
            }

            // Try authentication
            Debug.WriteLine("Generating authentication key");
            _ultralight.AuthenticationKey = LegoTag.GenerateCardPassword(_ultralight.SerialNumber);
            _displayInfo.View.Text += $"Authentication key: {BitConverter.ToString(_ultralight.AuthenticationKey)}.\r\n";
            Application.DoEvents();
            _ultralight.Command = UltralightCommand.PasswordAuthentication;
            int auth = _ultralight.RunUltralightCommand();

            // For debug pu^rposes, you can display all page card
            if (dump)
            {
                ReadAllCard();
            }

            // read page 0x24   
            if (ReadBlock(0x24))
            {
                for (int i = 0; i < 16; i++)
                {
                    Debug.Write($"{_ultralight.Data[i]:X2} ");
                }

                // If page 0x26 == 00 01 00 00 we have a vehicle
                if (LegoTag.IsVehicle(_ultralight.Data.AsSpan(8, 4).ToArray()))
                {
                    _displayInfo.View.Text += "Found a vehicle.\r\n";
                    // The 2 first one used
                    ushort id = LegoTag.GetVehicleId(_ultralight.Data);
                    _displayInfo.View.Text += $"  vehicle ID: {id}: ";
                    Vehicle vec = Vehicle.Vehicles.FirstOrDefault(m => m.Id == id);
                    if (vec is not null)
                    {
                        _displayInfo.View.Text += $"{vec.Name}, {vec.Rebuild} build - {vec.World}.\r\n";
                        _displayInfo.View.Text += "  Capabilities: ";
                        for (int i = 0; i < vec.Abilities.Count; i++)
                        {
                            _displayInfo.View.Text += $"{vec.Abilities[i]}{(i != vec.Abilities.Count - 1 ? ", " : "")}";
                        }

                        _displayInfo.View.Text += "\r\n";
                        Application.DoEvents();
                    }
                    else
                    {
                        _displayInfo.View.Text += "and vehicle does not exist!\r\n";
                        Application.DoEvents();
                    }
                }
                else
                {
                    _displayInfo.View.Text += "Found a character.\r\n";
                    ushort id = LegoTag.GetCharacterId(_ultralight.SerialNumber, _ultralight.Data.AsSpan(0, 8).ToArray());
                    _displayInfo.View.Text += $"  Character ID: {id}: ";
                    Character car = Character.Characters.FirstOrDefault(m => m.Id == id);
                    if (car is not null)
                    {
                        _displayInfo.View.Text += $"{car.Name} - {car.World}.\r\n";
                        _displayInfo.View.Text += "  Capabilities: ";
                        for (int i = 0; i < car.Abilities.Count; i++)
                        {
                            _displayInfo.View.Text += $"{car.Abilities[i]}{(i != car.Abilities.Count - 1 ? ", " : "")}";
                        }

                        _displayInfo.View.Text += "\r\n";
                        Application.DoEvents();
                    }
                    else
                    {
                        _displayInfo.View.Text += "and character does not exist!\r\n";
                        Application.DoEvents();
                    }
                }
            }
            else
            {
                _currentCardUid = [];
                _displayInfo.View.Text += "Can't read the tag, place it again or another one.\r\n";
            }
        }
        catch (Exception)
        {
            _currentCardUid = [];
            _displayInfo.View.Text += "Can't read the tag, place it again or another one.\r\n";
        }

        Application.DoEvents();
        while (!stopped)
        {
            Thread.Sleep(100);
        }

        Application.Shutdown();
    }

    public static void ReadAllCard()
    {
        _displayInfo.View.Text += "Dump of all the card:\r\n";
        Application.DoEvents();
        for (int block = 0; block < _ultralight.NumberBlocks; block++)
        {
            if (ReadBlock((byte)block))
            {
                _displayInfo.View.Text += $"  Block: {_ultralight.BlockNumber:X2} - ";
                for (int i = 0; i < 4; i++)
                {
                    _displayInfo.View.Text += $"{_ultralight.Data[i]:X2} ";
                }

                bool isReadOnly = _ultralight.IsPageReadOnly(_ultralight.BlockNumber);
                _displayInfo.View.Text += $"- Read only: {isReadOnly} ";

                _displayInfo.View.Text += "\r\n";
            }
            else
            {
                _displayInfo.View.Text += "Can't read card\r\n";
            }

            Application.DoEvents();
        }
    }

    public static void DisplayVersion()
    {
        byte[] version = _ultralight.GetVersion();
        if (version.Length > 0)
        {
            _displayInfo.View.Text += "Get Version details: ";
            foreach (byte bt in version)
            {
                _displayInfo.View.Text += $"{bt:X2} ";
            }

            _displayInfo.View.Text += "\r\n";
        }
        else
        {
            _displayInfo.View.Text += "Can't read the version.\r\n";
        }

        Application.DoEvents();
    }

    private static bool WriteAndCheck(byte block, byte[] data, int maxRetries = 3)
    {
        int retry = 0;
        RetryWrite:
        if (_ultralight.IsPageReadOnly(block))
        {
            _displayInfo.View.Text += $"Block 0x{block:X2} is readonly.\r\n";
            return false;
        }

        if (!WriteBlock(block, data))
        {
            if (retry++ < maxRetries)
            {
                // Try to auth
                Auth();
                Thread.Sleep(100);
                goto RetryWrite;
            }

            _displayInfo.View.Text += $"Failed to write block 0x{block:X2} after {maxRetries}.\r\n";
            return false;
        }

        // Time for the data to be properly written
        Thread.Sleep(100);
        retry = 0;
        RetryRead:
        _ultralight.Data = [];
        // Check it's correct
        if (!ReadBlock(block))
        {
            if (retry++ < maxRetries)
            {
                // Try to auth
                Auth();
                Thread.Sleep(100);
                goto RetryRead;
            }

            _displayInfo.View.Text += $"Can't check block 0x{block:X2}.\r\n";
            return false;
        }

        if (!data.SequenceEqual(_ultralight.Data.AsSpan(0, 4).ToArray()))
        {
            if (retry++ < maxRetries)
            {
                Thread.Sleep(100);
                goto RetryWrite;
            }

            _displayInfo.View.Text += $"Can't validate block 0x{block:X2} even after {maxRetries} retries.\r\n";
            return false;
        }

        return true;
    }

    private static bool Auth()
    {
        byte[] passwd = LegoTag.GenerateCardPassword(_ultralight.SerialNumber);
        _ultralight.Data = passwd;
        _ultralight.Command = UltralightCommand.PasswordAuthentication;
        int res = _ultralight.RunUltralightCommand();
        return res >= 0;
    }

    private static bool WriteBlock(byte block, byte[] data)
    {
        _ultralight.Data = data;
        _ultralight.BlockNumber = block;
        _ultralight.Command = UltralightCommand.Write4Bytes;
        return _ultralight.RunUltralightCommand() >= 0;
    }

    private static bool ReadBlock(byte block)
    {
        _ultralight.BlockNumber = block; // Safe cast, can't be more than 255
        _ultralight.Command = UltralightCommand.Read16Bytes;
        int res = _ultralight.RunUltralightCommand();
        return res >= 0;
    }

    private static UltralightCard GetUltralightCard()
    {
        CheckCard:
        byte[] retData = null;
        while (!Console.KeyAvailable)
        {
            retData = _pn532.ListPassiveTarget(MaxTarget.One, TargetBaudRate.B106kbpsTypeA);
            if (retData is object)
            {
                break;
            }

            // Give time to PN532 to process
            Thread.Sleep(200);
            _currentCardUid = [];
        }

        // Key pressed, exit
        if (retData is null)
        {
            return null;
        }

        // You need to remove the first element at it's the number of tags read
        // In, this case we will assume we are reading only 1 tag at a time
        Data106kbpsTypeA? decrypted = _pn532.TryDecode106kbpsTypeA(retData.AsSpan().Slice(1));

        if (decrypted is object)
        {
            Debug.WriteLine($"Tg: {decrypted.TargetNumber}, ATQA: {decrypted.Atqa} SAK: {decrypted.Sak}, NFCID: {BitConverter.ToString(decrypted.NfcId)}");
            if (decrypted.Ats is object)
            {
                Debug.WriteLine($", ATS: {BitConverter.ToString(decrypted.Ats)}");
            }

            if (_currentCardUid.SequenceEqual(decrypted.NfcId))
            {
                Thread.Sleep(1000);
                goto CheckCard;
            }

            _currentCardUid = decrypted.NfcId;

            _ultralight = new UltralightCard(_pn532, 0);
            _ultralight.SerialNumber = decrypted.NfcId;
            return _ultralight;
        }

        return null;
    }

    private static bool WriteAndCheck(UltralightCard ultralight, byte block, byte[] data, int maxRetries = 3)
    {
        int retry = 0;
        RetryWrite:
        if (ultralight.IsPageReadOnly(block))
        {
            Console.WriteLine($"Block 0x{block:X2} is readonly.");
            return false;
        }

        if (!WriteBlock(ultralight, block, data))
        {
            if (retry++ < maxRetries)
            {
                Thread.Sleep(100);
                goto RetryWrite;
            }

            Console.WriteLine($"Failed to write block 0x{block:X2} after {maxRetries}.");
            return false;
        }

        RetryRead:
        ultralight.Data = [];
        // Check it's correct
        if (!ReadBlock(ultralight, block))
        {
            if (retry++ < maxRetries)
            {
                Thread.Sleep(100);
                goto RetryRead;
            }

            Console.WriteLine($"Can't check block 0x{block:X2}.");
            return false;
        }

        if (!data.SequenceEqual(ultralight.Data))
        {
            if (retry++ < maxRetries)
            {
                Thread.Sleep(100);
                goto RetryWrite;
            }

            Console.WriteLine($"Can't validate block 0x{block:X2} even after {maxRetries} retries.");
            return false;
        }

        return true;
    }

    private static bool WriteBlock(UltralightCard ultralight, byte block, byte[] data)
    {
        ultralight.Data = data;
        ultralight.BlockNumber = block;
        ultralight.Command = UltralightCommand.Write4Bytes;
        return ultralight.RunUltralightCommand() >= 0;
    }

    private static bool ReadBlock(UltralightCard ultralight, byte block)
    {
        ultralight.BlockNumber = block; // Safe cast, can't be more than 255
        ultralight.Command = UltralightCommand.Read16Bytes;
        int res = ultralight.RunUltralightCommand();
        return res >= 0;
    }
}