using System;
using System.Collections.Generic;

namespace RobotCleaner
{
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Dictionary<Tuple<int, int>, bool> CleanedCoordinates;

        public Robot(int x, int y)
        {
            X = x;
            Y = y;
            CleanedCoordinates = new Dictionary<Tuple<int, int>, bool>();
            MarkCoordinatesCleaned();
        }

        public string DisplayCleaned()
        {
            return "=> Cleaned: " + CleanedCoordinates.Count;
        }

        public void Clean(string cardinal, int steps)
        {
            CardinalDirectionEnum direction;
            if (Enum.TryParse(cardinal, out direction))
            {
                if (IsHorizontalCardinalDirection(direction))
                {
                    CleanHorizontal(direction, steps);
                }
                else
                {
                    CleanVertical(direction, steps);
                }
            }
        }

        public void CleanHorizontal(CardinalDirectionEnum direction, int steps)
        {
            for (var i = 1; i <= steps; i++)
            {
                X += GetCardinalDirectionValue(direction);
                MarkCoordinatesCleaned();
            }
        }

        public void CleanVertical(CardinalDirectionEnum direction, int steps)
        {
            for (var i = 1; i <= steps; i++)
            {
                Y += GetCardinalDirectionValue(direction);
                MarkCoordinatesCleaned();
            }
        }

        public void MarkCoordinatesCleaned()
        {
            var coordinates = new Tuple<int, int>(X, Y);
            if (!CleanedCoordinates.ContainsKey(coordinates))
            {
                CleanedCoordinates.Add(coordinates, true);
            }
        }

        public bool IsHorizontalCardinalDirection(CardinalDirectionEnum direction)
        {
            return direction == CardinalDirectionEnum.E || direction == CardinalDirectionEnum.W;
             
        }

        public int GetCardinalDirectionValue(CardinalDirectionEnum direction)
        {
            return (direction == CardinalDirectionEnum.E || direction == CardinalDirectionEnum.N) ? 1 : -1;
        }
    }
}
