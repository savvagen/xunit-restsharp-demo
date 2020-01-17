using System;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using xunit_restsharp_demo_project.Client;

namespace xunit_restsharp_demo_project.Fixtures
{
    public class TestBaseFixture: IDisposable
    {
        public const String baseUrl = "http://localhost:3000";
        public RestClient Client;

        public TestBaseFixture()
        {
            Client = new RestClient(baseUrl);
            Client.UseNewtonsoftJson();
        }

        public void Dispose()
        {
            Console.WriteLine("cleanup1");
        }
    }
}