using Zts_RocketLanding_Library.Enum;
namespace Zts_RocketLanding.xUnitTest;

public class RocketLandingTest
{
    [Theory]
    [InlineData(5, 5)]
    [InlineData(14, 14)]
    [InlineData(6, 7)]
    void CheckRocketLanding_OkForLanding(int x, int y)
    {
        string resp = new RocketLanding().CheckLandAvailability(1, x, y);
        Assert.Same(ResponseConst.OK_FOR_LANDING, resp);
    }

    [Theory]
    [InlineData(-1, 1)]
    [InlineData(16, 5)]
    [InlineData(4, -4)]
    void CheckRocketLanding_OutOfPlatform(int x, int y)
    {
        string resp = new RocketLanding().CheckLandAvailability(1, x, y);
        Assert.Same(ResponseConst.OUT_OF_PLATFORM, resp);
    }

    [Theory]
    [InlineData(7, 7)]
    [InlineData(10, 5)]
    [InlineData(5, 14)]
    void CheckRocketLanding_Clash_SamePosition(int x, int y)
    {
        RocketLanding rocketLanding = new();
        string respA = rocketLanding.CheckLandAvailability(1, x, y);
        string respB = rocketLanding.CheckLandAvailability(2, x, y);
        Assert.Same(ResponseConst.OK_FOR_LANDING, respA);
        Assert.Same(ResponseConst.CLASH, respB);
    }

    [Theory]
    [InlineData(7, 7, 8, 8)]
    [InlineData(10, 5, 11, 5)]
    [InlineData(5, 14, 5, 13)]
    void CheckRocketLanding_Clash_NearPosition(int xA, int yA, int xB, int yB)
    {
        RocketLanding rocketLanding = new();
        string respA = rocketLanding.CheckLandAvailability(1, xA, yA);
        string respB = rocketLanding.CheckLandAvailability(2, xB, yB);
        Assert.Same(ResponseConst.OK_FOR_LANDING, respA);
        Assert.Same(ResponseConst.CLASH, respB);
    }

    [Theory]
    [InlineData(10, 10, 5, 5, 4, 4)]
    [InlineData(2, 5, 5, 5, 4, 4)]
    void CheckRocketLandingOnCustomPlatform_OutOfPlatform(int x, int y, int platformWidth, int platformHeight, int xPlatformPosition, int yPlatformPosition)
    {
        Platform platform = new(platformWidth, platformHeight, xPlatformPosition, yPlatformPosition);
        string resp = new RocketLanding(platform).CheckLandAvailability(1, x, y);
        Assert.Same(ResponseConst.OUT_OF_PLATFORM, resp);
    }

    [Theory]
    [InlineData(6, 5, 5, 5, 4, 4)]
    [InlineData(8, 8, 5, 5, 4, 4)]
    void CheckRocketLandingOnCustomPlatform_OkForLanding(int x, int y, int platformWidth, int platformHeight, int xPlatformPosition, int yPlatformPosition)
    {
        Platform platform = new(platformWidth, platformHeight, xPlatformPosition, yPlatformPosition);
        string resp = new RocketLanding(platform).CheckLandAvailability(1, x, y);
        Assert.Same(ResponseConst.OK_FOR_LANDING, resp);
    }
}