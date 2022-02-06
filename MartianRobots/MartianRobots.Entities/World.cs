using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Entities
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

        public bool isOutside(Position position)
        {
            return position.Coordinate.X > Edge.X || position.Coordinate.Y > Edge.Y;
        }
    }
}
