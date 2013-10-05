using NSubstitute;
using Xunit;

namespace MarsRover.Tests
{
    public class NavigatorFixture
    {
        [Fact]
        public void CanCreateNavigator()
        {
            var grid = Substitute.For<IGrid>();
            var navigator = new Navigator(grid);

            Assert.NotNull(navigator);
        }

        [Fact]
        public void GoingOffTheGridToTheLeftWrapsToTheRight()
        {
            var grid = Substitute.For<IGrid>();
            var navigator = new Navigator(grid);
            grid.Width.Returns(5);
            grid.Height.Returns(5);

            var pos = navigator.Wrap(new Position(-1, 2));

            Assert.Equal(new Position(4, 2), pos);
        }

        [Fact]
        public void GoingOffTheGridToTheRightWrapsToTheLeft()
        {
            var grid = Substitute.For<IGrid>();
            var navigator = new Navigator(grid);
            grid.Width.Returns(5);
            grid.Height.Returns(5);

            var pos = navigator.Wrap(new Position(6, 2));

            Assert.Equal(new Position(1, 2), pos); 
        }

        [Fact]
        public void GoingOffTheGridToTheBottomWrapsToTheTop()
        {
            var grid = Substitute.For<IGrid>();
            var navigator = new Navigator(grid);
            grid.Width.Returns(5);
            grid.Height.Returns(5);

            var pos = navigator.Wrap(new Position(2, -2));

            Assert.Equal(new Position(2, 3), pos); 
        }

        [Fact]
        public void GoingOffTheGridToTheTopWrapsToTheBottom()
        {
            var grid = Substitute.For<IGrid>();
            var navigator = new Navigator(grid);
            grid.Width.Returns(5);
            grid.Height.Returns(5);

            var pos = navigator.Wrap(new Position(2, 5));

            Assert.Equal(new Position(2, 0), pos);
        }
    }
}