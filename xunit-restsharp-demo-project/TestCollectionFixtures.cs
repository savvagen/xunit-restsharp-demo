using System;
using System.Net;
using System.Threading;
using RestSharp;
using Xunit;

namespace xunit_restsharp_demo_project
{
    
    
    
    
    public class ApiFixture: IDisposable
    {
        public RestClient RestClient { get; private set; }

        public ApiFixture()
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
    
    
    [CollectionDefinition("Client collection")]
    public class TestCollectionFixtures: IClassFixture<ApiFixture>
    {
        
    }
    
    
    
    
    [Collection("Client collection")]
    public class ApiTests1
    {
        private ApiFixture f;

        public ApiTests1(ApiFixture f)
        {
            this.f = f;
        }
        
        [Fact]
        public void ShouldTestApiClient1()
        {
            var resp = f.RestClient.Execute(new RestRequest("/users/1", Method.GET, DataFormat.Json));
            Thread.Sleep(3000);
            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        }
    }
    
    

    [Collection("Client collection")]
    public class ApiTests2
    {
        private ApiFixture f;

        public ApiTests2(ApiFixture f)
        {
            this.f = f;
        }
        
        [Fact]
        public void ShouldTestApiClient2()
        {
            var resp = f.RestClient.Execute(new RestRequest("/users/1", Method.GET, DataFormat.Json));
            Thread.Sleep(3000);
            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        }
    }
}