using MartianRobots.Web.Contract.V1;
using NUnit.Framework;

namespace MartianRobots.Tests
{
    public class ContractTests
    {
        [Test]
        public void SampleTransalationOK()
        {
            var requestV1 = new ExploreRequestV1("5 3\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL");
            var (exploreRequest, error) = TranslatorV1.TranslateToCoreRequest(requestV1);
            Assert.IsNotNull(exploreRequest);
        }
    }
}
