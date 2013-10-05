using System;
using Xunit;

namespace MarsRover.Tests
{
    public class MarsRoverFixture
    {
        [Fact]
        public void CanCreateRover()
        {
            var rover = new Rover(new Position(0, 0), Direction.N);
            Assert.NotNull(rover);
        }

        [Fact]
        public void MoveRoverForwardFacingNorth()
        {
            var rover = new Rover(new Position(0, 0), Direction.N);

            rover.Go(@"f");

            Assert.Equal(new Position(0, 1), rover.RoverState.Position);
        }

        [Fact]
        public void MoveRoverBackwardFacingNorth()
        {
            var rover = new Rover(new Position(1, 1), Direction.N);

            rover.Go(@"b");

            Assert.Equal(new Position(1, 0), rover.RoverState.Position);
        }

        [Fact]
        public void MoveRoverForwardFacingSouth()
        {
            var rover = new Rover(new Position(1, 1), Direction.S);

            rover.Go(@"f");

            Assert.Equal(new Position(1, 0), rover.RoverState.Position);
        }

        [Fact]
        public void MoveRoverBackwardFacingSouth()
        {
            var rover = new Rover(new Position(1, 1), Direction.S);

            rover.Go(@"b");

            Assert.Equal(new Position(1, 2), rover.RoverState.Position);
        }

        [Fact]
        public void MoveRoverForwardFacingWest()
        {
            var rover = new Rover(new Position(1, 1), Direction.W);

            rover.Go(@"f");

            Assert.Equal(new Position(0, 1), rover.RoverState.Position);
        }

        [Fact]
        public void MoveRoverBackwardFacingWest()
        {
            var rover = new Rover(new Position(1, 1), Direction.W);

            rover.Go(@"b");

            Assert.Equal(new Position(2, 1), rover.RoverState.Position);
        }

        [Fact]
        public void MoveRoverForwardFacingEast()
        {
            var rover = new Rover(new Position(1, 1), Direction.E);

            rover.Go(@"f");

            Assert.Equal(new Position(2, 1), rover.RoverState.Position);
        }

        [Fact]
        public void MoveRoverBackwardFacingEast()
        {
            var rover = new Rover(new Position(1, 1), Direction.E);

            rover.Go(@"b");

            Assert.Equal(new Position(0, 1), rover.RoverState.Position);
        }

        [Fact]
        public void MovingRoverForwardAndBackWardTwiceBringsBackRoverToStartingPostion()
        {
            var rover = new Rover(new Position(0, 0), Direction.N);

            rover.Go(@"ffbb");

            Assert.Equal(new Position(0, 0), rover.RoverState.Position);
        }

        [Fact]
        public void TurnRoverLeftFacingNorth()
        {
            var rover = new Rover(new Position(1, 1), Direction.N);

            rover.Go(@"l");

            Assert.Equal(Direction.W, rover.RoverState.Direction);
        }

        [Fact]
        public void TurnRoverRightFacingNorth()
        {
            var rover = new Rover(new Position(1, 1), Direction.N);

            rover.Go(@"r");

            Assert.Equal(Direction.E, rover.RoverState.Direction);
        }

        [Fact]
        public void TurnRoverLeftFacingSouth()
        {
            var rover = new Rover(new Position(1, 1), Direction.S);

            rover.Go(@"l");

            Assert.Equal(Direction.E, rover.RoverState.Direction);
        }

        [Fact]
        public void TurnRoverRightFacingSouth()
        {
            var rover = new Rover(new Position(1, 1), Direction.S);

            rover.Go(@"r");

            Assert.Equal(Direction.W, rover.RoverState.Direction);
        }

        [Fact]
        public void TurnRoverLeftFacingEast()
        {
            var rover = new Rover(new Position(1, 1), Direction.E);

            rover.Go(@"l");

            Assert.Equal(Direction.N, rover.RoverState.Direction);            
        }

        [Fact]
        public void TurnRoverRightFacingEast()
        {
            var rover = new Rover(new Position(1, 1), Direction.E);

            rover.Go(@"r");

            Assert.Equal(Direction.S, rover.RoverState.Direction);
        }

        [Fact]
        public void TurnRoverLeftFacingWest()
        {
            var rover = new Rover(new Position(1, 1), Direction.W);

            rover.Go(@"l");

            Assert.Equal(Direction.S, rover.RoverState.Direction);
        }

        [Fact]
        public void TurnRoverRightFacingWest()
        {
            var rover = new Rover(new Position(1, 1), Direction.W);

            rover.Go(@"r");

            Assert.Equal(Direction.N, rover.RoverState.Direction);            
        }

        [Fact]
        public void MoveRoverWithSeriesOfCommands()
        {
            var rover = new Rover(new Position(0, 0), Direction.N);

            rover.Go(@"ffrff");

            Assert.Equal(new Position(2, 2), rover.RoverState.Position);
            Assert.Equal(Direction.E, rover.RoverState.Direction);
        }

        [Fact]
        public void GoingOffTheGridToTheLeftWrapsToTheRight()
        {
            var rover = new Rover(new Position(0, 0), Direction.W, new Grid(100, 100));

            rover.Go(@"f");

            Assert.Equal(new Position(99, 0), rover.RoverState.Position);
        }

        [Fact]
        public void GoingOffTheGridToTheRightWrapsToTheLeft()
        {
            var rover = new Rover(new Position(99, 1), Direction.E, new Grid(100, 100));

            rover.Go(@"f");

            Assert.Equal(new Position(0, 1), rover.RoverState.Position);
        }

        [Fact]
        public void GoingOffTheGridToTheBottomWrapsToTheTop()
        {
            var rover = new Rover(new Position(1, 0), Direction.N, new Grid(100, 100));

            rover.Go(@"b");

            Assert.Equal(new Position(1, 99), rover.RoverState.Position);
        }

        [Fact]
        public void GoingOffTheGridToTheTopWrapsToTheBottom()
        {
            var rover = new Rover(new Position(1, 99), Direction.N, new Grid(100, 100));

            rover.Go(@"ff");

            Assert.Equal(new Position(1, 1), rover.RoverState.Position);
        }

        [Fact]
        public void RoverStopsJustBeforeObstacleWhileUsingForwardCommands()
        {
            var grid = new Grid(5, 5);
            grid.AddObstacle(1, 1);
            var rover = new Rover(new Position(0, 0), Direction.N, grid);

            rover.Go(@"frff");

            Assert.Equal(new Position(0, 1), rover.RoverState.Position);
        }

        [Fact]
        public void RoverStopsJustBeforeObstacleWhileUsingBackwardCommands()
        {
            var grid = new Grid(5, 5);
            grid.AddObstacle(4, 3);
            var rover = new Rover(new Position(0, 0), Direction.N, grid);

            rover.Go(@"bbrbb");

            Assert.Equal(new Position(0, 3), rover.RoverState.Position);
        }

        [Fact]
        public void UnknownCommandThrowsException()
        {
            var rover = new Rover(new Position(0, 0), Direction.N);

            Assert.Throws<NotSupportedException>(() => rover.Go(@"fc"));
        }
    }
}