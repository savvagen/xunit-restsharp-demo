using nunit_restsharp_demo_project.Core.Services;

namespace nunit_restsharp_demo_project.Test.NewTests
{
    public class TestBase
    {

        public UserApiService UserService;

        public TestBase()
        {
            UserService = new UserApiService("http://localhost:3000");
        }
    }
}