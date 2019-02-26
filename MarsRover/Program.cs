using System;
using System.Text;
using Autofac;
using MarsRover.Engine;
using MarsRover.Engine.Command;
using MarsRover.Engine.Plateau;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                string commandString = GetCommandString();
                Console.WriteLine(commandString);
                var marsRoverController = scope.Resolve<IMarsRoverController>();
                string result = marsRoverController.ExecuteCommand(commandString);
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }

        private static string GetCommandString()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");
            commandStringBuilder.AppendLine("3 3 E");
            commandStringBuilder.Append("MMRMMRMRRM");
            return commandStringBuilder.ToString();
        }
    }
}
