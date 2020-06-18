using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.UnitTests.RoverTests
{
    [TestClass]
    public class WhenRoverTurningLeft
    {
        [TestMethod]
        [DataRow(Direction.North, Direction.West, DisplayName="AndFacingNorthThenRoverFacesWest")]
        [DataRow(Direction.West, Direction.South, DisplayName = "AndFacingWestThenRoverFacesSouth")]
        [DataRow(Direction.South, Direction.East, DisplayName = "AndFacingSouthThenRoverFacesEast")]
        [DataRow(Direction.East, Direction.North, DisplayName = "AndFacingEastThenRoverFacesNorth")]
        public void ThenOrientationChangesButLocationIsTheSame(Direction startingDirection, Direction expectedDirection)
        {
            var rover = new Rover() { Orientation = startingDirection };
            var startingX = rover.X;
            var startingY = rover.Y;

            rover.TurnLeft();

            var expectedRover = new Rover { X = startingX, Y = startingY, Orientation = expectedDirection };
            RoverHelpers.AssertRoversAreSame(expectedRover, rover);
        }
    }
}
