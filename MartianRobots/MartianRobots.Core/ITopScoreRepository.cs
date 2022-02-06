namespace MartianRobots.Core
{
    public interface ITopScoreRepository
    {
        public void SaveScore(int value);
        public int GetTopScore();
    }
}
