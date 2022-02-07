namespace MartianRobots.Web.Contract.V1
{
    public class ExploreRequestV1
    {
        public string Input { get; set; }

        public ExploreRequestV1(string input)
        {
            Input = input;
        }
    }
}
