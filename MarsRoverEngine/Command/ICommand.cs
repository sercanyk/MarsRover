using MarsRover.Engine.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MarsRover.Engine.Command
{
    public interface ICommand
    {
        CommandType CommandType { get; }
        string Command { get; set; }
        void Execute();

    }
}
