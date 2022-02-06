namespace MartianRobots.Core.Entities
{
    public class World
    {
        public Coordinate Edge { get; set; }
        public List<Coordinate> Smells { get; set; }

        public World(Coordinate edge)
        {
            Edge = edge;
            Smells = new List<Coordinate>();
        }

        public bool IsOutside(Position position)
        {
            return position.Coordinate.X > Edge.X || position.Coordinate.Y > Edge.Y;
        }
    }
}
