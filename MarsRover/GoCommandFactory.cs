using System;

namespace MarsRover
{
    public class GoCommandFactory
    {
        public RoverState RoverState { get; set; }
        public INavigator Navigator { get; set; }
        public IObstacleDetector ObstacleDetector { get; set; }

        public GoCommandFactory(RoverState roverState, INavigator navigator, IObstacleDetector obstacleDetector)
        {
            RoverState = roverState;
            Navigator = navigator;
            ObstacleDetector = obstacleDetector;
        }

        public IGoCommand Create(char command)
        {
            switch (command)
            {
                case 'f':
                    return new MoveForwardCommand(RoverState, Navigator, ObstacleDetector);
                case 'b':
                    return new MoveBackwardCommand(RoverState, Navigator, ObstacleDetector);
                case 'l':
                    return new TurnLeftCommand(RoverState);
                case 'r':
                    return new TurnRightCommand(RoverState);
                default:
                    throw new NotSupportedException(@"Unknown command");
            }
        }
    }
}