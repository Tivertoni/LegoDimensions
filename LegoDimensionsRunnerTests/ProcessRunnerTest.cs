﻿// Licensed to Laurent Ellerbach and contributors under one or more agreements.
// Laurent Ellerbach and contributors license this file to you under the MIT license.

using LegoDimensions.Portal;
using System.Diagnostics;

namespace LegoDimensionsRunnerTests;

[Collection("ProcessRunner")]
public class ProcessRunnerTest
{
    private const int MAX_WAIT = 5000;
    private static readonly TestPortal Portal;

    static ProcessRunnerTest()
    {
        if (ProcessRunner.GetLegoPortals() == null)
        {
            Portal = new TestPortal();
            ProcessRunner.SetSinglePortal(Portal);
        }
        else
        {
            Portal = ProcessRunner.GetLegoPortals()[0] as TestPortal;
        }
    }

    [Fact]
    public void BasicTest()
    {
        // Arrange
        while (!Portal.ResetEvent.IsCancellationRequested)
        {
            Portal.ResetEvent.Token.WaitHandle.WaitOne(5000, true);
        }

        Runner runner = new()
        {
            Animations = []
        };
        Animation animation = new()
        {
            Name = "Test",
            Actions = []
        };
        SetColor setColor = new() { Pad = Pad.Center, Color = $"#{Color.Yellow.GetHashCode():X2}" };
        string strSetColor = setColor.ToString();
        SetColorAll setColorAll = new() { Center = Color.Yellow.ToString(), Left = $"#{Color.Red.GetHashCode():X2}", Right = "Tan", Duration = 200 };
        string strSetColorAll = setColorAll.ToString();
        animation.Actions.Add(strSetColor);
        animation.Actions.Add(strSetColorAll);
        runner.Animations.Add(animation);

        // Act
        ProcessRunner.Build(runner);

        // Assert
        Assert.Equal(2, runner.Animations[0].CompiledActions.Count);
        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);

        foreach (Animation anim in runner.Animations)
        {
            foreach (Action action in anim.CompiledActions)
            {
                while(!Portal.ResetEvent.IsCancellationRequested)
                {
                    Portal.ResetEvent.Token.WaitHandle.WaitOne(5000, true);
                }

                    
                Portal.GetLastFunction = null;
                action.Invoke();
                // This should be more complicated and check with the initial values
                string? res = Portal.GetLastFunction;                   
                Assert.NotNull(res);                    
            }
        }

