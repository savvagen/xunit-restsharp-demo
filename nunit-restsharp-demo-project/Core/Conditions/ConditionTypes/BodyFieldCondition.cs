using FluentAssertions;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace nunit_restsharp_demo_project.Core.Conditions.ConditionTypes
{
    public class BodyFieldCondition: ICondition
    {
        private string JsonPath;
        private string FieldValue;


        public BodyFieldCondition(string jsonPath, string value)
        {
            JsonPath = jsonPath;
            FieldValue = value;
        }

        public void check(IRestResponse response)
        {
            var jsonObject = JObject.Parse(response.Content);
            jsonObject.SelectToken(JsonPath).ToString().Should().Be(FieldValue);
        }

        public void uncheck(IRestResponse response)
        {
            var jsonObject = JObject.Parse(response.Content);
            jsonObject.SelectToken(JsonPath).ToString().Should().NotBe(FieldValue);
        }

        public override string ToString()
        {
            return $"Field {JsonPath} is: " + FieldValue;
        }
    }
}