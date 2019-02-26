using MarsRover.Engine.Plateau;

namespace MarsRover.Engine.Command
{
    public interface ISetPlateauCommand
    {
        string Command { get; }
        CommandType CommandType { get; }

        void Execute();
        IPlateau GetPlateau();
        void Initialize(string command);
    }
}