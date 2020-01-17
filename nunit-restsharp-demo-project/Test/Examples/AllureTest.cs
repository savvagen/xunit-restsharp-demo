using System;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace nunit_restsharp_demo_project
{
    [TestFixture]
    [AllureNUnit]
    [AllureSubSuite("Example")]
    [AllureSeverity(SeverityLevel.critical)]      
    public class AllureTest
    {
        [Test]
        [AllureTag("NUnit","Debug")]
        [AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        [AllureFeature("Core")]
        public void EvenTest([Range(0, 5)] int value)
        {
            Console.WriteLine($"This is test with value {value}");
            Assert.IsTrue(value % 2 == 0, $"Oh no :( {value} % 2 = {value % 2}" );
        }
    }
}