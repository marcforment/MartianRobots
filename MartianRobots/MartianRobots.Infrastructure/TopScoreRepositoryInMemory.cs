using MartianRobots.Core;

namespace MartianRobots.Infrastructure
{
    public class TopScoreRepositoryInMemory : ITopScoreRepository
    {
        private List<int> scores { get; set; }
        public TopScoreRepositoryInMemory()
        {
            scores = new List<int>();
        }

        public void SaveScore(int value)
        {
            scores.Add(value);
        }

        public int GetTopScore()
        {
            if(scores.Count == 0)
            {
                return 0;
            }
            return scores.Max();
        }
    }
}
