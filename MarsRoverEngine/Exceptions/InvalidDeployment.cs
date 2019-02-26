using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Engine.Exceptions
{
    public class InvalidDeployment : Exception
    {
        private const string message = "Invalid Deployment!";
        public InvalidDeployment() : base(message)
        {
        }
        public InvalidDeployment(string message) : base(message)
        {
        }
    }
}
