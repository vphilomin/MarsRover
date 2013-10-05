namespace MarsRover
{
    public interface IGrid
    {
        int Width { get; }
        int Height { get; }
        bool IsObstacleAt(int x, int y);
    }
}