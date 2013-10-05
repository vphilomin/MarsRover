namespace MarsRover
{
    public class MoveBackwardCommand : MoveCommand
    {
        public MoveBackwardCommand(RoverState roverState, INavigator navigator, IObstacleDetector obstacleDetector) 
            : base(roverState, navigator, obstacleDetector)
        {
            
        }

        protected override Position ComputeNewPosition()
        {
            var position = RoverState.Position.DeepClone();

            switch (RoverState.Direction)
            {
                case Direction.N:
                    position.DecrementY();
                    break;
                case Direction.S:
                    position.IncrementY();
                    break;
                case Direction.W:
                    position.IncrementX();
                    break;
                case Direction.E:
                    position.DecrementX();
                    break;
            }

            return position;
        }
    }
}