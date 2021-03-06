namespace MartianRobots.Core.Entities
{
    public class ExploreResponse
    {
        public string Result { get; set; }
        public int ScoreResult { get; set; }
        public int PreviousTopScore { get; set; } 

        public ExploreResponse(string result, int scoreResult, int previousTopScore)
        {
            Result = result;
            ScoreResult = scoreResult;
            PreviousTopScore = previousTopScore;
        }
    }
}
