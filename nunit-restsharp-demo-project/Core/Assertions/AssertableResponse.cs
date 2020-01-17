using System;
using Allure.Commons;
using log4net;
using NUnit.Allure.Core;
using NUnit.Allure.Steps;
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

        
        //[AllureStep()]
        public AssertableResponse<T> shouldHave(ICondition condition)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Log.Info($"Check for: {condition}");
                condition.check(Response);
            }, $"Check condition: {condition}");
            return this;
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
        
        //[AllureStep()]
        public AssertableResponse shouldHave(ICondition condition)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Log.Info($"Check for: {condition}");
                condition.check(Response);
            }, $"Check condition: {condition}");
            return this;
        }
    }
}