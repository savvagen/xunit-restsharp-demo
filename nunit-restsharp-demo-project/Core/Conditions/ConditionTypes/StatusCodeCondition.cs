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

        public override string ToString()
        {
            return "Status code " + StatusCode;
        }
    }
}