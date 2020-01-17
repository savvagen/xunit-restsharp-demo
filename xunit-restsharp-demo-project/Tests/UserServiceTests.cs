using System;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using Xunit;
using xunit_restsharp_demo_project.Fixtures;
using xunit_restsharp_demo_project.Models;

namespace xunit_restsharp_demo_project
{
    public class UserServiceTests : IClassFixture<TestBaseFixture>, IClassFixture<ServicesFixture>
    {
        private TestBaseFixture TestBaseFixture;
        private ServicesFixture ServicesFixture;

        public UserServiceTests(TestBaseFixture testBaseFixture, ServicesFixture servicesFixture)
        {
            TestBaseFixture = testBaseFixture;
            ServicesFixture = servicesFixture;
        }


        [Fact]
        public void Test1()
        {
            var getUser = new RestRequest("/users/1", Method.GET, DataFormat.Json);
            var response = TestBaseFixture.Client.Get(request: getUser);
            var user = JsonConvert.DeserializeObject<User>(response.Content);
            response.StatusCode.Should().Be(200);
            response.ContentType.Should().Be("application/json; charset=utf-8");
            user.Id.Should().Be(1);
            user.Name.Should().Be("user1");
        }

        [Fact]
        public void Test2()
        {
            var resp = ServicesFixture.UserService.GetUser(2);
            var user = JsonConvert.DeserializeObject<User>(resp.Content);
            resp.StatusCode.Should().Be(200);
            resp.ContentType.Should().Be("application/json; charset=utf-8");
            user.Id.Should().Be(2);
            user.Name.Should().Be("user2");
        }
    }
}