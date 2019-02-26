using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Engine.Rover
{
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public void SetPosition(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}
