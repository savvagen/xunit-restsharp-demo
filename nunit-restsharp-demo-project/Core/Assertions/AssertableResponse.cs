using System;
using Allure.Commons;
using log4net;
using Newtonsoft.Json.Linq;
using NUnit.Allure.Core;
using nunit_restsharp_demo_project.Core.Conditions;
using RestSharp;

namespace nunit_restsharp_demo_project.Core.Assertions
{
   public class AssertableResponse<T>
    {
        // private static ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static ILog Log = LogManager.GetLogger(typeof(AssertableResponse));
        public IRestResponse<T> Response;

        public AssertableResponse(IRestResponse<T> response)
        {
            Response = response;
        }

        public AssertableResponse<T> ShouldHave(ICondition condition)
        {
            
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Log.Info($"Check for: {condition}");
                condition.check(Response);
            }, $"Check condition: {condition}");
            return this;
        }
        
        public AssertableResponse<T> ShouldNotHave(ICondition condition)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Log.Info($"Check is not: {condition}");
                condition.uncheck(Response);
            }, $"Check is not: {condition}");
            return this;
        }
        
        /*
         * Quick Access Methods
         */
        
        public T ExtractBody()
        {
            return JObject.Parse(Response.Content).ToObject<T>();
        }
        
        public JObject JsonPath()
        {
            return JObject.Parse(Response.Content);
        }
        
        public string GetJsonField(string jsonPath)
        {
            return JObject.Parse(Response.Content).SelectToken(jsonPath).Value<string>();
        }
    }
    
    
    
    
    public class AssertableResponse
    {
        private static ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IRestResponse Response;

        public AssertableResponse(IRestResponse response)
        {
            Response = response;
        }
        
        public AssertableResponse ShouldHave(ICondition condition)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Log.Info($"Check for: {condition}");
                condition.check(Response);
            }, $"Check condition: {condition}");
            return this;
        }
        
        public AssertableResponse ShouldNotHave(ICondition condition)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Log.Info($"Check is not: {condition}");
                condition.uncheck(Response);
            }, $"Check is not: {condition}");
            return this;
        }

        /*
        * Quick Access Methods
        */


        public T ExtractBodyAs<T>()
        {
            // return JsonConvert.DeserializeObject<T>(Response.Content);
            return JObject.Parse(Response.Content).ToObject<T>();
        }

        public JObject JsonPath()
        {
            return JObject.Parse(Response.Content);
        }

        public string GetJsonField(string jsonPath)
        {
            return JObject.Parse(Response.Content).SelectToken(jsonPath).Value<string>();
        }

        public T GetJsonField<T>(string jsonPath)
        {
            return JObject.Parse(Response.Content).SelectToken(jsonPath).Value<T>();
        }


    }
}