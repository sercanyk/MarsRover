using MarsRover.Engine.Movement;
using MarsRover.Engine.Plateau;
using MarsRover.Engine.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Engine.Command
{
    public class MoveRoverCommand : ICommand, IMoveRoverCommand
    {
        public CommandType CommandType { get => CommandType.MoveRover; set => throw new NotImplementedException(); }
        IPlateau _plateau;
        IRover _rover;
        IMovement _movement;
        List<IRover> _deployedRoverList;
        private readonly IDictionary<char, MovementDirection> movementDirectionDictionary;

        public string Command { get; set; }

        public MoveRoverCommand(IMovement movement)
        {
            _movement = movement;

            movementDirectionDictionary = new Dictionary<char, MovementDirection>
            {
                 {'L', MovementDirection.Left},
                 {'R', MovementDirection.Right},
                 {'M', MovementDirection.Forward}
            };
        }

        public void Execute()
        {
            ValidateCommand();
            foreach (char commandItem in Command.Trim())
            {
                _movement.Move(movementDirectionDictionary[commandItem]);
            }
        }

        public void Initialize(IPlateau plateau, List<IRover> deployedRoverList, IRover rover, string command)
        {
            _plateau = plateau;
            _rover = rover;
            _deployedRoverList = deployedRoverList;
            _movement.SetRover(_plateau, _deployedRoverList, _rover);
            Command = command;
        }

        private bool ValidateCommand()
        {
            //TODO
            return true;
        }

    }
}
