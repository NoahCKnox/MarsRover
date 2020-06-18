using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain
{
    public enum Command
    {
        MoveForward,
        MoveBackward,
        TurnLeft,
        TurnRight,
        Quit,
        Unknown
    };
}
