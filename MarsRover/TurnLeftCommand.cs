namespace MarsRover
{
    public class TurnLeftCommand : GoCommand
    {
        public TurnLeftCommand(RoverState roverState) : base(roverState)
        {
        }

        public override void Go()
        {
            switch (RoverState.Direction)
            {
                case Direction.N:
                    RoverState.Direction = Direction.W;
                    break;
                case Direction.S:
                    RoverState.Direction = Direction.E;
                    break;
                case Direction.E:
                    RoverState.Direction = Direction.N;
                    break;
                case Direction.W:
                    RoverState.Direction = Direction.S;
                    break;
            }
        }
    }
}