using System.Threading;
using Xunit;
[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass, MaxParallelThreads = 2)]

namespace xunit_restsharp_demo_project
{
    public class ParallelTests
    {
        [Collection("Suite2")]
        public class TestClass1
        {
            
            [Fact]
            public void Test1()
            {
                string text = "hello-world";
                Thread.Sleep(3000);
                Assert.Equal("hello-world", text);
            }
            
            [Fact]
            public void Test2()
            {
                string text = "hello-world";
                Thread.Sleep(3000);
                Assert.Equal("hello-world", text);
            }
        }
        
        [Collection("Suite1")]
        public class TestClass2
        {
            
            [Fact]
            public void Test1()
            {
                string text = "hello-world";
                Thread.Sleep(3000);
                Assert.Equal("hello-world", text);
            }
            
            [Fact]
            public void Test2()
            {
                string text = "hello-world";
                Thread.Sleep(3000);
                Assert.Equal("hello-world", text);
            }
        }
        
    }
}