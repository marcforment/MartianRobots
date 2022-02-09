namespace MartianRobots.Web.Contract.V1
{
    public class ExploreResponseV1
    {
        public string Result { get; set; }
        public int ScoreResult { get; set; }
        public int PreviousTopScore { get; set; }

        public ExploreResponseV1(string result, int scoreResult, int previousTopScore)
        {
            Result = result;
            ScoreResult = scoreResult;
            PreviousTopScore = previousTopScore;
        }
    }
}
