using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Core.Entities
{
    public class ExploreRequest
    {
        public World World { get; set; }
        public List<Robot> Robots { get; set;}

        public ExploreRequest(World world, List<Robot> robots)
        {
            World = world;
            Robots = robots;
        }
    }
}
