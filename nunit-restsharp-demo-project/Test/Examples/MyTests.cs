using System.Threading;
using log4net;
using NUnit.Framework;
using static nunit_restsharp_demo_project.Core.Logger;

namespace nunit_restsharp_demo_project.Test.Examples
{
    public class BaseTest
    {
        public BaseTest()
        {
           InitLogger();
        }
    }
    
    [TestFixture]
    [Parallelizable]
    public class MyTests: BaseTest
    {
        private static ILog log = LogManager.GetLogger(typeof(MyTests));

        [SetUp]
        public void Setup()
        {
            log.Info("Test1 Started.");
            
        }
        
        [TearDown]
        public void Clenup()
        {
            log.Info("Test1 Finished.");

        }

        [Test]
        public void LogSomething()
        {
            log.Info("Test1_1 Passed.");
            Thread.Sleep(4000);
            Assert.True(true);

        }
        
        [Test]
        public void LogSomething2()
        {
            log.Info("Test2_1 Passed.");
            Thread.Sleep(4000);
            Assert.True(true);

        }
        
    }
    
    [TestFixture]
    [Parallelizable]
    public class MyTests2: BaseTest
    {
        private static ILog log = LogManager.GetLogger(typeof(MyTests2));

        [SetUp]
        public void Setup()
        {
            log.Info("Test2 Started.");
            
        }
        
        [TearDown]
        public void Clenup()
        {
            log.Info("Test2 Finished.");
            
        }


        [Test]
        public void LogSomething()
        {
            log.Info("Test1_2 Passed.");
            Thread.Sleep(3000);
            Assert.True(true);
        }
        
        [Test]
        public void LogSomething2()
        {
            log.Info("Test2_2 Passed.");
            Thread.Sleep(3000);
            Assert.True(true);
        }
        
    }
}