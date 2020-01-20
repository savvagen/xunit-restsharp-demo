using System;
using System.Net;
using FluentAssertions;
using NUnit.Framework;
using nunit_restsharp_demo_project.Models;

namespace nunit_restsharp_demo_project.Test.RestSharp
{
    
    [TestFixture]
    public class UserServiceTests: BaseTest
    {

        [SetUp]
        public void Init()
        {
            Console.WriteLine("=== Start ===");

        }

        [TearDown]
        public void Cleanup()
        {
            Console.WriteLine("=== Finish ===");
        }

        [Test]
        public void ShouldGetUser()
        {
            var resp = UserService.GetUser<User>(1);
            resp.StatusCode.Should().Be(HttpStatusCode.OK);
            resp.Data.id.Should().Be(1);
            resp.Data.email.Should().Be("user1@test.com");
        }
        
        [Test]
        public void ShouldCreateUser()
        {
            var user = new User {name = "test", username = "test.test", email = "my_email@test.com"};
            var resp = UserService.CreateUser<User>(user);
            resp.StatusCode.Should().Be(HttpStatusCode.Created);
            resp.Data.id.Should().BeInRange(100, 300);
            resp.Data.email.Should().Be(user.email);
        }
        
    }
}