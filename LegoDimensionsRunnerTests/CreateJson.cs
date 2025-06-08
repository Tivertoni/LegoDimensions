using LegoDimensions.Portal;
using Newtonsoft.Json;

namespace LegoDimensionsRunnerTests;

public class CreateJson
{
    [Fact]
    public void TestBasic()
    {
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
        SetColorAll setColorAll = new() { Center = $"#{Color.Yellow.GetHashCode():X2}", Left = $"#{Color.Red.GetHashCode():X2}", Right = $"#{Color.Tan.GetHashCode():X2}", Duration = 200 };
        string strSetColorAll = setColorAll.ToString();
        animation.Actions.Add(strSetColor);
        animation.Actions.Add(strSetColorAll);
        runner.Animations.Add(animation);

        string ser = JsonConvert.SerializeObject(runner);

        Runner? runnerDeserializer = JsonConvert.DeserializeObject<Runner>(ser);
        Assert.Equal(1, runnerDeserializer.Animations.Count);
        Assert.Equal("Test", runnerDeserializer.Animations[0].Name);
        Assert.Equal(strSetColor, runnerDeserializer.Animations[0].Actions[0]);
    }
        
    [Fact]
    public void TestBasicJson()
    {
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
        SetColorAll setColorAll = new() { Center = $"#{Color.Yellow.GetHashCode():X2}", Left = $"#{Color.Red.GetHashCode():X2}", Right = $"#{Color.Tan.GetHashCode():X2}", Duration = 200 };
        animation.Actions.Add(setColor);
        animation.Actions.Add(setColorAll);
        runner.Animations.Add(animation);

        string ser = JsonConvert.SerializeObject(runner);

        Runner? runnerDeserializer = JsonConvert.DeserializeObject<Runner>(ser);
        Assert.Equal(1, runnerDeserializer.Animations.Count);
        Assert.Equal("Test", runnerDeserializer.Animations[0].Name);
        Assert.Equal(setColor.Name, (string)runnerDeserializer.Animations[0].Actions[0]["Name"]);
    }
}