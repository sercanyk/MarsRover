using MarsRover.Engine.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MarsRover.Engine.Command
{
    public class CommandParser : ICommandParser
    {
        public string InitialCommandString { get; private set; }
        public List<KeyValuePair<CommandType, string>> CommandList { get; private set; }

        public List<KeyValuePair<CommandType, string>> ParseCommand(string command)
        {
            InitialCommandString = command;
            ValidateCommand();

            CommandList = new List<KeyValuePair<CommandType, string>>();
            using (StringReader commandReader = new StringReader(InitialCommandString))
            {
                string line;
                int index = 0;
                while ((line = commandReader.ReadLine()) != null)
                {
                    CommandList.Add(new KeyValuePair<CommandType, string>(DetermineCommandType(index), line));
                    index++;
                }
            }
            return CommandList;
        }

        private CommandType DetermineCommandType(int index)
        {
            if (index == 0)
            {
                return CommandType.SetPlateau;
            }
            switch ((index - 1) % 2)
            {
                case 0:
                    return CommandType.DeployRover;
                case 1:
                    return CommandType.MoveRover;
            }
            throw new InvalidCommand();
        }

        private void ValidateCommand()
        {
            //TODO
        }
    }
}
