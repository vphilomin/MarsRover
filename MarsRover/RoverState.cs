namespace MarsRover
{
    public class RoverState
    {
        public Position Position { get; set; }
        public Direction Direction { get; set; }

        public RoverState(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}