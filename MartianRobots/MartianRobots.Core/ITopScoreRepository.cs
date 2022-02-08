namespace MartianRobots.Core
{
    public interface ITopScoreRepository
    {
        public int SaveScore(int value);
        public int GetTopScore();
    }
}
