using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Engine.Exceptions
{
    public class InvalidMovement : Exception
    {
        const string message = "Invalid Movement!";
        public InvalidMovement() : base(message)
        {
        }

        public InvalidMovement(string message) : base(message)
        {
        }
    }
}
