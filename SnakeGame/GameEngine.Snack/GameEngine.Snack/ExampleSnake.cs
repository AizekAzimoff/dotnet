using PixelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Snack
{
    public class ExampleSnake : ISnake
    {
        private const int _width = 50;
        private const int _wallDistanceThreshold = 5;
        private Point _myHeadPosition;

        public string Name => "Aziz";

        public SnakeDirection GetNextDirection(SnakeDirection currentDirection)
        {

            if(currentDirection == SnakeDirection.Up 
                && _myHeadPosition.Y < _wallDistanceThreshold)
            {
                return SnakeDirection.Left;
            }

            if(currentDirection == SnakeDirection.Right
                && _myHeadPosition.X > _width - _wallDistanceThreshold)
            {
                return SnakeDirection.Up;
            }

            if(currentDirection == SnakeDirection.Down
                && _myHeadPosition.Y > _width - _wallDistanceThreshold)
            {
                return SnakeDirection.Right;
            }

            if (currentDirection == SnakeDirection.Left
                && _myHeadPosition.X <  _wallDistanceThreshold)
            {
                return SnakeDirection.Down;
            }

            Tuple<int, int> foodCoord = SnakeGame.getFoodCoord();
            int foodX = foodCoord.Item1;
            int foodY = foodCoord.Item2;

            if (currentDirection == SnakeDirection.Up
                && _myHeadPosition.Y == foodY && _myHeadPosition.X < foodX)
            {
                return SnakeDirection.Right;
            }
            else if (currentDirection == SnakeDirection.Up
   && _myHeadPosition.Y == foodY && _myHeadPosition.X > foodX)
            {
                return SnakeDirection.Left;
            }

            else if (currentDirection == SnakeDirection.Right
                 && _myHeadPosition.X == foodX && _myHeadPosition.Y > foodY)
            {
                return SnakeDirection.Up;
            }
            else if (currentDirection == SnakeDirection.Right
    && _myHeadPosition.X == foodX && _myHeadPosition.Y < foodY)
            {
                return SnakeDirection.Down;
            }
            else if (currentDirection == SnakeDirection.Left
                 && _myHeadPosition.X == foodX && _myHeadPosition.Y < foodY)
            {
                return SnakeDirection.Down;
            }
            else if (currentDirection == SnakeDirection.Left
                 && _myHeadPosition.X == foodX && _myHeadPosition.Y > foodY)
            {
                return SnakeDirection.Up;
            }
            else if (currentDirection == SnakeDirection.Down
                && _myHeadPosition.Y == foodY && _myHeadPosition.X < foodX)
            {
                return SnakeDirection.Right;
            }
            else if (currentDirection == SnakeDirection.Down
   && _myHeadPosition.Y == foodY && _myHeadPosition.X > foodX)
            {
                return SnakeDirection.Left;
            }
            return currentDirection;
        }

        public void UpdateMap(string map)
        {
            _myHeadPosition = getMyHeadPosition(map);
        }

        private Point getMyHeadPosition(string map)
        {
            var headIndex = map.IndexOf('*');
            return new Point(headIndex % _width, headIndex / _width);
        }
    }
}
