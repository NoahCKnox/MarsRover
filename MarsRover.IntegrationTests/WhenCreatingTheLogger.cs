using System;
using System.IO;
using System.Reflection;
using MarsRover.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.IntegrationTests
{
    // Dependency Injection
    /*
    - D part of SOLID 
    - Instead of creating our dependencies internally, they're passed in
    - Constructor Level
        - Great for dependencies that do not change while the object exists
        - If the dependency isn't "valid", can throw an exception
    - Method Level
        - Great for dependencies that can change
        - If the dependency isn't "valid", can throw an exception
    - Property Level
        - Great for dependencies that need to be changed "some of the time"
        - Can't force it to be set
    */

    // Dependencies
    // Path of the file (directory and name) C:\users\cpresley\file.txt (Constructor)
    // Message to log (string) (Method)
    // 
    [TestClass]
    public class WhenCreatingTheLogger
    {
        [TestMethod]
        public void AndThePathIsNullThenAnExceptionIsThrown()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Logger(null));
        }

        [TestMethod]
        public void AndThePathIsEmptyThenAnExceptionIsThrown()
        {
            Assert.ThrowsException<ArgumentException>(() => new Logger(string.Empty));
        }

        [TestMethod]
        public void AndThePathDoesntExistThenAnExceptionIsThrown()
        {
            var executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var nonExistentDirectory = executingDirectory + "\\doesntExist\\";
            if(Directory.Exists(nonExistentDirectory)) Directory.Delete(nonExistentDirectory);
            
            var path = nonExistentDirectory+"\\file.txt";

            Assert.ThrowsException<ArgumentException>(() => new Logger(path));
        }

        [TestMethod]
        public void AndThePathExistsAndFileDoesntThenAFileShouldBeCreated()
        {
            var executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = executingDirectory + "\\logger.txt";
            if (File.Exists(path)) File.Delete(path);

            Logger logger = new Logger(path);

            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]
        public void AndThePathExistsAndFileAlreadyExistsThenFileShouldBeDeletedAndReplacedWithEmptyFile()
        {
            var executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = executingDirectory + "\\logger.txt";
            if (File.Exists(path)) File.Delete(path);
            File.WriteAllText(path, "Test Message");

            Logger logger = new Logger(path);

            Assert.IsTrue(File.Exists(path));
            Assert.AreEqual("",File.ReadAllText(path));
        }
    }
}
