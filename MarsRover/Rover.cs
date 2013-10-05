namespace MarsRover
{
    public class Rover
    {
        private readonly INavigator _navigator;
        private readonly IObstacleDetector _obstacleDetector;
        public RoverState RoverState { get; set; }

        public Rover(Position position, Direction direction) : this(position, direction, new Grid(100, 100))
        {
        }

        public Rover(Position position, Direction direction, IGrid grid)
        {
            RoverState = new RoverState(position, direction);
            _navigator = new Navigator(grid);
            _obstacleDetector = new ObstacleDetector(grid);
        }

        public void Go(string commands)
        {
            var goCommandFactory = new GoCommandFactory(RoverState, _navigator, _obstacleDetector);
            foreach (var command in commands)
            {
                var goCommand = goCommandFactory.Create(command);
                if (!goCommand.CanGo())
                    break;
                goCommand.Go();
            }
        }
    }
}