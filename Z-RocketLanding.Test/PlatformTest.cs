namespace Zts_RocketLanding.xUnitTest;

public class PlatformTest
{
    [Fact]
    public void CreateDefaultPlatform_Ok()
    {
        var exception = Record.Exception(() => new Platform());
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(50)]
    public void CreatePlatformCustomWidth_Ok(int width)
    {
        var exception = Record.Exception(() => new Platform(width));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(100)]
    public void CreatePlatformCustomWidth_Fail(int width)
    {
        var exception = Record.Exception(() => new Platform(width));
        Assert.NotNull(exception);
        Assert.StartsWith("Width", exception.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(50)]
    public void CreatePlatformCustomHeight_Ok(int height)
    {
        var exception = Record.Exception(() => new Platform(height: height));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(100)]
    public void CreatePlatformCustomHeight_Fail(int height)
    {
        var exception = Record.Exception(() => new Platform(height: height));
        Assert.NotNull(exception);
        Assert.StartsWith("Height", exception.Message);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(50, 50)]
    public void CreatePlatformCustomPosition_Ok(int x, int y)
    {
        var exception = Record.Exception(() => new Platform(xLeftTopVertexPosition: x, yLeftTopVertexPosition: y));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(-1, 1)]
    public void CreatePlatformCustomPosition_XFail(int x, int y)
    {
        var exception = Record.Exception(() => new Platform(xLeftTopVertexPosition: x, yLeftTopVertexPosition: y));
        Assert.NotNull(exception);
        Assert.StartsWith("X", exception.Message);
    }

    [Theory]
    [InlineData(94, 5)]
    public void CreatePlatformCustomPosition_AreaFail(int x, int y)
    {
        var exception = Record.Exception(() => new Platform(xLeftTopVertexPosition: x, yLeftTopVertexPosition: y));
        Assert.NotNull(exception);
        Assert.StartsWith("Platform area", exception.Message);
    }
}
