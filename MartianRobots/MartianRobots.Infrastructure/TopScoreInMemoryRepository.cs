using MartianRobots.Core;

namespace MartianRobots.Infrastructure
{
    public class TopScoreInMemoryRepository : ITopScoreRepository
    {
        private List<int> scores { get; set; }
        public TopScoreInMemoryRepository()
        {
            scores = new List<int>();
        }

        public int SaveScore(int value)
        {
            scores.Add(value);
            return value;
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
