using MartianRobots.Web.Contract.V1;
using NUnit.Framework;

namespace MartianRobots.Tests
{
    public class ContractTests
    {
        [Test]
        public void TransalationOK()
        {
            var requestV1 = new ExploreRequestV1("5 3\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL");
            var (exploreRequest, error) = TranslatorV1.TranslateToCoreRequest(requestV1);
            Assert.IsNotNull(exploreRequest);
        }

        [Test]
        public void TranslationErrors()
        {
            StringErrorTest("", "Input field cannot be empty.");
            StringErrorTest(null, "Input field cannot be empty.");
            StringErrorTest("1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL", "Incorrect number of lines. Input needs to contain at least a line with world bonduary definition and two lines with a robot definition.");
            StringErrorTest("5 3\r\n6 3 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL", "Robot position 6 3 needs to be inside bonduary 5 3.");
            StringErrorTest("5 3\r\n1 1 E\r\nRFRFRFRF\r\nZ K N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL", "There was a problem parsing cooordinates: Z K.");
            StringErrorTest("5 3\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n-1 -1 W\r\nLLFFFRFLFL", "Coordinates: -1 -1 need to be positive and less than or equal than 50.");
            StringErrorTest("60 3\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL", "Coordinates: 60 3 need to be positive and less than or equal than 50.");
            StringErrorTest("5 3\r\n1 1 E\r\nRFRFRFRFFRFRFRFRFFRFRFRFRFFRFRFRFRFFRFRFRFRFFRFRFRFRFFRFRFRFRFFRFRFRFRFFRFRFRFRFFFRFRFRFRFFRFRFRFRFF\r\n3 2 N\r\nF\r\n0 3 W\r\nL", "Instruction strings need to be less than 100 characters in length.");
        }
        
        private void StringErrorTest(string badRequest, string expectedError)
        {
            var requestV1 = new ExploreRequestV1(badRequest);
            var (exploreRequest, error) = TranslatorV1.TranslateToCoreRequest(requestV1);
            Assert.IsNull(exploreRequest);
            Assert.AreEqual(expectedError, error);
        }
    }
}
