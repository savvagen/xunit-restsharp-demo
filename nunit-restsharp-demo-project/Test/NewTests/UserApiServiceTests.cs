using System;
using System.Collections.Generic;
using Allure.Commons;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using nunit_restsharp_demo_project.Core.Services;
using nunit_restsharp_demo_project.Test;
using xunit_restsharp_demo_project.Models;
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
                .shouldHave(StatusCode(200)).Response;
            resp.Data.id.Should().Be(1);
        }

        [Test]
        [AllureTag("NUnit","Debug")]
        [AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        [AllureFeature("Users")]
        public void ShouldGetAllUsers()
        {
            var resp = UserService.GetUsers<List<User>>()
                .shouldHave(StatusCode(200))
                .shouldHave(ContentType("application/json; charset=utf-8")).Response;
            resp.Data.Count.Should().BeGreaterThan(100);
            resp.Data[0].id.Should().Be(1);

        }
        
        
    }
}