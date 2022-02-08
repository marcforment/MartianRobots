namespace MartianRobots.Core.Entities
{
    public class ExploreResponse
    {
        public string Result { get; set; }
        public string ScoreResult { get; set; }

        public ExploreResponse(string result, string scoreResult)
        {
            Result = result;
            ScoreResult = scoreResult;
        }

    }
}
