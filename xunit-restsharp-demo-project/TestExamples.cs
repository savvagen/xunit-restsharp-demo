using System;
using System.Collections.Generic;
using Xunit;

namespace xunit_restsharp_demo_project
{
    public class TestExamples
    {


        [Fact]
        public void voidShouldRunOnlySingleTest()
        {
            string text = "hello-world";
            Assert.Equal("hello-world", text);
        }


        [Theory(DisplayName = "test2")]
        [InlineData(1, "hello")]
        public void SouldRuntestWithParameters(int number, string text)
        {
            Assert.Equal(1, number);
            Assert.Equal("hello", text);
        }


        [Theory]
        [MemberData("someData")]
        public void ShouldTestArrayOFData(int num1, int num2, string text)
        {
            Assert.Equal(num1, num2);
            Assert.Equal("hello", text);
        }    



        public static IEnumerable<object[]> someData()
        {
            yield return new object[]{1, 1, "hello"};
            yield return new object[]{2, 2, "hello"};
        }
        
    }
}