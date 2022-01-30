using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingAndSearchingArrayAlgorithms.Tests
{
    public class BaseSortTests<T> where T: SortingMetrics<int>
    {
        public void PreSortedTests(T algorithm)
        {
            TestUtils.DemandSorted(algorithm.Sort(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
            TestUtils.DemandSorted(algorithm.Sort(new int[] { 1 }));
            TestUtils.DemandSorted(algorithm.Sort(new int[] { 1, 2 }));
            TestUtils.DemandSorted(algorithm.Sort(new int[] { }));
            TestUtils.DemandSorted(algorithm.Sort(new int[] { 1, 2, 3 }));
            TestUtils.DemandSorted(algorithm.Sort(new int[] { 1, 1 }));
            TestUtils.DemandSorted(algorithm.Sort(new int[] { 1, 1, 1 }));
        }

        public void UnsortedTests(T algorithm)
        {
            TestUtils.DemandSorted(algorithm.Sort(new int[] { 2, 1 }));
            TestUtils.DemandSorted(algorithm.Sort(new int[] { 2, 3, 1 }));
            TestUtils.DemandSorted(algorithm.Sort(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 }));
            TestUtils.DemandSorted(algorithm.Sort(new int[] { 9, 8, 7, 6, 5, 4, 3, 1, 2 }));
        }

        public void RandomTests(T algorithm, int length = 1000)
        {
            TestUtils.DemandSorted(algorithm.Sort(RandomArray(length)));
        }

        private Random _rng = new Random();

        private int[] RandomArray(int length)
        {
            int[] data = new int[length];
            for(int i = 0; i < data.Length; i++)
            {
                data[i] = _rng.Next();
            }

            return data;
        }
    }
}
