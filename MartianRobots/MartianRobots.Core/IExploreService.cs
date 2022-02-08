using MartianRobots.Core.Entities;

namespace MartianRobots.Core
{
    public interface IExploreService
    {
        public ExploreResponse ExploreWorld(ExploreRequest exploreRequest);
    }
}
