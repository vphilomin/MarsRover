namespace MarsRover
{
    public abstract class GoCommand : IGoCommand
    {
        public RoverState RoverState { get; set; }

        protected GoCommand(RoverState roverState)
        {
            RoverState = roverState;
        }

        public virtual bool CanGo()
        {
            return true;
        }

        public abstract void Go();
    }
}