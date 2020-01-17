using System;
using nunit_restsharp_demo_project.Core.Conditions.ConditionTypes;

namespace nunit_restsharp_demo_project.Core.Conditions
{
    public class Conditions
    {
        public static ICondition StatusCode(int statusCode)
        {
            return new StatusCodeCondition(statusCode);
        }

        public static ICondition ContentType(string contentType)
        {
            return new ContentTypeCondition(contentType);
        }
        
    }
}