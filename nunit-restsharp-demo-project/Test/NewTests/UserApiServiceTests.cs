using System;
using System.Collections.Generic;
using Allure.Commons;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using nunit_restsharp_demo_project.Core.Services;
using nunit_restsharp_demo_project.Models;
using nunit_restsharp_demo_project.Test;
using static nunit_restsharp_demo_project.Core.Conditions.Conditions;
using ContentType = RestSharp.Serialization.ContentType;


namespace nunit_restsharp_demo_project.Test.NewTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSubSuite("Example")]
    [AllureSeverity(SeverityLevel.critical)]      
    public class UserApiServiceTests: TestBase
    {

        [Test]
        [AllureTag("NUnit","Debug")]
        [AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        [AllureFeature("Users")]
        public void ShouldGetUser()
        {
            var resp = UserService.GetUser<User>(1)
                .ShouldHave(StatusCode(200)).Response;
            resp.Data.id.Should().Be(1);
        }
        
        [Test]
        [AllureTag("NUnit","Debug")]
        [AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        [AllureFeature("Users")]
        public void ShouldGetAndExtractUser()
        {
            var user = UserService.GetUser<User>(1)
                .ShouldHave(StatusCode(200)).ExtractBody();
            user.id.Should().Be(1);
            user.email.Should().Be("user1@test.com");
            user.username.Should().Be("user_name1");

        }

        [Test]
        [AllureTag("NUnit","Debug")]
        [AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        [AllureFeature("Users")]
        public void ShouldGetAllUsers()
        {
            var resp = UserService.GetUsers<List<User>>()
                .ShouldHave(StatusCode(200))
                .ShouldHave(ContentType("application/json; charset=utf-8")).Response;
            resp.Data.Count.Should().BeGreaterThan(100);
            resp.Data[0].id.Should().Be(1);

        }
        
        
    }
}