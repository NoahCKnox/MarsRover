using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.UnitTests.RoverTests
{
    [TestClass]
    public class WhenRoverTurningRight
    {
        [TestMethod]
        [DataRow(Direction.North, Direction.East, DisplayName = "AndFacingNorthThenRoverFacesEast")]
        [DataRow(Direction.East, Direction.South, DisplayName = "AndFacingEastThenRoverFacesSouth")]
        [DataRow(Direction.South, Direction.West, DisplayName = "AndFacingSouthThenRoverFacesWest")]
        [DataRow(Direction.West, Direction.North, DisplayName = "AndFacingWestThenRoverFacesNorth")]
        public void ThenOrientationChangesButLocationIsTheSame(Direction startingDirection, Direction expectedDirection)
        {
            var rover = new Rover() { Orientation = startingDirection };
            var startingX = rover.X;
            var startingY = rover.Y;

            rover.TurnRight();

            var expectedRover = new Rover { X = startingX, Y = startingY, Orientation = expectedDirection };
            RoverHelpers.AssertRoversAreSame(expectedRover, rover);
        }
    }
}
