namespace MarsRover.Engine.Rover
{
    public interface IPosition
    {
        Direction Direction { get; set; }
        int X { get; set; }
        int Y { get; set; }

        void SetPosition(int x, int y, Direction direction);
    }
}