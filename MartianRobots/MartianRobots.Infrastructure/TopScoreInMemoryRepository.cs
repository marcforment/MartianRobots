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

        public void SaveScore(int value)
        {
            scores.Add(value);
        }

        public int GetTopScore()
        {
            return scores.Max();
        }
    }
}
