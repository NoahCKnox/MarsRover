using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Domain;
using MarsRover.Services;
using MarsRover.UnitTests.RoverTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MarsRover.UnitTests.RoverDecoratorTests
{
    [TestClass]
    public class WhenProcessingACommand
    {
        private const string forwardMessage = "Rover moved forward!";
        private const string backwardMessage = "Rover moved backward!";
        private const string leftMessage = "Rover turned left!";
        private const string rightMessage = "Rover turned right!";
        private const string quitMessage = "Rover stopped receiving instructions.";
        private const string unknownMessage = "Unknown command requested.";
        private Mock<IRover> _rover;
        private Mock<ILogger> _logger;
        private RoverDecorator _decorator;

        [TestInitialize]
        public void TestInitialize()
        {
            _rover = new Mock<IRover>();
            _logger = new Mock<ILogger>();
            _decorator = new RoverDecorator(_rover.Object, _logger.Object);
        }

        [TestMethod]
        public void AndTheCommandIsMoveForwardThenRoverMovedForward()
        {
            _decorator.ProcessCommand(Command.MoveForward);

            _rover.Verify(x => x.MoveForward(), Times.Once());
        }

        [TestMethod]
        public void AndTheCommandIsMoveBackwardThenRoverMovedBackward()
        {
            _decorator.ProcessCommand(Command.MoveBackward);

            _rover.Verify(x => x.MoveBackward(), Times.Once());
        }

        [TestMethod]
        public void AndTheCommandIsTurnLeftThenRoverTurnedLeft()
        {
            _decorator.ProcessCommand(Command.TurnLeft);

            _rover.Verify(x => x.TurnLeft(), Times.Once());
        }

        [TestMethod]
        public void AndTheCommandIsTurnRightThenRoverTurnedRight()
        {
            _decorator.ProcessCommand(Command.TurnRight);

            _rover.Verify(x => x.TurnRight(), Times.Once());
        }

        [TestMethod]
        [DataRow(Command.MoveForward, forwardMessage, DisplayName ="AndTheCommandIsMoveForwardThenTheCorrectMessageIsLogged")]
        [DataRow(Command.MoveBackward, backwardMessage, DisplayName = "AndTheCommandIsMoveBackwardThenTheCorrectMessageIsLogged")]
        [DataRow(Command.TurnLeft, leftMessage, DisplayName = "AndTheCommandIsTurnLeftThenTheCorrectMessageIsLogged")]
        [DataRow(Command.TurnRight, rightMessage, DisplayName = "AndTheCommandIsTurnRightThenTheCorrectMessageIsLogged")]
        [DataRow(Command.Quit, quitMessage, DisplayName = "AndTheCommandIsQuitThenTheCorrectMessageIsLogged")]
        [DataRow(Command.Unknown, unknownMessage, DisplayName = "AndTheCommandIsUnkownThenTheCorrectMessageIsLogged")]
        public void AndTheCommandIsValidThenTheCorrectMessageIsLogged(Command command, string message)
        {
            _decorator.ProcessCommand(command);

            _logger.Verify(x => x.Log(message), Times.Once());
        }

    }
}
