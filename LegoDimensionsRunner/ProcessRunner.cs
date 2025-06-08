// Licensed to Laurent Ellerbach and contributors under one or more agreements.
// Laurent Ellerbach and contributors license this file to you under the MIT license.

using LegoDimensions;
using LegoDimensions.Portal;
using LegoDimensionsRunner.Actions;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using LibUsbDotNet.LibUsb;

namespace LegoDimensionsRunner;

public static class ProcessRunner
{
    private static ILegoPortal[]? _portals;
    private static Runner? _runner;

    public static void CreateAllPortals()
    {
        IUsbDevice[] portals = LegoPortal.GetPortals();
        _portals = new ILegoPortal[portals.Length];
        for (int i = 0; i < portals.Length; i++)
        {
            _portals[i] = new LegoPortal(portals[i], i);
        }
    }

    public static void SetSinglePortal(ILegoPortal portal) => _portals = [portal];

    public static ILegoPortal[]? GetLegoPortals() => _portals;

    public static void Build(Runner runner)
    {
        foreach (Animation anim in runner.Animations)
        {
            int? portalId = anim.PortalId;
            // Sanity check
            if (portalId != null && (portalId.Value < 0 || portalId.Value >= _portals.Length))
            {
                continue;
            }

            anim.CompiledActions = [];
            foreach (dynamic action in anim.Actions)
            {
                if (TryGetObject<SetColor>(action, out SetColor setColor))
                {
                    anim.CompiledActions.Add(() =>
                    {
                        if (portalId == null)
                        {
                            for (int i = 0; i < _portals.Length; i++)
                            {
                                _portals[i].SetColor(setColor.Pad, GetColorFromString(setColor.Color));
                            }
                        }
                        else
                        {
                            _portals[portalId.Value].SetColor(setColor.Pad, GetColorFromString(setColor.Color));
                        }

                        Thread.Sleep(setColor.Duration ?? 0);
                    });
                }
                else if (TryGetObject<SetColorAll>(action, out SetColorAll setColorAll))
                {
                    anim.CompiledActions.Add(() =>
                    {
                        if (portalId == null)
                        {
                            for (int i = 0; i < _portals.Length; i++)
                            {
                                _portals[i].SetColorAll(GetColorFromString(setColorAll.Center), GetColorFromString(setColorAll.Left), GetColorFromString(setColorAll.Right));
                            }
                        }
                        else
                        {
                            _portals[portalId.Value].SetColorAll(GetColorFromString(setColorAll.Center), GetColorFromString(setColorAll.Left), GetColorFromString(setColorAll.Right));
                        }

                        Thread.Sleep(setColorAll.Duration ?? 0);
                    });
                }
                else if (TryGetObject<Flash>(action, out Flash flash))
                {
                    anim.CompiledActions.Add(() =>
                    {
                        if (portalId == null)
                        {
                            for (int i = 0; i < _portals.Length; i++)
                            {
                                _portals[i].Flash(flash.Pad, new FlashPad(flash.TickOn, flash.TickOff, flash.TickCount, GetColorFromString(flash.Color), flash.Enabled));
                            }
                        }
                        else
                        {
                            _portals[portalId.Value].Flash(flash.Pad, new FlashPad(flash.TickOn, flash.TickOff, flash.TickCount, GetColorFromString(flash.Color), flash.Enabled));
                        }

                        Thread.Sleep(flash?.Duration ?? 0);
                    });
                }
                else if (TryGetObject<SwitchOffAll>(action, out SwitchOffAll switchOffAll))
                {
                    anim.CompiledActions.Add(() =>
                    {
                        if (portalId == null)
                        {
                            foreach (ILegoPortal portal in _portals)
                            {
                                portal.SwitchOffAll();
                            }
                        }
                        else
                        {
                            _portals[portalId.Value].SwitchOffAll();
                        }

                        Thread.Sleep(switchOffAll?.Duration ?? 0);
                    });
                }
                else if (TryGetObject<FlashAll>(action, out FlashAll flashAll))
                {
                    anim.CompiledActions.Add(() =>
                    {
                        if (portalId == null)
                        {
                            foreach (ILegoPortal portal in _portals)
                            {
                                portal.FlashAll(new FlashPad(flashAll.CenterTickOn, flashAll.CenterTickOn, flashAll.CenterTickOn, GetColorFromString(flashAll.CenterColor), flashAll.CenterEnabled),
                                    new FlashPad(flashAll.LeftTickOn, flashAll.LeftTickOff, flashAll.LeftTickCount, GetColorFromString(flashAll.LeftColor), flashAll.LeftEnabled),
                                    new FlashPad(flashAll.RightTickOn, flashAll.RightTickOff, flashAll.RightTickCount, GetColorFromString(flashAll.RightColor), flashAll.RightEnabled));
                            }
                        }
                        else
                        {
                            _portals[portalId.Value].FlashAll(new FlashPad(flashAll.CenterTickOn, flashAll.CenterTickOn, flashAll.CenterTickOn, GetColorFromString(flashAll.CenterColor), flashAll.CenterEnabled),
                                new FlashPad(flashAll.LeftTickOn, flashAll.LeftTickOff, flashAll.LeftTickCount, GetColorFromString(flashAll.LeftColor), flashAll.LeftEnabled),
                                new FlashPad(flashAll.RightTickOn, flashAll.RightTickOff, flashAll.RightTickCount, GetColorFromString(flashAll.RightColor), flashAll.RightEnabled));
                        }
                        Thread.Sleep(flashAll?.Duration ?? 0);
                    });
                }
                else if (TryGetObject<Fade>(action, out Fade fade))
                {
                    anim.CompiledActions.Add(() =>
                    {
                        if (portalId == null)
                        {
                            foreach (ILegoPortal portal in _portals)
                            {
                                portal.Fade(fade.Pad, new FadePad(fade.TickTime, fade.TickCount, GetColorFromString(fade.Color), fade.Enabled));
                            }
                        }
                        else
                        {
                            _portals[portalId.Value].Fade(fade.Pad, new FadePad(fade.TickTime, fade.TickCount, GetColorFromString(fade.Color), fade.Enabled));
                        }

                        Thread.Sleep(fade?.Duration ?? 0);
                    });
                }
                else if (TryGetObject<FadeAll>(action, out FadeAll fadeAll))
                {
                    anim.CompiledActions.Add(() =>
                    {
                        if (portalId == null)
                        {
                            for (int i = 0; i < _portals.Length; i++)
                            {
                                _portals[i].FadeAll(new FadePad(fadeAll.CenterTickTime, fadeAll.CenterTickCount, GetColorFromString(fadeAll.CenterColor), fadeAll.CenterEnabled),
                                    new FadePad(fadeAll.LeftTickTime, fadeAll.LeftTickCount, GetColorFromString(fadeAll.LeftColor), fadeAll.LeftEnabled),
                                    new FadePad(fadeAll.RightTickTime, fadeAll.RightTickCount, GetColorFromString(fadeAll.RightColor), fadeAll.RightEnabled));
                            }
                        }
                        else
                        {
                            _portals[portalId.Value].FadeAll(new FadePad(fadeAll.CenterTickTime, fadeAll.CenterTickCount, GetColorFromString(fadeAll.CenterColor), fadeAll.CenterEnabled),
                                new FadePad(fadeAll.LeftTickTime, fadeAll.LeftTickCount, GetColorFromString(fadeAll.LeftColor), fadeAll.LeftEnabled),
                                new FadePad(fadeAll.RightTickTime, fadeAll.RightTickCount, GetColorFromString(fadeAll.RightColor), fadeAll.RightEnabled));
                        }

                        Thread.Sleep(fadeAll?.Duration ?? 0);
                    });
                }
                else if (TryGetObject<FadeRandom>(action, out FadeRandom fadeRandom))
                {
                    anim.CompiledActions.Add(() =>
                    {
                        if (portalId == null)
                        {
                            for (int i = 0; i < _portals.Length; i++)
                            {
                                _portals[i].FadeRandom(fadeRandom.Pad, fadeRandom.TickTime, fadeRandom.TickCount);
                            }
                        }
                        else
                        {
                            _portals[portalId.Value].FadeRandom(fadeRandom.Pad, fadeRandom.TickTime, fadeRandom.TickCount);
                        }

                        Thread.Sleep(fadeRandom?.Duration ?? 0);
                    });
                }
            }
        }

        _runner = runner;
        for (int i = 0; i < _portals.Length; i++)
        {
            _portals[i].LegoTagEvent += PortalLegoTagEvent;
        }
    }

