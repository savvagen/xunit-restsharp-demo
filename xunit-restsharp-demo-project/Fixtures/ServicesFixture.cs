using System;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using xunit_restsharp_demo_project.Client;

namespace xunit_restsharp_demo_project.Fixtures
{
    public class ServicesFixture: IDisposable
    {
        public UserService UserService;
        public string BaseUrl = "http://localhost:3000";
        public RestClient Client;
        
        public ServicesFixture()
        {
            Client = new RestClient(BaseUrl);
            Client.UseNewtonsoftJson();
            UserService = new UserService(BaseUrl);
        }

        public void Dispose()
        {
            Console.WriteLine("cleanup2");
        }
    }
}