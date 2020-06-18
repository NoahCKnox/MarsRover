using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using MarsRover.Domain;
using MarsRover.Services;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Rover theRover = new Rover();

            var executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = executingDirectory + "\\logger.txt";
            ILogger theLogger = new Logger(path);

            RoverDecorator rover = new RoverDecorator(theRover, theLogger);

            Console.WriteLine("Hi, welcome to the Mars Rover!");
            Command command = Command.Unknown;
            do
            {
                Console.WriteLine("Please enter a valid command: Move (F)orward, Move (B)ackward, Turn (L)eft, Turn (R)ight, or (Q)uit.");
                string input = Console.ReadLine();
                command = CommandParser.ParseCommand(input);
                if (command == Command.Unknown)
                {
                    System.Console.WriteLine("Invalid command!");
                }
                else 
                {
                    rover.ProcessCommand(command);
                }
            } while (command != Command.Quit);

            Console.WriteLine($"Rover is at {theRover.X} , {theRover.Y} facing {theRover.Orientation}");
            Process.Start("notepad.exe", path);
        }
    }
}
