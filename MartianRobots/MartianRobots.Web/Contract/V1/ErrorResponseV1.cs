namespace MartianRobots.Web.Contract.V1
{
    public class ErrorResponseV1
    {
        public string ErrorString { get; set; }

        public ErrorResponseV1(string errorString)
        {
            this.ErrorString = errorString;
        }
    }
}