    private static void PortalLegoTagEvent(object? sender, LegoTagEventArgs e)
    {
        // First check by ID
        IEnumerable<Event>? id = _runner?.Events?.Where(m => m.Id != null && m.Id == e.LegoTag?.Id).Where(m => m.Pad == Pad.All || m.Pad == e.Pad);
        if (id != null && id.Any())
        {
            RunEvent(id);
        }
        else
        {
            IEnumerable<Event>? cardId = _runner?.Events?.Where(m => m.CardId != null && m.CardId == BitConverter.ToString(e.CardUid)).Where(m => m.Pad == Pad.All || m.Pad == e.Pad);
            if (cardId != null && cardId.Any())
            {
                RunEvent(cardId);
            }
            else
            {
                // Check if we have a specific pad 
                IEnumerable<Event>? pads = _runner?.Events?.Where(m => (m.Pad == Pad.All || m.Pad == e.Pad) && m.Id == null && string.IsNullOrEmpty(m.CardId));
                if (pads != null && pads.Any())
                {
                    RunEvent(pads);
                }
            }
        }
    }

    private static void RunEvent(IEnumerable<Event> events)
    {
        foreach (Event item in events)
        {
            IEnumerable<Animation>? anims = _runner?.Animations.Where(m => m.Name == item.Animation);
            if (anims.Any())
            {
                foreach (Animation anim in anims)
                {
                    foreach (Action act in anim.CompiledActions)
                    {
                        act.Invoke();
                    }
                }
            }
        }
    }

