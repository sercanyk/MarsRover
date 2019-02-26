namespace MarsRover.Engine.Plateau
{
    public interface IDimension
    {
        int Height { get; }
        int Width { get; }

        void SetDimension(int width, int height);
    }
}