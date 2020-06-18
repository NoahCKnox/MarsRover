using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.UnitTests.RoverTests
{
    [TestClass]
    public class WhenRoverMovingForward
    {
        [TestMethod]
        public void AndFacingNorthThenYUp1()
        {
            var rover = new Rover();
            var startingX = rover.X;
            var startingY = rover.Y;

            rover.MoveForward();
          
            var expectedRover = new Rover { X = startingX, Y = startingY + 1, Orientation = Direction.North };
            RoverHelpers.AssertRoversAreSame(expectedRover, rover);
        }

        [TestMethod]
        public void AndFacingSouthThenYDown1()
        {
            var rover = new Rover() { Orientation = Direction.South };
            var startingX = rover.X;
            var startingY = rover.Y;

            rover.MoveForward();

            var expectedRover = new Rover { X = startingX, Y = startingY - 1, Orientation = Direction.South };
            RoverHelpers.AssertRoversAreSame(expectedRover, rover);
        }

        [TestMethod]
        public void AndFacingWestThenXDown1()
        {
            var rover = new Rover() { Orientation = Direction.West };
            var startingX = rover.X;
            var startingY = rover.Y;

            rover.MoveForward();


            var expectedRover = new Rover { X = startingX - 1, Y = startingY, Orientation = Direction.West };
            RoverHelpers.AssertRoversAreSame(expectedRover, rover);
        }

        [TestMethod]
        public void AndFacingEastThenXUp1()
        {
            var rover = new Rover() { Orientation = Direction.East };
            var startingX = rover.X;
            var startingY = rover.Y;

            rover.MoveForward();

            var expectedRover = new Rover { X = startingX + 1, Y = startingY, Orientation = Direction.East };
            RoverHelpers.AssertRoversAreSame(expectedRover, rover);
        }
    }
}
