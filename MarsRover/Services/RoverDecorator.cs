using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Domain;

namespace MarsRover.Services
{
    public class RoverDecorator
    {
        private readonly IRover _rover;
        private readonly ILogger _logger;

        /*
- Constructor will take in a Rover and a Logger
- Method, ProcessCommand -> command -> void
*/

        public RoverDecorator(IRover rover, ILogger logger)
        {
            if (rover is null) throw new ArgumentNullException(nameof(rover));
            if (logger is null) throw new ArgumentNullException(nameof(logger));
            _rover = rover;
            _logger = logger;
        }

        public void ProcessCommand(Command command)
        {
            switch(command)
            {
                case Command.MoveForward:
                    _rover.MoveForward();
                    _logger.Log("Rover moved forward!");
                    break;
                case Command.MoveBackward:
                    _rover.MoveBackward();
                    _logger.Log("Rover moved backward!");
                    break;
                case Command.TurnLeft:
                    _rover.TurnLeft();
                    _logger.Log("Rover turned left!");
                    break;
                case Command.TurnRight:
                    _rover.TurnRight();
                    _logger.Log("Rover turned right!");
                    break;
                case Command.Quit:
                    _logger.Log("Rover stopped receiving instructions.");
                    break;
                case Command.Unknown:
                    _logger.Log("Unknown command requested.");
                    break;
            }
                
        }
    }
}
