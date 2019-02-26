using System.Collections.Generic;
using MarsRover.Engine.Plateau;
using MarsRover.Engine.Rover;

namespace MarsRover.Engine.Command
{
    public interface IMoveRoverCommand
    {
        string Command { get; }
        CommandType CommandType { get; set; }

        void Execute();
        void Initialize(IPlateau plateau, List<IRover> deployedRoverList, IRover rover, string command);
    }
}