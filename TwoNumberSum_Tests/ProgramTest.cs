using System;
using Xunit;
using TwoNumberSum_;

namespace TwoNumberSum_Tests
{
    public class ProgramTest
    {
        [Fact]
        public void Test1()
        {
            int[] output = Program.TwoNumberSum(new int[] { 3, 5, -4, 8, 11, 1, -1, 6 }, 10);
           // Assert.True(output.Length == 2);
            Assert.True(Array.Exists(output, e => e == -1));
            Assert.True(Array.Exists(output, e => e == 11));
        }
    }
}

