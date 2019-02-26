using System.Collections.Generic;
using MarsRover.Engine.Plateau;
using MarsRover.Engine.Rover;

namespace MarsRover.Engine.Movement
{
    public interface IMovement
    {
        void Move(MovementDirection movementDirection);
        void SetRover(IPlateau plateau, List<IRover> deployedRovers, IRover rover);
    }
}