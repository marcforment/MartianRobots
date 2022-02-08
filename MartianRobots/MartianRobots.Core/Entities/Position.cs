namespace MartianRobots.Core.Entities
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

        public Position executeInstruction(Instruction instruction)
        {
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
                    return new Position(new Coordinate(Coordinate), Orientation.West);
                default:
                    return new Position(new Coordinate(Coordinate), Orientation.North);
            }
        }

        private Position moveForward()
        {
            switch (Orientation)
            {
                case Orientation.North:
                    return new Position(new Coordinate(Coordinate.X, Coordinate.Y+1), Orientation);
                case Orientation.East:
                    return new Position(new Coordinate(Coordinate.X+1, Coordinate.Y), Orientation);
                case Orientation.South:
                    return new Position(new Coordinate(Coordinate.X, Coordinate.Y-1), Orientation);
                default:
                    return new Position(new Coordinate(Coordinate.X-1, Coordinate.Y), Orientation);
            }
        }

        public string ResultString()
        {
            return $"{Coordinate.X} {Coordinate.Y} {Orientation.ResultString()}";
        }

        public int ScoreEntry()
        {
            return (this.Coordinate.X * 10) + this.Coordinate.Y;
        }
    }
}
