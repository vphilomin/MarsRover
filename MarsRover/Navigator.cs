namespace MarsRover
{
    public class Navigator : INavigator
    {
        private readonly IGrid _grid;

        public Navigator(IGrid grid)
        {
            _grid = grid;
        }

        public Position Wrap(Position position)
        {
            var wrappedX = WrapX(position.X);
            var wrappedY = WrapY(position.Y);
            
            return new Position(wrappedX, wrappedY);
        }

        private int WrapY(int y)
        {
            if (y < 0)
                return _grid.Height + y;
            if (y >= _grid.Height)
                return y - _grid.Height;
            return y;
        }

        private int WrapX(int x)
        {
            if (x < 0)
                return _grid.Width + x;
            if (x >= _grid.Width)
                return x - _grid.Width;
            return x;
        }
    }
}