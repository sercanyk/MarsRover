using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Engine.Command;
using NUnit.Framework;
using Moq;
using MarsRover.Engine.Plateau;

namespace MarsRover.Tests.Command
{
    [TestFixture]
    public class SetPlateauCommandTests
    {
        [Test]
        public void ExposesCorrectCommandType()
        {
            var mockPlateau = new Mock<IPlateau>();
            SetPlateauCommand setPlateauCommand = new SetPlateauCommand(mockPlateau.Object);
            CommandType commandType = setPlateauCommand.CommandType;
            Assert.AreEqual(CommandType.SetPlateau, commandType);
        }

        [Test]
        public void Initialize_ExposesCommand_WhenCalledWithCommand()
        {
            var mockPlateau = new Mock<IPlateau>();
            SetPlateauCommand setPlateauCommand = new SetPlateauCommand(mockPlateau.Object);
            string command = "9 15";
            setPlateauCommand.Initialize(command);
            Assert.AreEqual(command, setPlateauCommand.Command);
        }

        [Test]
        public void Execute_SetsPlateauObjectWithCorrectSize_WhenInitializedWithCommand()
        {
            string command = "9 15";
            Dimension dimension = new Dimension();
            Plateau plateau = new Plateau(dimension);
            SetPlateauCommand setPlateauCommand = new SetPlateauCommand(plateau);
            setPlateauCommand.Initialize(command);
            setPlateauCommand.Execute();
            string size = String.Format("{0} {1}", plateau.GetSize().Width, plateau.GetSize().Height);
            Assert.AreEqual(command, size);
        }
    }
}
