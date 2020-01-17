using System;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using xunit_restsharp_demo_project.Client;
using xunit_restsharp_demo_project.Models;

namespace xunit_restsharp_demo_project
{
    public class TestBase
    {
        public const String baseUrl = "http://localhost:3000";
        public RestClient _client;
        public UserService UserService;

        public TestBase()
        {
            _client = new RestClient(baseUrl);
            _client.UseNewtonsoftJson();
            
            UserService = new UserService(baseUrl);
        }
    }
}