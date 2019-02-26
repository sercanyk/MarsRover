using MarsRover.Engine.Exceptions;
using MarsRover.Engine.Plateau;
using MarsRover.Engine.Rover;
using System;
using System.Collections.Generic;

namespace MarsRover.Engine.Movement
{
    public class Movement : IMovement
    {
        IPlateau _plateau;
        IRover _rover;
        List<IRover> _deployedRoverList;

        public void SetRover(IPlateau plateau, List<IRover> deployedRovers, IRover rover)
        {
            _plateau = plateau;
            _deployedRoverList = deployedRovers;
            _rover = rover;
        }

        public void Move(MovementDirection movementDirection)
        {
            int currentPositionX = _rover.Position.X;
            int currentPositionY = _rover.Position.Y;
            Direction currentDirection = _rover.Position.Direction;

            if (movementDirection == MovementDirection.Forward)
            {
                switch (_rover.Position.Direction)
                {
                    case Direction.North:
                        currentPositionY++;
                        break;
                    case Direction.East:
                        currentPositionX++;
                        break;
                    case Direction.South:
                        currentPositionY--;
                        break;
                    case Direction.West:
                        currentPositionX--;
                        break;
                }
            }
            else
            {
                Direction[] directionArray = { Direction.West, Direction.North, Direction.East, Direction.South };
                int currentIndex = Array.FindIndex(directionArray, a => a == currentDirection);
                int nextIndex = movementDirection == MovementDirection.Left ? (currentIndex + directionArray.Length - 1) % directionArray.Length : (currentIndex + 1) % directionArray.Length;
                currentDirection = directionArray[nextIndex];
            }
            ValidatePosition(currentPositionX, currentPositionY, currentDirection);
            _rover.Position.X = currentPositionX;
            _rover.Position.Y = currentPositionY;
            _rover.Position.Direction = currentDirection;
        }

        private void ValidatePosition(int x, int y, Direction direction)
        {
            var isValidX = x >= 0 && x <= _plateau.GetSize().Width;
            var isValidY = y >= 0 && y <= _plateau.GetSize().Height;
            if (!isValidX || !isValidY)
            {
                throw new InvalidMovement();
            }
            foreach (var rover in _deployedRoverList)
            {
                // Ignore current Rover
                if (_rover.Position.X == rover.Position.X && _rover.Position.Y == rover.Position.Y)
                    continue;
                if (rover.Position.X == x && rover.Position.Y == y)
                    throw new InvalidMovement("Position occupied by another Rover!");
            }
        }
    }
}
