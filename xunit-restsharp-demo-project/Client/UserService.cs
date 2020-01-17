using RestSharp;

namespace xunit_restsharp_demo_project.Client
{
    public class UserService
    {
        private ApiClient Client;

        public UserService(string baseUrl)
        {
            Client = new ApiClient(baseUrl);
        }


        public IRestResponse GetUser(int id)
        {
            var getUser = new RestRequest($"/users/{id}", Method.GET, DataFormat.Json);
            return Client.RestClient.Get(getUser);
        }

    }
}