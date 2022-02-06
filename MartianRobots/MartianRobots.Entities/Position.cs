using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Entities
{
    public class Position
    {
        public Coordinate Coordinate { get; set; }
        public Orientation Orientation { get; set; }

        public Position(Coordinate coordinate, Orientation orientation)
        {
            Coordinate = coordinate;
            Orientation = orientation;
        }

        public Position executeInstruction(Instruction instruction, List<Coordinate> smells)
        {
            var initialPosition = Coordinate;
            switch (instruction)
            {
                case Instruction.Left:
                    return moveLeft();
                case Instruction.Right:
                    return moveRight();
                default:
                    return moveForward();
            }
        }

        private Position moveLeft()
        {
            switch (Orientation)
            {
                case Orientation.North:
                    return new Position(new Coordinate(Coordinate), Orientation.West);
                case Orientation.East:
                    return new Position(new Coordinate(Coordinate), Orientation.North);
                case Orientation.South:
                    return new Position(new Coordinate(Coordinate), Orientation.East);
                default:
                    return new Position(new Coordinate(Coordinate), Orientation.South);
            }
        }

        private Position moveRight()
        {
            switch (Orientation)
            {
                case Orientation.North:
                    return new Position(new Coordinate(Coordinate), Orientation.East);
                case Orientation.East:
                    return new Position(new Coordinate(Coordinate), Orientation.South);
                case Orientation.South:
                    return new Position(new Coordinate(Coordinate), Orientation.East);
                default:
                    return new Position(new Coordinate(Coordinate), Orientation.North);
            }
        }

        private Position moveForward()
        {
            switch (Orientation)
            {
                case Orientation.North:
                    return new Position(new Coordinate(Coordinate.X, Coordinate.Y++), Orientation);
                case Orientation.East:
                    return new Position(new Coordinate(Coordinate.X++, Coordinate.Y), Orientation);
                case Orientation.South:
                    return new Position(new Coordinate(Coordinate.X, Coordinate.Y--), Orientation);
                default:
                    return new Position(new Coordinate(Coordinate.X--, Coordinate.Y), Orientation);
            }
        }

        public string ResultString()
        {
            return $"{Coordinate.X} {Coordinate.Y} {Orientation.ResultString()}";
        }
    }
}
