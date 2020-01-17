using System;
using NUnit.Framework;

namespace nunit_restsharp_demo_project
{
    
    [TestFixture]
    [Parallelizable]
    public class ParallelTests1
    {
        
        [Test]
        public void Test11()
        {
            Console.WriteLine("Test1");
            System.Threading.Thread.Sleep(2000);
            Assert.Pass();
        }
        
        [Test]
        public void Test21()
        {
            Console.WriteLine("Test1");
            System.Threading.Thread.Sleep(3000);
            Assert.Pass();
        }
        
    }

    [TestFixture]
    [Parallelizable]
    public class ParallelTests2
    {
        [Test]
        public void Test12()
        {
            Console.WriteLine("Test1");
            System.Threading.Thread.Sleep(2000);
            Assert.Pass();
        }
        
        [Test]
        public void Test22()
        {
            Console.WriteLine("Test1");
            System.Threading.Thread.Sleep(3000);
            Assert.Pass();
        }
    }
}