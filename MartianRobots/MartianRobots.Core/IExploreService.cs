using MartianRobots.Core.Entities;

namespace MartianRobots.Core
{
    public interface IExploreService
    {
        public string ExploreWorld(World world, List<Robot> robots);
    }
}
