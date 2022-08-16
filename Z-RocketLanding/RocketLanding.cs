using Zts_RocketLanding_Library.Dtos;
using Zts_RocketLanding_Library.Enum;
namespace Zts_RocketLanding_Library;

public class RocketLanding
{
    private readonly Platform Platform;
    private readonly List<PositionHistory> PositionHistory = new List<PositionHistory>();
    /// <summary>
    /// Rocket landing helper with default landing platform
    /// </summary>
    public RocketLanding()
    {
        Platform = new Platform();
    }

    /// <summary>
    /// Rocket landing helper with custom landing platform
    /// </summary>
    /// <param name="platform">Custom platform</param>
    public RocketLanding(Platform platform)
    {
        Platform = platform;
    }

    ///// <summary>
    ///// Determines if the requested position is available for landing
    ///// </summary>
    ///// <returns>"out of platform", "clash" or "ok for landing"</returns>
    public string CheckLandAvailability(int rocketId, int x, int y)
    {
        if (!PositionIsInsideOfArea(Platform.XLeftTopVertexPosition, Platform.YLeftTopVertexPosition,
            Platform.Width, Platform.Height, x, y))
            return ResponseConst.OUT_OF_PLATFORM;
        if (!PositionIsFarFromOtherLanding(rocketId, x, y))
            return ResponseConst.CLASH;

        this.PositionHistory.Add(new PositionHistory(rocketId, x, y));
        return ResponseConst.OK_FOR_LANDING;
    }

    #region positionAvailability
    bool PositionIsInsideOfArea(int areaXTopLeft, int areaYTopfLeft, int areaWidth, int areaHeight, int x, int y)
    {
        if (x < Platform.MINOR_LIMIT || x > Platform.MAJOR_LIMIT || y < Platform.MINOR_LIMIT || y > Platform.MAJOR_LIMIT)
            return false;

        bool isInsideX = (x - areaXTopLeft > -1) && (x - areaXTopLeft < areaWidth);
        bool isIndiseY = (y - areaYTopfLeft > -1) && (y - areaYTopfLeft < areaHeight);
        return isInsideX && isIndiseY;
    }

    bool PositionIsFarFromOtherLanding(int rocketId, int x, int y)
    {
        var allPositionsCheckedByOthers = this.PositionHistory.Where(r => r.rocketId != rocketId);
        var lastPositionCheckedByOther = allPositionsCheckedByOthers.LastOrDefault();
        //If last check from another rocket is the same position
        if (lastPositionCheckedByOther != null && lastPositionCheckedByOther.x == x && lastPositionCheckedByOther.y == y)
            return false;

        //If a near position was checked by another rocket
        foreach (var position in allPositionsCheckedByOthers)
            if (PositionIsInsideOfArea(position.x - 1, position.y - 1, 3, 3, x, y))
                return false;

        return true;
    }

    #endregion positionAvailability
}