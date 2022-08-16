namespace Zts_RocketLanding_Library;

public class Platform
{
    public const int MINOR_LIMIT = 0;
    public const int MAJOR_LIMIT = 99;
    private const int DEFAULT_WIDTH = 10;
    private const int DEFAULT_HEIGHT = 10;
    private const int DEFAULT_X = 5;
    private const int DEFAULT_Y = 5;

    /// <summary>
    /// Create a default Platform position of 15x15 tiles and on 5,5 position.
    /// </summary>
    public Platform() { }

    /// <summary>
    /// Create a custom size or/and Platform position
    /// </summary>
    /// <param name="width">Platform width. Should be between 0 and 99. If not specified, default value is 15.</param>
    /// <param name="height">Platform height. Should be between 0 and 99. If not specified, default value is 15.</param>
    /// <param name="xLeftTopVertexPosition">X position of left top vertex position.
    /// Should fit inside landing area calculating width and height. If not specified, default value is 5.</param>
    /// <param name="yLeftTopVertexPosition">Y position of left top vertex position.
    /// Should fit inside landing area calculating width and height. If not specified, default value is 5.</param>
    public Platform(int width = DEFAULT_WIDTH, int height = DEFAULT_HEIGHT,
        int xLeftTopVertexPosition = DEFAULT_X, int yLeftTopVertexPosition = DEFAULT_Y)
    {
        ValidateInputData(width, height, xLeftTopVertexPosition, yLeftTopVertexPosition);
        ValidatePlatformConfiguration(width, height, xLeftTopVertexPosition, yLeftTopVertexPosition);
        CreatePlatform(width, height, xLeftTopVertexPosition, yLeftTopVertexPosition);
    }

    public int Width { get; set; } = DEFAULT_WIDTH;
    public int Height { get; set; } = DEFAULT_HEIGHT;
    public int XLeftTopVertexPosition { get; set; } = DEFAULT_X;
    public int YLeftTopVertexPosition { get; set; } = DEFAULT_Y;

    #region platformCreation
    private static void ValidateInputData(int width, int height, int xLeftTopVertexPosition, int yLeftTopVertexPosition)
    {
        List<string> errorMessages = new List<string>();
        if (width < MINOR_LIMIT || width > MAJOR_LIMIT)
            errorMessages.Add($"Width value should be between {MINOR_LIMIT} and {MAJOR_LIMIT}");
        if (height < MINOR_LIMIT || height > MAJOR_LIMIT)
            errorMessages.Add($"Height value should be between {MINOR_LIMIT} and {MAJOR_LIMIT}");
        if (xLeftTopVertexPosition < MINOR_LIMIT || xLeftTopVertexPosition > MAJOR_LIMIT)
            errorMessages.Add($"X left top vertex position axys should be between {MINOR_LIMIT} and {MAJOR_LIMIT}");
        if (yLeftTopVertexPosition < MINOR_LIMIT || yLeftTopVertexPosition > MAJOR_LIMIT)
            errorMessages.Add($"Y left top vertex position axys should be between {MINOR_LIMIT} and {MAJOR_LIMIT}");

        if (errorMessages.Any())
            throw new Exception(errorMessages.Aggregate((a, b) => $"{a}, {b}"));
    }

    private static void ValidatePlatformConfiguration(int width, int height, int xLeftTopVertexPosition, int yLeftTopVertexPosition)
    {
        if (width + xLeftTopVertexPosition > MAJOR_LIMIT || height + yLeftTopVertexPosition > MAJOR_LIMIT)
            throw new Exception($"Platform area does not fit for specified position. Try another position.");
    }

    private void CreatePlatform(int width, int height, int xLeftTopVertexPosition, int yLeftTopVertexPosition)
    {
        this.Width = width;
        this.Height = height;
        this.XLeftTopVertexPosition = xLeftTopVertexPosition;
        this.YLeftTopVertexPosition = yLeftTopVertexPosition;
    }
    #endregion platformCreation
}