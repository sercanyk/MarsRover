using System.Collections.Generic;

namespace MarsRover.Engine.Command
{
    public interface ICommandParser
    {
        List<KeyValuePair<CommandType, string>> CommandList { get; }
        string InitialCommandString { get; }

        List<KeyValuePair<CommandType, string>> ParseCommand(string command);
    }
}