using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization;
using RestSharp.Serialization.Json;
using xunit_restsharp_demo_project.Models;

namespace nunit_restsharp_demo_project.Test.RestSharp
{
    [TestFixture]
    public class UserTest: BaseTest
    {

        [Test]
        public void ShouldGetUser()
        {
           var getUser = new RestRequest("/users/{id}", Method.GET)
               .AddUrlSegment("id", 1)
               .AddHeader("Content-Type", ContentType.Json);
           var resp = Client.Execute(getUser);
           resp.StatusCode.Should().Be(200);
           Console.WriteLine(resp.StatusCode);
           Console.WriteLine(resp.Content);
           JsonConvert.DeserializeObject<User>(resp.Content).id.Should().Be(1);
        }

        [Test]
        public void ShouldGetAllUsers()
        {
            var getUsers = new RestRequest("/users", Method.GET, DataFormat.Json);
            var resp = Client.Execute(getUsers);
            var users = JsonConvert.DeserializeObject<List<User>>(resp.Content);
            users.Count.Should().Be(users.Last().id);
            users[0].id.Should().Be(1);
            users[0].email.Should().Be("user1@test.com");

        }
        
        [Test]
        public void ShouldCreateNewUser()
        {
            var user = new User("test", "test@gmail.com", "test.test");
            // var json = JObject.FromObject(user).ToString(); 
            var createUser = new RestRequest("/users", Method.POST, DataFormat.Json)
                .AddParameter(ContentType.Json, JObject.FromObject(user) , ParameterType.RequestBody)
                //.AddBody(user);
                //.AddBody(new User {name = "test", email = "test@gmail.com", username = "test.test" })
                .AddHeader("Content-Type", ContentType.Json);
            
            var resp = Client.Execute(createUser);
            Console.WriteLine(resp.StatusCode);
            Console.WriteLine(resp.Content);
            
            var createdUser = JObject.Parse(resp.Content);
            resp.StatusCode.Should().Be(HttpStatusCode.Created);
            createdUser["email"].ToString().Should().Be(user.email);


        }
        
        [Test]
        public void ShouldCreateNewUserWithDataParam()
        {
            var createUser = new RestRequest("/users", Method.POST, DataFormat.Json)
                .AddBody(new User {name = "test", email = "test@gmail.com", username = "test.test"})
                .AddHeader("Content-Type", ContentType.Json);
            
            //var resp = Client.Execute<User>(createUser);

            // var resp = ExecuteAsyncRequest<User>(Client, createUser).GetAwaiter().GetResult();
            // var resp = ExecuteRequest<User>(Client, createUser).GetAwaiter().GetResult();
            var resp = ExecuteRequest<User>(Client, createUser);
            
            resp.StatusCode.Should().Be(HttpStatusCode.Created);
            resp.Data.id.Should().BeInRange(100, 300);
            resp.Data.email.Should().Be("test@gmail.com");
        }
        
    }
}