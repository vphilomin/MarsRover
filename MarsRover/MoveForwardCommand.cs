namespace MarsRover
{
    public class MoveForwardCommand : MoveCommand
    {
        public MoveForwardCommand(RoverState roverState, INavigator navigator, IObstacleDetector obstacleDetector) 
            : base(roverState, navigator, obstacleDetector)
        {
            
        }

        protected override Position ComputeNewPosition()
        {
            var position = RoverState.Position.DeepClone();

            switch (RoverState.Direction)
            {
                case Direction.N:
                    position.IncrementY();
                    break;
                case Direction.S:
                    position.DecrementY();
                    break;
                case Direction.W:
                    position.DecrementX();
                    break;
                case Direction.E:
                    position.IncrementX();
                    break;
            }

            return position;
        }
    }
}