namespace MarsRover
{
    public class TurnRightCommand : GoCommand
    {
        public TurnRightCommand(RoverState roverState) : base(roverState)
        {
        }

        public override void Go()
        {
            switch (RoverState.Direction)
            {
                case Direction.N:
                    RoverState.Direction = Direction.E;
                    break;
                case Direction.S:
                    RoverState.Direction = Direction.W;
                    break;
                case Direction.E:
                    RoverState.Direction = Direction.S;
                    break;
                case Direction.W:
                    RoverState.Direction = Direction.N;
                    break;
            }
        }
    }
}