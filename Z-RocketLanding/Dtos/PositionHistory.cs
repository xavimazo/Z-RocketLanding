namespace Zts_RocketLanding_Library.Dtos;

public class PositionHistory
{
    public PositionHistory(int rocketId, int x, int y)
    {
        this.rocketId = rocketId;
        this.x = x;
        this.y = y;
    }

    public int rocketId { get; set; }
    public int x { get; set; }
    public int y { get; set; }
}