using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Domain;

namespace MarsRover.Services
{
    public static class CommandParser
    {
        public static Command ParseCommand(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            switch (input.ToLower())
            {
                case "f":
                    return Command.MoveForward;
                case "b":
                    return Command.MoveBackward;
                case "l":
                    return Command.TurnLeft;
                case "r":
                    return Command.TurnRight;
                case "q":
                    return Command.Quit;
                default:
                    return Command.Unknown;
            }
        }
    }
}
