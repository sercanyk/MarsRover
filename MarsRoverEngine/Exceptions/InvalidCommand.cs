using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Engine.Exceptions
{
    public class InvalidCommand : Exception
    {
        private const string message = "InvalidCommand!";
        public InvalidCommand() : base(message)
        {
        }
    }
}
