using Newtonsoft.Json.Linq;
using nunit_restsharp_demo_project.Test.RestSharp;
using RestSharp;
using RestSharp.Serialization;
using xunit_restsharp_demo_project.Models;

namespace nunit_restsharp_demo_project.Services
{
    public class UserService: Requests
    {
        public RestClient Client;
        public string basePath;

        public UserService(RestClient client)
        {
            Client = client;
            basePath = "/users";
            Client.AddDefaultHeader("Content-Type", ContentType.Json);
        }

        public IRestResponse<T> GetUser<T>(int id)
        {
            var r = new RestRequest($"{basePath}/{id}", Method.GET, DataFormat.Json);
            return ExecuteRequest<T>(Client, r);
        }

        public IRestResponse<T> CreateUser<T>(User user)
        {
            var r = new RestRequest("/users", Method.POST, DataFormat.Json).AddBody(user);
            return ExecuteRequest<T>(Client, r);
        }


    }
}