        Portal.ResetEvent.Cancel();
    }

    [Fact]
    public void SetColorTest()
    {
        // Arrange
        while (!Portal.ResetEvent.IsCancellationRequested)
        {
            Portal.ResetEvent.Token.WaitHandle.WaitOne(5000, true);
        }

        Runner runner = new()
        {
            Animations = []
        };
        Animation animation = new()
        {
            Name = "Test",
            Actions = []
        };
        SetColor setColor = new() { Pad = Pad.Center, Color = $"#{Color.Yellow.GetHashCode():X2}" };
        string strSetColor = setColor.ToString();
        animation.Actions.Add(strSetColor);
        runner.Animations.Add(animation);

        // Act
        ProcessRunner.Build(runner);
           
        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;
        runner.Animations[0].CompiledActions[0].Invoke();
        string? res = Portal.GetLastFunction;
        Portal.ResetEvent.Cancel();

        // Assert
        Assert.Equal("SetColor(Center, #FFFFFF00)", res);
    }

    [Fact]
    public void SetColorWithPortalIdTest()
    {
        // Arrange
        while (!Portal.ResetEvent.IsCancellationRequested)
        {
            Portal.ResetEvent.Token.WaitHandle.WaitOne(5000, true);
        }

        Runner runner = new()
        {
            Animations = []
        };
        Animation animation = new()
        {
            Name = "Test",
            PortalId = 0,
            Actions = []
        };
        SetColor setColor = new() { Pad = Pad.Center, Color = $"#{Color.Yellow.GetHashCode():X2}" };
        string strSetColor = setColor.ToString();
        animation.Actions.Add(strSetColor);
        runner.Animations.Add(animation);

        // Act
        ProcessRunner.Build(runner);
            
        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;
        runner.Animations[0].CompiledActions[0].Invoke();
        string? res = Portal.GetLastFunction;
        Portal.ResetEvent.Cancel();

        // Assert
        Assert.Equal("SetColor(Center, #FFFFFF00)", res);
    }

    [Theory]
    [InlineData("{\"Configuration\":null,\"Animations\":[{\"Name\":\"Test\",\"Duration\":null,\"Actions\":[\"Name=SetColor,Pad=Center,Color=#FFFFFF00,Duration=\",\"Name=SetColorAll,Center=#FFFFFF00,Left=#FFFF0000,Right=#FFD2B48C,Duration=1\"],\"CompiledActions\":null}],\"Event\":null}")]
    [InlineData("{\"Animations\":[{\"Name\":\"Test\",\"Actions\":[\"Name=SetColor,Pad=1,Color=#FFFFFF00\",\"Name=SetColorAll,Center=yellow,Left=#FFFF0000,Right=#FFD2B48C,Duration=200\"]}]}")]
    [InlineData("{\"Animations\":[{\"Name\":\"Test\",\"Actions\":[\"Name=SetColor,   PAD =     1, color = #FFFFFF00    \",\"Name=SetColorAll,Center=yellow,Left=#FFFF0000,Right=#FFD2B48C,Duration=200\"]}]}")]
    [InlineData("{\"Configuration\":null,\"Animations\":[{\"Name\":\"Test\",\"Duration\":null,\"Actions\":[{\"Duration\":null,\"Name\":\"SetColor\",\"Pad\":1,\"Color\":\"#FFFFFF00\"},{\"Name\":\"SetColorAll\",\"Duration\":1,\"Center\":\"#FFFFFF00\",\"Left\":\"#FFFF0000\",\"Right\":\"#FFD2B48C\"}],\"CompiledActions\":null}],\"Event\":null}")]
    [InlineData("{\"Animations\":[{\"Name\":\"Test\",\"Actions\":[{\"Name\":\"setcolor\",\"PAD\":1,\"coLor\":\"yellow\"},{\"Name\":\"SetColorAll\",\"Duration\":200,\"Center\":\"#FFFFFF00\",\"Left\":\"#FFFF0000\",\"Right\":\"#FFD2B48C\"}],\"CompiledActions\":null}],\"Event\":null}")]
    public void SetColorFromJson(string json)
    {
        // Arrange
        while (!Portal.ResetEvent.IsCancellationRequested)
        {
            Portal.ResetEvent.Token.WaitHandle.WaitOne(5000, true);
        }

        Runner runner = ProcessRunner.Deserialize(json);

        // Act
        ProcessRunner.Build(runner);            

        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;
        runner.Animations[0].CompiledActions[0].Invoke();
        string? res = Portal.GetLastFunction;
        Portal.ResetEvent.Cancel();

        // Assert
        Assert.Equal("SetColor(Center, #FFFFFF00)", res);
    }

    [Fact]
    public void SetColorAllTest()
    {
        // Arrange
        while (!Portal.ResetEvent.IsCancellationRequested)
        {
            Portal.ResetEvent.Token.WaitHandle.WaitOne(5000, true);
        }

        Runner runner = new()
        {
            Animations = []
        };
        Animation animation = new()
        {
            Name = "Test",
            Actions = []
        };
        SetColorAll setColor = new() { Center = Color.Yellow.ToString(), Left = $"#{Color.Red.GetHashCode():X2}", Right = "Tan", Duration = 2000 };
        string strSetColor = setColor.ToString();
        animation.Actions.Add(strSetColor);
        runner.Animations.Add(animation);

        // Act
        ProcessRunner.Build(runner);
            
        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;

        // Check the time of execution as well, must be more than the duration
        Stopwatch stopwatch = new();
        stopwatch.Start();
        runner.Animations[0].CompiledActions[0].Invoke();
        stopwatch.Stop();
        string? res = Portal.GetLastFunction;
        Portal.ResetEvent.Cancel();

        // Assert
        Assert.Equal("SetColorAll(#FFFFFF00, #FFFF0000, #FFD2B48C)", res);
        Assert.True(stopwatch.ElapsedMilliseconds >= 2000);
    }

    [Fact]
    public void FadeTest()
    {
        // Arrange
        while (!Portal.ResetEvent.IsCancellationRequested)
        {
            Portal.ResetEvent.Token.WaitHandle.WaitOne(5000, true);
        }

        Runner runner = new()
        {
            Animations = []
        };
        Animation animation = new()
        {
            Name = "Test",
            Actions = []
        };
        Fade fade = new() { Color = "yeLLOw", Pad = Pad.Right, TickCount = 42, TickTime = 20, Duration = 100 };
        string strFade = fade.ToString();
        animation.Actions.Add(strFade);
        runner.Animations.Add(animation);

        // Act
        ProcessRunner.Build(runner);
            
        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;
        runner.Animations[0].CompiledActions[0].Invoke();
        string? res = Portal.GetLastFunction;
        Portal.ResetEvent.Cancel();

        // Assert           
        Assert.Equal("Fade(Right, {\"Enabled\":true,\"TickTime\":20,\"TickCount\":42,\"Color\":{\"A\":255,\"B\":0,\"R\":255,\"G\":255}})", res);
    }

    [Fact]
    public void FadeAllTest()
    {
        // Arrange
        while (!Portal.ResetEvent.IsCancellationRequested)
        {
            Portal.ResetEvent.Token.WaitHandle.WaitOne(5000, true);
        }

        Runner runner = new()
        {
            Animations = []
        };
        Animation animation = new()
        {
            Name = "Test",
            Actions = []
        };
        FadeAll fade = new() { CenterColor = "yeLLOw", CenterTickCount = 42, CenterTickTime = 20, LeftColor = "RED", LeftTickCount = 24, LeftTickTime = 2, LeftEnabled = false, Duration = 100 };
        string strFade = fade.ToString();
        animation.Actions.Add(strFade);
        runner.Animations.Add(animation);

        // Act
        ProcessRunner.Build(runner);
            
        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;
        runner.Animations[0].CompiledActions[0].Invoke();
        string? res = Portal.GetLastFunction;
        Portal.ResetEvent.Cancel();

        // Assert
        Assert.Equal("FadeAll(This is a lot, so should work)", res);
    }

    [Fact]
    public void FadeRandomTest()
    {
        // Arrange
        while (!Portal.ResetEvent.IsCancellationRequested)
        {
            Portal.ResetEvent.Token.WaitHandle.WaitOne(5000, true);
        }

        Runner runner = new()
        {
            Animations = []
        };
        Animation animation = new()
        {
            Name = "Test",
            Actions = []
        };
        FadeRandom fade = new() { Pad = Pad.Right, TickCount = 42, TickTime = 20, Duration = 100 };
        string strFade = fade.ToString();
        animation.Actions.Add(strFade);
        runner.Animations.Add(animation);

        // Act
        ProcessRunner.Build(runner);
                        
        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;
        runner.Animations[0].CompiledActions[0].Invoke();
        string? res = Portal.GetLastFunction;
        Portal.ResetEvent.Cancel();

        // Assert
        Assert.Equal("FadeRandom(Right, 20, 42)", res);
    }

    [Fact]
    public void FlashTest()
    {
        // Arrange
        while (!Portal.ResetEvent.IsCancellationRequested)
        {
            Portal.ResetEvent.Token.WaitHandle.WaitOne(5000, true);
        }

        Runner runner = new()
        {
            Animations = []
        };
        Animation animation = new()
        {
            Name = "Test",
            Actions = []
        };
        Flash flash = new() { Color = "yeLLOw", Pad = Pad.Right, TickCount = 42, TickOn = 20, TickOff = 12, Duration = 100 };
        string strFlash = flash.ToString();
        animation.Actions.Add(strFlash);
        runner.Animations.Add(animation);

        // Act
        ProcessRunner.Build(runner);

        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;
        runner.Animations[0].CompiledActions[0].Invoke();
        string? res = Portal.GetLastFunction;
        Portal.ResetEvent.Cancel();

        // Assert
        Assert.Equal("Flash(Right, {\"FlashForever\":false,\"TickOn\":20,\"TickOff\":12,\"TickCount\":42,\"Color\":{\"A\":255,\"B\":0,\"R\":255,\"G\":255},\"Enabled\":true})", res);
    }

    [Fact]
    public void FlashAllTest()
    {
        // Arrange
        while (!Portal.ResetEvent.IsCancellationRequested)
        {
            Portal.ResetEvent.Token.WaitHandle.WaitOne(5000, true);
        }

        Runner runner = new()
        {
            Animations = []
        };
        Animation animation = new()
        {
            Name = "Test",
            Actions = []
        };
        FlashAll flash = new() { CenterColor = "yeLLOw", CenterTickCount = 42, CenterTickOn = 20, CenterTickOff = 12, LeftColor = "black", LeftTickCount = 123, RightColor = "#12345678" };
        string strFlash = flash.ToString();
        animation.Actions.Add(strFlash);
        runner.Animations.Add(animation);

        // Act
        ProcessRunner.Build(runner);

        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;
        runner.Animations[0].CompiledActions[0].Invoke();
        string? res = Portal.GetLastFunction;
        Portal.ResetEvent.Cancel();

        // Assert
        Assert.Equal("FadeAll({\"FlashForever\":false,\"TickOn\":20,\"TickOff\":20,\"TickCount\":20,\"Color\":{\"A\":255,\"B\":0,\"R\":255,\"G\":255},\"Enabled\":true}, {\"FlashForever\":false,\"TickOn\":0,\"TickOff\":0,\"TickCount\":123,\"Color\":{\"A\":255,\"B\":0,\"R\":0,\"G\":0},\"Enabled\":true}, {\"FlashForever\":false,\"TickOn\":0,\"TickOff\":0,\"TickCount\":0,\"Color\":{\"A\":18,\"B\":120,\"R\":52,\"G\":86},\"Enabled\":true})", res);
    }
}