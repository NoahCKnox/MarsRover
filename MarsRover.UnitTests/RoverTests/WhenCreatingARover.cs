using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.UnitTests.RoverTests
{
    // Given/When/Then
    /*
        Given -> Context for the test
        When -> A scenario
        Then -> Expected Behavior
        Inspiration can be found at -> http://blog.thesoftwarementor.com/mars-rover-intro-to-testing/ 

        All good tests have 3 parts
        AAA

        Arrange -> Set up all of your dependencies, setting up initial state
        Act -> What are we testing? This calling the method, property, or constructor
        Assert -> Did we get what we expected?

        TDD
        Red -> Write a failing unit test
        Green -> Write enough code to make it pass
        Refactor -> Simplify/clean-up code
        Commit -> Commit changes
    */
    [TestClass]
    public class WhenCreatingARover
    {
        [TestMethod]
        public void ThenTheRoverIsAt00()
        {
            var rover = new Rover();

            Assert.AreEqual(0, rover.X);
            Assert.AreEqual(0, rover.Y);
        }

        [TestMethod]
        public void ThenTheRoverIsFacingNorth()
        {
            var rover = new Rover();

            Assert.AreEqual(Direction.North, rover.Orientation);
        }
    }
}
