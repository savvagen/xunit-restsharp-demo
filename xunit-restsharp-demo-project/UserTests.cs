using System;
using FluentAssertions;
using Microsoft.VisualStudio.CodeCoverage;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using Xunit;
using Xunit.Abstractions;
using xunit_restsharp_demo_project.Client;
using xunit_restsharp_demo_project.Models;

namespace xunit_restsharp_demo_project
{
    public class UserTests : TestBase
    {

        [Fact]
        public void Test1()
        {
            var getUser = new RestRequest("/users/1", Method.GET, DataFormat.Json);
            var response = _client.Get(request: getUser);
            var user = JsonConvert.DeserializeObject<User>(response.Content);
            response.StatusCode.Should().Be(200);
            response.ContentType.Should().Be("application/json; charset=utf-8");
            user.Id.Should().Be(1);
            user.Name.Should().Be("user1");
        }

        [Fact]
        public void Test2()
        {
            var resp = UserService.GetUser(2);
            var user = JsonConvert.DeserializeObject<User>(resp.Content);
            resp.StatusCode.Should().Be(200);
            resp.ContentType.Should().Be("application/json; charset=utf-8");
            user.Id.Should().Be(2);
            user.Name.Should().Be("user2");
        }
    }
}