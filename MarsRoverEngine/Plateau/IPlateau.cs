namespace MarsRover.Engine.Plateau
{
    public interface IPlateau
    {
        IDimension GetSize();
        void SetSize(int x, int y);
    }
}