using System;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using nunit_restsharp_demo_project.Models;
using RA;
using RestSharp.Serialization;

namespace nunit_restsharp_demo_project.Test
{
    
    [TestFixture]
    public class UserTests: BaseTest
    {

        [Test]
        public void GetUser()
        {
            
            var endpoint = new RestAssured()
                .Given()
                .Header("Content-Type", "application/json; charset=utf-8")
                .Host("localhost")
                .Port(3000)
                .Uri("/users/1");
            var resp = endpoint.When().Get()
                // .Debug() // --> Print Request Conditions
                .Then()
                .Debug() // --> Print Response Conditions
                .TestStatus("Should be equal 200", i => i == 200 )
                .TestBody("id", i => i.Equals(1));
            var id = resp.Retrieve(b => b.id);
            var user = (User) resp.Retrieve(u => JsonConvert.DeserializeObject<User>(u.ToString()));
            id.Should().Be(1);
            user.email.Should().Be("user1@test.com");

            resp.TestStatus("", s => s.Equals(200));
        }
        
    }
    
}