using MarsRover.Engine.Plateau;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Engine.Command
{
    public class SetPlateauCommand : ICommand, ISetPlateauCommand
    {
        public CommandType CommandType { get => CommandType.SetPlateau; }
        public string Command { get; set; }
        private IPlateau _plateau;

        public SetPlateauCommand(IPlateau plateau)
        {
            _plateau = plateau;
        }

        public void Initialize(string command)
        {
            Command = command;
        }
        public void Execute()
        {
            ValidateCommand();
            string[] commandParams = Command.Split(' ');
            _plateau.SetSize(Int32.Parse(commandParams[0]), Int32.Parse(commandParams[1]));
        }

        public IPlateau GetPlateau()
        {
            return _plateau;
        }

        private bool ValidateCommand()
        {
            //TODO
            return true;
        }
    }
}
