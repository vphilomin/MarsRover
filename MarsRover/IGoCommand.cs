namespace MarsRover
{
    public interface IGoCommand
    {
        bool CanGo();
        void Go();
    }
}