namespace MarsRover.Engine.Rover
{
    public interface IRover
    {
        IPosition Position { get; }

        void Deploy(IPosition position);
    }
}