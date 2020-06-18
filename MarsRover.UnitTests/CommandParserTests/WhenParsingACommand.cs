using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Domain;
using MarsRover.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.UnitTests.CommandParserTests
{
    [TestClass]
    public class WhenParsingACommand
    {
        [TestMethod]
        public void AndInputIsNullThrowException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => CommandParser.ParseCommand(null));
        }

        [TestMethod]
        [DataRow("invalid")]
        [DataRow("")]
        [DataRow("f ")]
        [DataRow("hi!!!!/8502")]
        public void AndInputIsNotNullAndNotValidReturnUnknownCommand(string input)
        {
            Assert.AreEqual(Command.Unknown, CommandParser.ParseCommand(input));
        }

        [TestMethod]
        [DataRow("f", Command.MoveForward)]
        [DataRow("F", Command.MoveForward)]
        [DataRow("b", Command.MoveBackward)]
        [DataRow("B", Command.MoveBackward)]
        [DataRow("l", Command.TurnLeft)]
        [DataRow("L", Command.TurnLeft)]
        [DataRow("r", Command.TurnRight)]
        [DataRow("R", Command.TurnRight)]
        [DataRow("q", Command.Quit)]
        [DataRow("Q", Command.Quit)]
        public void AndInputIsValidReturnCorrectCommand(string input, Command command)
        {
            Assert.AreEqual(command, CommandParser.ParseCommand(input));
        }
    }
}
