using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain
{


    public class Rover : IRover
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Direction Orientation { get; set; }

        public Rover()
        {
            X = 0;
            Y = 0;
            Orientation = Direction.North;
        }

        public void MoveForward()
        {
            Action ifNorth = () => Y += 1;
            Action ifEast = () => X += 1;
            Action ifWest = () => X -= 1;
            Action ifSouth = () => Y -= 1;

            Move(ifNorth, ifSouth, ifEast, ifWest);
        }

        public void MoveBackward()
        {
            Action ifNorth = () => Y -= 1;
            Action ifEast = () => X -= 1;
            Action ifWest = () => X += 1;
            Action ifSouth = () => Y += 1;

            Move(ifNorth, ifSouth, ifEast, ifWest);
        }

        public void TurnLeft()
        {
            Action ifNorth = () => Orientation = Direction.West;
            Action ifEast = () => Orientation = Direction.North;
            Action ifWest = () => Orientation = Direction.South;
            Action ifSouth = () => Orientation = Direction.East;

            Move(ifNorth, ifSouth, ifEast, ifWest);
        }

        public void TurnRight()
        {
            Action ifNorth = () => Orientation = Direction.East;
            Action ifEast = () => Orientation = Direction.South;
            Action ifWest = () => Orientation = Direction.North;
            Action ifSouth = () => Orientation = Direction.West;

            Move(ifNorth, ifSouth, ifEast, ifWest);
        }

        private void Move(Action ifNorth, Action ifSouth, Action ifEast, Action ifWest)
        {
            // Action -> no parameters, has no output
            switch (Orientation)
            {
                case Direction.North:
                    ifNorth();
                    break;
                case Direction.East:
                    ifEast();
                    break;
                case Direction.South:
                    ifSouth();
                    break;
                case Direction.West:
                    ifWest();
                    break;
            }
        }
    }
}