using RestSharp;

namespace nunit_restsharp_demo_project.Core.Conditions
{
    public interface ICondition
    {
        public void check(IRestResponse response);

        public void uncheck(IRestResponse response);
        
    }
}