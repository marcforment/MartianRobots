using MartianRobots.Core;
using MartianRobots.Infrastructure;
using NUnit.Framework;

namespace MartianRobots.Tests.Integration
{
    public class TopScoreInmemoryRepositoryTests
    {
        [Test]
        public void TopChanges()
        {
            var repository = IntitializeRepository();

            repository.SaveScore(1);
            repository.SaveScore(2);
            var newTop = repository.GetTopScore();

            Assert.AreEqual(2, newTop);
        }

        private ITopScoreRepository IntitializeRepository() 
        {
            return new TopScoreRepositoryInMemory();
        }
    }
}
