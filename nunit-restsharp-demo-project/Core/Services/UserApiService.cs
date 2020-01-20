using System;
using System.Reflection;
using NUnit.Allure.Steps;
using NUnit.Framework.Internal;
using nunit_restsharp_demo_project.Core.Assertions;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Newtonsoft.Json.Extensions;

namespace nunit_restsharp_demo_project.Core.Services
{
    public class UserApiService: ApiClient
    {

        public RestClient RestClient;
        public string BasePath;

        public UserApiService(string baseUrl)
        {
            RestClient = new RestClient(baseUrl);
            RestClient.UseNewtonsoftJsonDeserializer();
            BasePath = "users";
        }

        [AllureStep("GetUsers")]
        public AssertableResponse<T> GetUsers<T>()
        {
            var request = new RestRequest($"{BasePath}", Method.GET, DataFormat.Json);
            return new AssertableResponse<T>(ExecuteRequest<T>(RestClient, request));        
        }

        [AllureStep("GetUser")]
        public AssertableResponse<T> GetUser<T>(int id)
        {
            var request = new RestRequest($"{BasePath}/{id}", Method.GET, DataFormat.Json);
            return new AssertableResponse<T>(ExecuteRequest<T>(RestClient, request));
        }

       
    }
}