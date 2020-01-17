using System;
using NUnit.Framework;
using nunit_restsharp_demo_project.Services;
using RestSharp;
using RestSharp.Newtonsoft.Json.Extensions;

namespace nunit_restsharp_demo_project.Test.RestSharp
{
    [TestFixture]
    public class BaseTest: Requests
    {

        public RestClient Client;
        public UserService UserService;
        
        public BaseTest()
        {
            Client = new RestClient("http://localhost:3000");
            Client.UseNewtonsoftJsonDeserializer();
            UserService = new UserService(Client);
        }

        [OneTimeSetUp]
        public void Setup()
        {
            Console.WriteLine("tests started.");
        }
        
        
        [OneTimeTearDown]
        public void TearDown()
        {
            Console.WriteLine("tests finished.");
        }
    }
    
    
    
    
}