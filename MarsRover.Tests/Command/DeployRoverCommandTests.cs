using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Engine.Command;
using NUnit.Framework;
using Moq;
using MarsRover.Engine.Plateau;
using MarsRover.Engine.Rover;
using MarsRover.Engine.Exceptions;

namespace MarsRover.Tests.Command
{
    [TestFixture]
    public class DeployRoverCommandTests
    {
        [Test]
        public void ExposesCorrectCommandType()
        {
            var mockRover = new Mock<IRover>();
            var mockPosition = new Mock<IPosition>();
            DeployRoverCommand deployRoverCommand = new DeployRoverCommand(mockRover.Object, mockPosition.Object);
            CommandType commandType = deployRoverCommand.CommandType;
            Assert.AreEqual(CommandType.DeployRover, commandType);
        }

        [Test]
        public void Initialize_ExposesCommandAsProperty_WhenCalledWithCommand()
        {
            string command = "1 1 N";
            var mockPlateau = new Mock<IPlateau>();
            var mockDimension = new Mock<IDimension>();
            mockDimension.Setup(d => d.Height).Returns(5);
            mockDimension.Setup(d => d.Width).Returns(5);
            mockPlateau.Setup(a => a.GetSize()).Returns(mockDimension.Object);
            List<IRover> roverList = new List<IRover>();
            var mockRover = new Mock<IRover>();
            var mockPosition = new Mock<IPosition>();
            DeployRoverCommand deployRoverCommandObject = new DeployRoverCommand(mockRover.Object, mockPosition.Object);
            deployRoverCommandObject.Initialize(mockPlateau.Object, roverList, command);

            Assert.AreEqual(command, deployRoverCommandObject.Command);
        }

        [Test]
        public void Execute_SetRoverObjectWithCorrectPosition_WhenInitializedWithCommand()
        {
            string command = "1 1 N";
            Dimension dimension = new Dimension();
            Plateau plateau = new Plateau(dimension);
            plateau.SetSize(5, 5);
            Rover rover = new Rover();
            Position position = new Position();
            List<IRover> deployedRovers = new List<IRover>();
            DeployRoverCommand deployRoverCommandObject = new DeployRoverCommand(rover, position);
            deployRoverCommandObject.Initialize(plateau, deployedRovers, command);
            deployRoverCommandObject.Execute();
             IPosition roverPosition = deployRoverCommandObject.GetRover().Position;
            string deployedRoverPosition = String.Format("{0} {1} {2}", roverPosition.X, roverPosition.Y, roverPosition.Direction.ToString()[0]);
            Assert.AreEqual(command, deployedRoverPosition);
        }

        [Test]
        [TestCase(5,5,"5 6 N")]
        [TestCase(5,5,"6 5 N")]
        public void Execute_ThrowsInvalidDeploymentException_WhenPositionNotInsidePlateau(int plateauSizeX, int plateauSizeY, string deployRoverCommand)
        {
            Dimension dimension = new Dimension();
            Plateau plateau = new Plateau(dimension);
            plateau.SetSize(5, 5);
            Rover rover = new Rover();
            Position position = new Position();
            List<IRover> deployedRovers = new List<IRover>();
            DeployRoverCommand deployRoverCommandObject = new DeployRoverCommand(rover, position);
            deployRoverCommandObject.Initialize(plateau, deployedRovers, deployRoverCommand);
            Assert.Catch<InvalidDeployment>(() => deployRoverCommandObject.Execute());
        }
    }
}
