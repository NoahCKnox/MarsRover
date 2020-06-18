namespace MarsRover.Domain
{
    public interface IRover
    {
        void MoveBackward();
        void MoveForward();
        void TurnLeft();
        void TurnRight();
    }
}