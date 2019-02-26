using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Engine.Exceptions
{
    public class InvalidDimension : Exception
    {
        private const string message = "Invalid Dimension!";
        public InvalidDimension() : base(message)
        {
        }
    }
}
