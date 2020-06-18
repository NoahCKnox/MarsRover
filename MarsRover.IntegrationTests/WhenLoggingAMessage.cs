using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using MarsRover.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.IntegrationTests
{
    [TestClass]
    public class WhenLoggingAMessage
    {
        private Logger _logger;
        private string _path;
        private string _testMessage1 = "test message";
        private string _testMessage2 = "test message 2";

        [TestInitialize]
        public void TestInitialize()
        {
            var executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _path = executingDirectory + "\\logger.txt";
            _logger = new Logger(_path);
        }

        [TestMethod]
        public void AndMessageIsNullThenThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _logger.Log(null));
        }

        [TestMethod]
        public void ThenSameMessageIsInFile()
        {
            _logger.Log(_testMessage1);

            Assert.AreEqual(_testMessage1 + "\n", File.ReadAllText(_path));
        }

        [TestMethod]
        public void AndMultipleLogsOccurThenAllMessagesAreStoredInFile()
        {
            _logger.Log(_testMessage1);
            _logger.Log(_testMessage2);

            Assert.AreEqual(_testMessage1 + "\n" + _testMessage2 +"\n", File.ReadAllText(_path));
        }
    }
}
