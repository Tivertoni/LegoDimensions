using LegoDimensions.Portal;
using LegoDimensions.Tag;

namespace LegoDimensionsRunnerTests;

[Collection("ProcessRunner")]
public class EventTests
{
    private const int MAX_WAIT = 5000;
    private static readonly TestPortal Portal;

    static EventTests()
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
    public void IdEventTest()
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
        Animation animation1 = new()
        {
            Name = "Test1",
            Actions = []
        };

        SetColor setColor1 = new() { Pad = Pad.Center, Color = $"#{Color.Yellow.GetHashCode():X2}" };
        string strSetColor1 = setColor1.ToString();
        animation1.Actions.Add(strSetColor1);
        runner.Animations.Add(animation1);

        Animation animation2 = new()
        {
            Name = "Test2",
            Actions = []
        };
        SetColor setColor2 = new() { Pad = Pad.Right, Color = $"#{Color.Red.GetHashCode():X2}" };
        string strSetColor2 = setColor2.ToString();
        animation2.Actions.Add(strSetColor2);
        runner.Animations.Add(animation2);

        Event event1 = new() { Animation = "Test1", Id = 42 };
        runner.Events =
        [
            event1
            // Act
        ];

        // Act

        ProcessRunner.Build(runner);
        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;
        Portal.RaiseTheEvent(new LegoTagEventArgs(Pad.Center, true, null, Character.Characters.FirstOrDefault(m => m.Id == 42), 0));
        string? res = Portal.GetLastFunction;
        Portal.ResetEvent.Cancel();

