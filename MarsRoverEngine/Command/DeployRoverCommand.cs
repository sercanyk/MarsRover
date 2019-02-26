using MarsRover.Engine.Exceptions;
using MarsRover.Engine.Plateau;
using MarsRover.Engine.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Engine.Command
{
    public class DeployRoverCommand : ICommand, IDeployRoverCommand
    {
        public CommandType CommandType { get => CommandType.DeployRover; set => throw new NotImplementedException(); }
        private IPlateau _plateau;
        private List<IRover> _roverList;
        private IRover _rover;
        private IPosition _position;
        public string Command { get; set; }
        private readonly IDictionary<char, Direction> directionDictionary;

        public DeployRoverCommand(IRover rover, IPosition position)
        {
            _rover = rover;
            _position = position;

            directionDictionary = new Dictionary<char, Direction>
            {
                 {'N', Direction.North},
                 {'S', Direction.South},
                 {'E', Direction.East},
                 {'W', Direction.West}
            };

        }

        public void Initialize(IPlateau plateau, List<IRover> roverList, string command)
        {
            _plateau = plateau;
            _roverList = roverList;
            Command = command;
        }

        public void Execute()
        {
            string[] commandParams = Command.Split(' ');
            _position.X = Int32.Parse(commandParams[0]);
            _position.Y = Int32.Parse(commandParams[1]);
            _position.Direction = directionDictionary[Char.Parse(commandParams[2])];

            ValidateCommand();
            _rover.Deploy(_position);
            _roverList.Add(_rover);
        }


        public IRover GetRover()
        {
            return _rover;
        }

        private bool ValidateCommand()
        {
            var isValidX = _position.X >= 0 && _position.X <= _plateau.GetSize().Width;
            var isValidY = _position.Y >= 0 && _position.Y <= _plateau.GetSize().Height;
            if (!isValidX || !isValidY)
            {
                throw new InvalidDeployment();
            }

            foreach (var rover in _roverList)
            {
                if (rover.Position.X == _position.X && rover.Position.Y == _position.Y)
                    throw new InvalidDeployment("Position occupied by another Rover!");
            }
            return true;
        }

    }
}
