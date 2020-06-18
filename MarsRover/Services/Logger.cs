using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MarsRover.Services
{
    public class Logger : ILogger
    {
        private string _path;

        public Logger(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException(nameof(path) + " is empty");
            if (!Directory.Exists(Path.GetDirectoryName(path))) throw new ArgumentException(nameof(path) + " is an invalid directory");

            _path = path;
            File.WriteAllText(_path, "");
        }

        public void Log(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            File.AppendAllText(_path, message + "\n");
        }
    }
}
