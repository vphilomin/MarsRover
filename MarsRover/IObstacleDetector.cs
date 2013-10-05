namespace MarsRover
{
    public interface IObstacleDetector
    {
        bool IsObstacleAt(Position position);
    }
}