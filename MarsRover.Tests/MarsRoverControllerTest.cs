using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Engine.Command;
using NUnit.Framework;
using Moq;
using MarsRover.Engine.Plateau;
using MarsRover.Engine.Rover;
using MarsRover.Engine.Exceptions;
using Autofac;
using System.Reflection;

namespace MarsRover.Tests
{
    [TestFixture]
    public class MarsRoverControllerTest
    {
        private IContainer container;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            container = ContainerConfig.Configure();
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            container.Dispose();
        }
        [Test]
        public void GetExpectedOutputForCommand()
        {
            string command = GetCommandString();
            var marsRoverController = container.Resolve<IMarsRoverController>();
            string output = marsRoverController.ExecuteCommand(command);
            Assert.AreEqual(GetExpectedResult(), output);
        }

        private string GetCommandString()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");
            commandStringBuilder.AppendLine("3 3 E");
            commandStringBuilder.Append("MMRMMRMRRM");
            return commandStringBuilder.ToString();
        }

        private string GetExpectedResult()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("1 3 N");
            commandStringBuilder.AppendLine("5 1 E");
            return commandStringBuilder.ToString();
        }
    }
}