    public static Runner Deserialize(string json)
    {
        JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<Runner>(json, options);
    }

    public static void Run(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            foreach (string item in _runner?.Playlist)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }

                // Play the animation
                Animation? anim = _runner?.Animations?.Where(m => string.Compare(m.Name, item, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();
                if (anim != null)
                {
                    foreach (Action act in anim.CompiledActions)
                    {
                        act.Invoke();
                    }
                }
            }
        }
    }

    private static bool TryGetObject<T>(dynamic? ser, out T? action) where T : class
    {
        action = null;
        // First, check if we have a json object or just a string

        T? actionRef = (T)Activator.CreateInstance(typeof(T));

        try
        {
            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true
            };

            // And then use the normal json deserializer
            action = JsonSerializer.Deserialize<T>(ser, options);

        }
        catch
        {
            // Nothing on purpose
        }

        if (action != null)
        {
            MethodInfo? actionRefMethod = (actionRef?.GetType().GetMethods()).FirstOrDefault(m => m.Name == "get_Name");
            MethodInfo? actionMethod = actionRef.GetType().GetMethods().FirstOrDefault(m => m.Name == "get_Name");

            if (actionRefMethod.Invoke(actionRef, null) == actionMethod.Invoke(action, null))
            {
                return true;
            }

            action = null;
        }

        // If just a string, then we have a key value list like key1=value1,key2=value2
        string[] data;
        try
        {
            data = ser.GetString().Trim().Split(',');
        }
        catch
        {
            data = ((string)ser).Trim().Split(',');
        }

        Dictionary<string, string> dict = new();
        foreach (string s in data)
        {
            string[] dic = s.Trim().Split('=');
            dict.Add(dic[0].Trim().ToLower(), dic[1].Trim());
        }

        if (String.Compare(dict["name"], typeof(T).Name, StringComparison.OrdinalIgnoreCase) == 0)
        {
            try
            {
                MethodInfo[] methods = typeof(T).GetMethods();
                action = (T)Activator.CreateInstance(typeof(T));
                foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("set_")))
                {
                    string mem = method.Name.ToLower();

                    if (dict.ContainsKey(mem.Substring(4)))
                    {
                        string toParse = dict[mem.Substring(4)];
                        ParameterInfo[] parameters = method.GetParameters();
                        object param = null;
                        if (parameters[0].ParameterType == typeof(string))
                        {
                            param = toParse;
                        }
                        else if (parameters[0].ParameterType == typeof(int?))
                        {
                            if (!string.IsNullOrEmpty(toParse))
                            {
                                int val = int.Parse(toParse);
                                param = val;
                            }
                        }
                        else if (parameters[0].ParameterType == typeof(int))
                        {
                            if (!string.IsNullOrEmpty(toParse))
                            {
                                int val = int.Parse(toParse);
                                param = val;
                            }
                            else
                            {
                                param = 0;
                            }
                        }
                        else if (parameters[0].ParameterType == typeof(bool))
                        {
                            if (!string.IsNullOrEmpty(toParse))
                            {
                                bool val = bool.Parse(toParse);
                                param = val;
                            }
                        }
                        else if (parameters[0].ParameterType == typeof(Pad))
                        {
                            Enum.TryParse(toParse, out Pad val);
                            param = val;
                        }
                        else if (parameters[0].ParameterType == typeof(byte))
                        {
                            if (!string.IsNullOrEmpty(toParse))
                            {
                                byte val = byte.Parse(toParse);
                                param = val;
                            }
                            else
                            {
                                param = (byte)0;
                            }
                        }

                        method.Invoke(action, [param]);
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex}");
            }
        }

        return action != null;
    }

    private static Color GetColorFromString(string color)
    {
        // Default will be black but that won't throw
        Color.TryGetColor(color, out Color result);
        return result;
    }
}