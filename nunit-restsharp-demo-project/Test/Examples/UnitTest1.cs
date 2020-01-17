using System;
using System.Threading;
using NUnit.Framework;

namespace nunit_restsharp_demo_project
{
    [TestFixture]
    [NonParallelizable]
    public class FirstTests
    {

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Test started");
        }
        
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Test finished");
        }


        [Test]
        public void Test1()
        {
            Console.WriteLine("Test 1");
            Thread.Sleep(4000);
            Assert.True((10 - 5) == 5, "Number should match 5");
        }
        
        [Test]
        public void Test2()
        {
            Console.WriteLine("Test 2");
            Thread.Sleep(3000);
            Assert.True((10 - 5) == 5, "Number should match 5");
        }

    }
}