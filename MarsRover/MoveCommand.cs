namespace MarsRover
{
    public abstract class MoveCommand : GoCommand
    {
        protected readonly INavigator Navigator;
        protected readonly IObstacleDetector ObstacleDetector;

        protected MoveCommand(RoverState roverState, INavigator navigator, IObstacleDetector obstacleDetector) : base(roverState)
        {
            Navigator = navigator;
            ObstacleDetector = obstacleDetector;
        }

        protected abstract Position ComputeNewPosition();

        public override bool CanGo()
        {
            return !ObstacleDetector.IsObstacleAt(GetWrappedNewPosition());
        }

        public override void Go()
        {
            RoverState.Position = GetWrappedNewPosition();
        }

        private Position GetWrappedNewPosition()
        {
            return Navigator.Wrap(ComputeNewPosition());
        }
    }
}