        // Assert
        // This should be more complicated and check with the initial values
        Assert.Equal("SetColor(Center, #FFFFFF00)", res);

    }

    [Fact]
    public void PadEventTest()
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
        Animation animation1 = new()
        {
            Name = "Test1",
            Actions = []
        };

        SetColor setColor1 = new() { Pad = Pad.Center, Color = $"#{Color.Yellow.GetHashCode():X2}" };
        string strSetColor1 = setColor1.ToString();
        animation1.Actions.Add(strSetColor1);
        runner.Animations.Add(animation1);

        Animation animation2 = new()
        {
            Name = "Test2",
            Actions = []
        };
        SetColor setColor2 = new() { Pad = Pad.Right, Color = $"#{Color.Red.GetHashCode():X2}" };
        string strSetColor2 = setColor2.ToString();
        animation2.Actions.Add(strSetColor2);
        runner.Animations.Add(animation2);

        Event event1 = new() { Animation = "Test1", Pad = Pad.Right };
        runner.Events =
        [
            event1
            // Act
        ];

        // Act
        ProcessRunner.Build(runner);
        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;
        Portal.RaiseTheEvent(new LegoTagEventArgs(Pad.Right, true, null, Character.Characters.FirstOrDefault(m => m.Id == 40), 0));
        string? res = Portal.GetLastFunction;
        Portal.ResetEvent.Cancel();

        // Assert
        // This should be more complicated and check with the initial values
        Assert.Equal("SetColor(Center, #FFFFFF00)", res);
    }

    [Fact]
    public void PadAndIdEventTest()
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
        Animation animation1 = new()
        {
            Name = "Test1",
            Actions = []
        };

        SetColor setColor1 = new() { Pad = Pad.Center, Color = $"#{Color.Yellow.GetHashCode():X2}" };
        string strSetColor1 = setColor1.ToString();
        animation1.Actions.Add(strSetColor1);
        runner.Animations.Add(animation1);

        Animation animation2 = new()
        {
            Name = "Test2",
            Actions = []
        };
        SetColor setColor2 = new() { Pad = Pad.Right, Color = $"#{Color.Red.GetHashCode():X2}" };
        string strSetColor2 = setColor2.ToString();
        animation2.Actions.Add(strSetColor2);
        runner.Animations.Add(animation2);

        Event event1 = new() { Animation = "Test1", Pad = Pad.Right, Id = 40 };
        runner.Events =
        [
            event1
            // Act
        ];

        // Act
        ProcessRunner.Build(runner);
        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;
        Portal.RaiseTheEvent(new LegoTagEventArgs(Pad.Right, true, null, Character.Characters.FirstOrDefault(m => m.Id == 40), 0));
        string? res = Portal.GetLastFunction;
        Portal.ResetEvent.Cancel();

        // Assert
        // This should be more complicated and check with the initial values
        Assert.Equal("SetColor(Center, #FFFFFF00)", res);
    }

    [Fact]
    public void NoPadEventTest()
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
        Animation animation1 = new()
        {
            Name = "Test1",
            Actions = []
        };

        SetColor setColor1 = new() { Pad = Pad.Center, Color = $"#{Color.Yellow.GetHashCode():X2}" };
        string strSetColor1 = setColor1.ToString();
        animation1.Actions.Add(strSetColor1);
        runner.Animations.Add(animation1);

        Animation animation2 = new()
        {
            Name = "Test2",
            Actions = []
        };
        SetColor setColor2 = new() { Pad = Pad.Right, Color = $"#{Color.Red.GetHashCode():X2}" };
        string strSetColor2 = setColor2.ToString();
        animation2.Actions.Add(strSetColor2);
        runner.Animations.Add(animation2);

        Event event1 = new() { Animation = "Test1", Pad = Pad.Right };
        runner.Events =
        [
            event1
            // Act
        ];

        // Act
        ProcessRunner.Build(runner);
        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;
        Portal.RaiseTheEvent(new LegoTagEventArgs(Pad.Center, true, null, Character.Characters.FirstOrDefault(m => m.Id == 40), 0));
        string? res = Portal.GetLastFunction;
        Portal.ResetEvent.Cancel();

        // Assert
        // This should be more complicated and check with the initial values
        Assert.Null(res);
    }

    [Fact]
    public void NoIdEventTest()
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
        Animation animation1 = new()
        {
            Name = "Test1",
            Actions = []
        };

        SetColor setColor1 = new() { Pad = Pad.Center, Color = $"#{Color.Yellow.GetHashCode():X2}" };
        string strSetColor1 = setColor1.ToString();
        animation1.Actions.Add(strSetColor1);
        runner.Animations.Add(animation1);

        Animation animation2 = new()
        {
            Name = "Test2",
            Actions = []
        };
        SetColor setColor2 = new() { Pad = Pad.Right, Color = $"#{Color.Red.GetHashCode():X2}" };
        string strSetColor2 = setColor2.ToString();
        animation2.Actions.Add(strSetColor2);
        runner.Animations.Add(animation2);

        Event event1 = new() { Animation = "Test1", Id = 42 };
        runner.Events =
        [
            event1
            // Act
        ];

        // Act
        ProcessRunner.Build(runner);
        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;
        Portal.RaiseTheEvent(new LegoTagEventArgs(Pad.Center, true, null, Character.Characters.FirstOrDefault(m => m.Id == 40), 0));
        string? res = Portal.GetLastFunction;

        // Assert
        // This should be more complicated and check with the initial values
        Assert.Null(res);
    }

    [Fact]
    public void NoEventTest()
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
        Animation animation1 = new()
        {
            Name = "Test1",
            Actions = []
        };

        SetColor setColor1 = new() { Pad = Pad.Center, Color = $"#{Color.Yellow.GetHashCode():X2}" };
        string strSetColor1 = setColor1.ToString();
        animation1.Actions.Add(strSetColor1);
        runner.Animations.Add(animation1);

        Animation animation2 = new()
        {
            Name = "Test2",
            Actions = []
        };
        SetColor setColor2 = new() { Pad = Pad.Right, Color = $"#{Color.Red.GetHashCode():X2}" };
        string strSetColor2 = setColor2.ToString();
        animation2.Actions.Add(strSetColor2);
        runner.Animations.Add(animation2);

        // No event for this test.
        // Event event1 = new Event() { Animation = "Test1", Id = 42 };
        // runner.Events = new List<Event>();
        // runner.Events.Add(event1);            

        // Act
        ProcessRunner.Build(runner);
        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;
        Portal.RaiseTheEvent(new LegoTagEventArgs(Pad.Center, true, null, Character.Characters.FirstOrDefault(m => m.Id == 40), 0));
        string? res = Portal.GetLastFunction;

        // Assert
        // This should be more complicated and check with the initial values
        Assert.Null(res);
    }

    [Fact]
    public void CardIdEventTest()
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
        Animation animation1 = new()
        {
            Name = "Test1",
            Actions = []
        };

        SetColor setColor1 = new() { Pad = Pad.Center, Color = $"#{Color.Yellow.GetHashCode():X2}" };
        string strSetColor1 = setColor1.ToString();
        animation1.Actions.Add(strSetColor1);
        runner.Animations.Add(animation1);

        Animation animation2 = new()
        {
            Name = "Test2",
            Actions = []
        };
        SetColor setColor2 = new() { Pad = Pad.Right, Color = $"#{Color.Red.GetHashCode():X2}" };
        string strSetColor2 = setColor2.ToString();
        animation2.Actions.Add(strSetColor2);
        runner.Animations.Add(animation2);

        Event event1 = new() { Animation = "Test1", CardId = BitConverter.ToString([0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06
        ]) };
        runner.Events =
        [
            event1
            // Act
        ];

        // Act
        ProcessRunner.Build(runner);
        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;
        Portal.RaiseTheEvent(new LegoTagEventArgs(Pad.Center, true, [0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06], null, 0));
        string? res = Portal.GetLastFunction;
        Portal.ResetEvent.Cancel();

        // Assert
        // This should be more complicated and check with the initial values
        Assert.Equal("SetColor(Center, #FFFFFF00)", res);
    }

    [Fact]
    public void NoCardIdEventTest()
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
        Animation animation1 = new()
        {
            Name = "Test1",
            Actions = []
        };

        SetColor setColor1 = new() { Pad = Pad.Center, Color = $"#{Color.Yellow.GetHashCode():X2}" };
        string strSetColor1 = setColor1.ToString();
        animation1.Actions.Add(strSetColor1);
        runner.Animations.Add(animation1);

        Animation animation2 = new()
        {
            Name = "Test2",
            Actions = []
        };
        SetColor setColor2 = new() { Pad = Pad.Right, Color = $"#{Color.Red.GetHashCode():X2}" };
        string strSetColor2 = setColor2.ToString();
        animation2.Actions.Add(strSetColor2);
        runner.Animations.Add(animation2);

        Event event1 = new() { Animation = "Test1", CardId = BitConverter.ToString([0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06
        ]) };
        runner.Events =
        [
            event1
            // Act
        ];

        // Act
        ProcessRunner.Build(runner);
        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;
        Portal.RaiseTheEvent(new LegoTagEventArgs(Pad.Center, true, [0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x00], null, 0));
        string? res = Portal.GetLastFunction;
        Portal.ResetEvent.Cancel();

        // Assert
        // This should be more complicated and check with the initial values
        Assert.Null(res);
    }
}