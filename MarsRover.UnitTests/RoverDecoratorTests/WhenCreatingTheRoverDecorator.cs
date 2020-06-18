using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Domain;
using MarsRover.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MarsRover.UnitTests.RoverDecoratorTests
{
    [TestClass]
    public class WhenCreatingTheRoverDecorator
    {
        [TestMethod]
        public void AndTheLoggerIsNullThenExceptionIsThrown()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new RoverDecorator(new Rover(), null));
        }

        [TestMethod]
        public void AndTheRoverIsNullThenExceptionIsThrown()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new RoverDecorator(null, new Mock<ILogger>().Object));
        }
    }
}
