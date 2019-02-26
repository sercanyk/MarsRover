using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Engine.Command;
using NUnit.Framework;
using Moq;
using MarsRover.Engine.Plateau;
using MarsRover.Engine.Rover;
using MarsRover.Engine.Exceptions;
using MarsRover.Engine.Movement;

namespace MarsRover.Tests.Command
{
    [TestFixture]
    public class MoveRoverCommandTest
    {
        [Test]
        public void ExposesCorrectCommandType()
        {
            var mockRover = new Mock<IMovement>();
            MoveRoverCommand moveRoverCommand = new MoveRoverCommand(mockRover.Object);
            CommandType commandType = moveRoverCommand.CommandType;
            Assert.AreEqual(CommandType.MoveRover, commandType);
        }

        [Test]
        [TestCase("1 1 N", "LM", ExpectedResult = "0 1 W")]
        [TestCase("4 0 N", "LMMMM", ExpectedResult = "0 0 W")]
        public string Execute_MoveRoverObjectToCorrectPosition_WhenInitializedWithCommand(string currentPosition, string moveCommand)
        {
            Dimension dimension = new Dimension();
            Plateau plateau = new Plateau(dimension);
            plateau.SetSize(5, 5);
            Rover rover = new Rover();
            Position position = new Position();
            List<IRover> deployedRovers = new List<IRover>();
            DeployRoverCommand deployRoverCommandObject = new DeployRoverCommand(rover, position);
            deployRoverCommandObject.Initialize(plateau, deployedRovers, currentPosition);
            deployRoverCommandObject.Execute();

            Movement movement = new Movement();
            MoveRoverCommand moveRoverCommand = new MoveRoverCommand(movement);
            moveRoverCommand.Initialize(plateau, deployedRovers, rover, moveCommand);
            moveRoverCommand.Execute();

            string lastPosition = string.Format("{0} {1} {2}", rover.Position.X, rover.Position.Y, rover.Position.Direction.ToString()[0]);
            return lastPosition;
        }

        [Test]
        [TestCase("4 0 N", "LMMMMM")]
        public void Execute_ThrowsInvalidMevementException_WhenMovedPositionNotInsidePlateau(string currentPosition, string moveCommand)
        {
            Dimension dimension = new Dimension();
            Plateau plateau = new Plateau(dimension);
            plateau.SetSize(5, 5);
            Rover rover = new Rover();
            Position position = new Position();
            List<IRover> deployedRovers = new List<IRover>();
            DeployRoverCommand deployRoverCommandObject = new DeployRoverCommand(rover, position);
            deployRoverCommandObject.Initialize(plateau, deployedRovers, currentPosition);
            deployRoverCommandObject.Execute();

            Movement movement = new Movement();
            MoveRoverCommand moveRoverCommand = new MoveRoverCommand(movement);
            moveRoverCommand.Initialize(plateau, deployedRovers, rover, moveCommand);
            Assert.Catch<InvalidMovement>(() => moveRoverCommand.Execute());
        }
    }
}
