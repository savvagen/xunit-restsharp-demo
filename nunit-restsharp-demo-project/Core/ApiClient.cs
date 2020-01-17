using System;
using System.Threading.Tasks;
using log4net;
using log4net.Core;
using RestSharp;
using static nunit_restsharp_demo_project.Core.Logger;


//[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]
namespace nunit_restsharp_demo_project.Core
{
    
    
   
    public abstract class ApiClient
    {
        //private static ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static ILog Log = LogManager.GetLogger(typeof(ApiClient));


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
            printRequest(client, request);
            var resp = client.Execute<T>(request);
            if (resp.ErrorException != null)
            {
                const string message = "Error retrieving response.";
                throw new ApplicationException(message + $"\n{resp.Content}", resp.ErrorException);
            }
            if (resp.IsSuccessful)
            {
                printResponse(resp);
            }
            return resp;
            
        }


        public IRestResponse ExecuteRequest(RestClient client, IRestRequest request)
        {
            printRequest(client, request);
            var taskCompletionSource = new TaskCompletionSource<IRestResponse>();
            var resp = client.Execute(request);
            if (resp.ErrorException != null)
            {
                const string message = "Error retrieving response.";
                throw new ApplicationException(message + $"\n{resp.Content}", resp.ErrorException);
            }
            if (resp.IsSuccessful)
            {
                printResponse(resp);

            }
            taskCompletionSource.SetResult(resp);
            return resp;
        }

        public static void printRequest(IRestClient client, IRestRequest request)
        {
            Log.Debug("Request:");
            Log.Debug(request.Method);
            Log.Debug(client.BaseUrl + request.Resource);
            Log.Debug("-----");
        }

        public static void printResponse(IRestResponse response)
        {
            Log.Debug("Response:");
            Log.Debug(response.StatusCode);
            Log.Debug(response.Content);
        }

        
    }
    
    
    
}