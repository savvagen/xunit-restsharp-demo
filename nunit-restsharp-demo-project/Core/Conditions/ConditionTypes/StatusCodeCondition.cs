using FluentAssertions;
using RestSharp;

namespace nunit_restsharp_demo_project.Core.Conditions.ConditionTypes
{
    public class StatusCodeCondition: ICondition
    {

        private int StatusCode;

        public StatusCodeCondition(int statusCode)
        {
            StatusCode = statusCode;
        }


        public void check(IRestResponse response)
        {
            response.StatusCode.Should().Be(StatusCode);
        }

        public void uncheck(IRestResponse response)
        {
            response.StatusCode.Should().NotBe(StatusCode);
        }

        public override string ToString()
        {
            return "Status code " + StatusCode;
        }
    }
}