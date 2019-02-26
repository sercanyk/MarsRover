using System.Collections.Generic;
using MarsRover.Engine.Plateau;
using MarsRover.Engine.Rover;

namespace MarsRover.Engine.Command
{
    public interface IDeployRoverCommand
    {
        string Command { get; }
        CommandType CommandType { get; set; }

        void Execute();
        IRover GetRover();
        void Initialize(IPlateau plateau, List<IRover> roverList, string command);
    }
}