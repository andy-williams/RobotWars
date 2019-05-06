using System;

namespace RobotWars
{
    public class Robot
    {
        private Coordinates _coordinates;
        private Direction _direction;
        private readonly Coordinates _upperBoundary;


        // 0,0 = bottom left
        // upperBoundary x, upperBoundary y = top right
        public Robot(Coordinates upperBoundary, Coordinates initialCoordinates, Direction initialDirection)
        {
            _coordinates = initialCoordinates;
            _direction = initialDirection;
            _upperBoundary = upperBoundary;
        }

        public Robot MoveForward()
        {
            Coordinates newCoordinates;
            if (_direction == Direction.North)
                newCoordinates = new Coordinates(_coordinates.X, _coordinates.Y + 1);

            else if (_direction == Direction.South)
                newCoordinates = new Coordinates(_coordinates.X, _coordinates.Y - 1);

            else if (_direction == Direction.East)
                newCoordinates = new Coordinates(_coordinates.X + 1, _coordinates.Y);

            else if (_direction == Direction.West)
                newCoordinates = new Coordinates(_coordinates.X - 1, _coordinates.Y);
            else
                throw new Exception("Unrecognised direction");

            AssertCoordinates(newCoordinates);
            _coordinates = newCoordinates;

            return this;
        }

        private void AssertCoordinates(Coordinates coordinates)
        {
            if (
                coordinates.X > _upperBoundary.X
                || coordinates.Y > _upperBoundary.Y
                || coordinates.X < 0
                || coordinates.Y < 0
            )
            {
                throw new Exception("Bot beyond boundary");
            }
        }

        public Robot ChangeDirection(DirectionalMove move)
        {
            if (_direction == Direction.North)
            {
                if (move == DirectionalMove.Left)
                    _direction = Direction.West;

                if (move == DirectionalMove.Right)
                    _direction = Direction.East;
            }
            else if (_direction == Direction.South)
            {
                if (move == DirectionalMove.Left)
                    _direction = Direction.East;

                if (move == DirectionalMove.Right)
                    _direction = Direction.West;
            }
            else if (_direction == Direction.East)
            {
                if (move == DirectionalMove.Left)
                    _direction = Direction.North;

                if (move == DirectionalMove.Right)
                    _direction = Direction.South;
            }
            else if (_direction == Direction.West)
            {
                if (move == DirectionalMove.Left)
                    _direction = Direction.South;

                if (move == DirectionalMove.Right)
                    _direction = Direction.North;
            }
            else
            {
                throw new Exception("Direction unknown");
            }

            return this;
        }


        public Coordinates GetCoordinates()
        {
            return _coordinates;
        }

        public Direction GetDirection()
        {
            return _direction;
        }
    }
}