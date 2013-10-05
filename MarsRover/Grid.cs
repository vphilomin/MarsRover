using System.Collections.Generic;

namespace MarsRover
{
    public class Grid : IGrid
    {
        private readonly List<Position> _obstacles = new List<Position>();
        public int Width { get; set; }
        public int Height { get; set; }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void AddObstacle(int x, int y)
        {
            _obstacles.Add(new Position(x, y));
        }

        public bool IsObstacleAt(int x, int y)
        {
            return _obstacles.Contains(new Position(x, y));
        }
    }
}