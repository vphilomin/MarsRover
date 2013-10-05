namespace MarsRover
{
    public class ObstacleDetector : IObstacleDetector
    {
        private readonly IGrid _grid;

        public ObstacleDetector(IGrid grid)
        {
            _grid = grid;
        }

        public bool IsObstacleAt(Position position)
        {
            return _grid.IsObstacleAt(position.X, position.Y);
        }
    }
}