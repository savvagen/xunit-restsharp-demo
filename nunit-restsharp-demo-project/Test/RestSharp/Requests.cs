using System;
using System.Threading.Tasks;
using RestSharp;

namespace nunit_restsharp_demo_project.Test.RestSharp
{
    public class Requests
    {
        
        public async Task<IRestResponse<T>> ExecuteAsyncRequest<T>(RestClient client, IRestRequest request) where T : new()
        {
            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();
            client.ExecuteAsync<T>(request, testResponse => {
                if (testResponse.ErrorException != null)
                {
                    const string message = "Error retreving response.";
                    throw new ApplicationException(message, testResponse.ErrorException);
                }
                if (testResponse.IsSuccessful)
                {
                    Console.WriteLine("Success!!!!");
                }
                taskCompletionSource.SetResult(testResponse);
            });

            return await taskCompletionSource.Task;
        }

        public async Task<IRestResponse> ExecuteAsyncRequest(RestClient client, IRestRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, testResponse => {
                if (testResponse.ErrorException != null)
                {
                    const string message = "Error retreving response.";
                    throw new ApplicationException(message, testResponse.ErrorException);
                }
                if (testResponse.IsSuccessful)
                {
                    Console.WriteLine("Sucesss!!!!");
                }
                taskCompletionSource.SetResult(testResponse);
            });
            return await taskCompletionSource.Task;
        }
        
        public IRestResponse<T> ExecuteRequest<T>(RestClient client, IRestRequest request)
        {
            Console.WriteLine("Request:");
            Console.WriteLine(request.Method);
            Console.WriteLine(client.BaseUrl + request.Resource);
            Console.WriteLine("-----");
            
            var resp = client.Execute<T>(request);
            if (resp.ErrorException != null)
            {
                const string message = "Error retreving response.";
                throw new ApplicationException(message + $"\n{resp.Content}", resp.ErrorException);
            }
            if (resp.IsSuccessful)
            {
                Console.WriteLine("Response:");
                Console.WriteLine(resp.StatusCode);
                Console.WriteLine(resp.Content);
            }
            return resp;
            
        }


        public IRestResponse ExecuteRequest(RestClient client, IRestRequest request)
        {
            Console.WriteLine("Request:");
            Console.WriteLine(request.Method);
            Console.WriteLine(client.BaseUrl + request.Resource);
            Console.WriteLine("-----");
            
            var taskCompletionSource = new TaskCompletionSource<IRestResponse>();
            var resp = client.Execute(request);
            if (resp.ErrorException != null)
            {
                const string message = "Error retreving response.";
                throw new ApplicationException(message + $"\n{resp.Content}", resp.ErrorException);
            }
            if (resp.IsSuccessful)
            {
                Console.WriteLine("Response:");
                Console.WriteLine(resp.StatusCode);
                Console.WriteLine(resp.Content);
            }
            taskCompletionSource.SetResult(resp);
            return resp;
        }
        
    }
}