using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.UnitTests.RoverTests
{
    public static class RoverHelpers
    {
        public static void AssertRoversAreSame(Rover a, Rover b)
        {
            Assert.AreEqual(a.X, b.X);
            Assert.AreEqual(a.Y, b.Y);
            Assert.AreEqual(a.Orientation, b.Orientation);
        }
    }
}
