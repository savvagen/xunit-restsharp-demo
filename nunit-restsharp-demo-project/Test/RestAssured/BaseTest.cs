using System;
using NUnit.Framework;

namespace nunit_restsharp_demo_project.Test
{
    
    
    [TestFixture]
    public class BaseTest
    {
        public string BaseUrl;
        
        

        public BaseTest()
        {
            BaseUrl = "http://localhost:3000";
        }

        [SetUp]
        public void SetupSuite()
        {
            
        }

        [TearDown]
        public void TearDownSuite()
        {
            
        }
    }
}