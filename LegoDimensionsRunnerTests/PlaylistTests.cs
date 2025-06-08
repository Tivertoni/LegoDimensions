namespace LegoDimensionsRunnerTests;

[Collection("ProcessRunner")]
public class PlaylistTests
{
    private const int MAX_WAIT = 5000;
    private static readonly TestPortal Portal;

    static PlaylistTests()
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
    public void SimplePlaylistTest()
    {
        // Arrange
        while (!Portal.ResetEvent.IsCancellationRequested)
        {
            Portal.ResetEvent.Token.WaitHandle.WaitOne(5000, true);
        }

        Runner runner = ProcessRunner.Deserialize("{\"animations\":[{\"Name\":\"Test\",\"Actions\":[\"Name=SetColor,   PAD =     1, color = #FFFFFF00    \",\"Name=SetColorAll,Center=yellow,Left=#FFFF0000,Right=#FFD2B48C,Duration=200\"]},{\"Name\":\"Test2\",\"Actions\":[\"Name=SetColor,   PAD =     2, color = #FFFF0000    \",\"Name=SetColorAll,Center=yellow,Left=#FFFFFF00,Right=#FFD2B48C,Duration=200\"]}],\"Playlist\":[\"Test\",\"Test2\"]}");

        // Act
        ProcessRunner.Build(runner);

        Portal.ResetEvent = new CancellationTokenSource(MAX_WAIT);
        Portal.GetLastFunction = null;
        CancellationTokenSource cs = new(5000);
        ProcessRunner.Run(cs.Token);
        string? res = Portal.GetLastFunction;
        Portal.ResetEvent.Cancel();

        // Assert
        // Should be more complex but that's enough for now
        Assert.NotNull(res);
    }
}