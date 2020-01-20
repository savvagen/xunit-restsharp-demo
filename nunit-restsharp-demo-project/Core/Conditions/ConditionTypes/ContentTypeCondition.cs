using FluentAssertions;
using RestSharp;

namespace nunit_restsharp_demo_project.Core.Conditions.ConditionTypes
{
    public class ContentTypeCondition: ICondition
    {
        private string ContentType;


        public ContentTypeCondition(string value)
        {
            ContentType = value;
        }


        public void check(IRestResponse response)
        {
            response.ContentType.Should().Be(ContentType);
        }

        public void uncheck(IRestResponse response)
        {
            response.ContentType.Should().NotBe(ContentType);
        }

        public override string ToString()
        {
            return "ContenType is " + ContentType;
        }
    }
}