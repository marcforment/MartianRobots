using MartianRobots.Core.Entities;

namespace MartianRobots.Core
{
    public interface IExploreService
    {
        public string ExploreWorld(ExploreRequest exploreRequest);
    }
}
