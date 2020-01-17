using System;
using System.Net;
using RestSharp;
using Xunit;

namespace xunit_restsharp_demo_project
{
    public class TestFixture: IDisposable
    {
        public RestClient RestClient { get; private set; }

        public TestFixture()
        {
            RestClient = new RestClient("http://localhost:3000");
            // ... initialize api client ...
            Console.WriteLine("Tests Started.");
        }

        public void Dispose()
        {
            // ... clean up test data ...
            Console.WriteLine("Tests Finished.");
        }
    }


    public class ApiTests: IClassFixture<TestFixture>
    {
        private TestFixture fixture;

        public ApiTests(TestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void ShouldTestApiClient()
        {
            var resp = fixture.RestClient.Execute(new RestRequest("/users/1", Method.GET, DataFormat.Json));
            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        }
            
    }
}