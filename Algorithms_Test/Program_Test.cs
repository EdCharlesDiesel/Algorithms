using Algorithms;
using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithms_Test
{
    public class Program_Test
    {
        [Fact]
        public void TwoNumberSum_Test()
        {
            int[] output = Program.TwoNumberSum(new int[] { 3, 5, -4, 8, 11, 1, -1, 6 }, 10);
            Assert.True(output.Length == 2);
            Assert.True(Array.Exists(output, e => e == -1));
            Assert.True(Array.Exists(output, e => e == 11));
        }

        [Fact]
        public void TwoNumberSum_HashSet_Test()
        {
            int[] output = Program.TwoNumberSum_HashSet(new int[] { 3, 5, -4, 8, 11, 1, -1, 6 }, 10);
            Assert.True(output.Length == 2);
            Assert.True(Array.Exists(output, e => e == -1));
            Assert.True(Array.Exists(output, e => e == 11));
        }

        [Fact]
        public void TwoNumberSum_for_Test()
        {
            int[] output = Program.TwoNumberSumFor(new int[] { 3, 5, -4, 8, 11, 1, -1, 6 }, 10);
            Assert.True(output.Length == 2);
            Assert.True(Array.Exists(output, e => e == -1));
            Assert.True(Array.Exists(output, e => e == 11));
        }

        [Fact]
        public void IsValidateSubsequence_Test()
        {
            var array = new List<int> { 3, 5, -4, 8, 11, 1, -1, 6 };
            var sequence = new List<int> { -4, 8, 1, 6 };

            bool output = Program.IsValidateSbseuence(array, sequence);

            Assert.True(output);            
        }


        [Fact]
        public void IsValidateSubsequence_loop_Test()
        {
            var array = new List<int> { 3, 5, -4, 8, 11, 1, -1, 6 };
            var sequence = new List<int> { -4, 8, 1, 6 };

            bool output = Program.IsValidateSbseuence_loop(array, sequence);

            Assert.True(output);
        }
    }
}
