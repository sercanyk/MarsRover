using MarsRover.Engine.Exceptions;
using MarsRover.Engine.Movement;
using MarsRover.Engine.Plateau;

namespace MarsRover.Engine.Rover
{
    public class Rover : IRover
    {
        public IPosition Position { get; private set; }

        public void Deploy(IPosition position)
        {
            Position = position;
        }
    }
}
