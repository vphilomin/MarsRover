namespace MarsRover
{
    public interface INavigator
    {
        Position Wrap(Position position);
    }
}