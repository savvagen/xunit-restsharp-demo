using System;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace xunit_restsharp_demo_project.Client
{
    public class ApiClient
    {

        public string BaseUrl;
        public RestClient RestClient;

        public ApiClient(string baseUrl)
        {
            BaseUrl = baseUrl;
            RestClient = new RestClient(baseUrl);
            RestClient.UseNewtonsoftJson();
            RestClient.AddDefaultHeader("Content-Type", "application/json; charset=utf-8");
        }
    }
    
    
    
}

