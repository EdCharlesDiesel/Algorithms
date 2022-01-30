using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingAndSearchingArrayAlgorithms.Tests
{
    [TestClass]
    public class MergeSortTests
    {
        BaseSortTests<MergeSort<int>> test = new BaseSortTests<MergeSort<int>>();
        MergeSort<int> sorter = new MergeSort<int>();

        [TestMethod]
        public void PreSortedTests()
        {
            test.PreSortedTests(sorter);
        }

        [TestMethod]
        public void UnsortedTests()
        {
            test.UnsortedTests(sorter);
        }

        [TestMethod]
        public void RandomTests()
        {
            test.RandomTests(sorter);
        }

        [TestMethod]
        public void RandomTests_50k()
        {
            test.RandomTests(sorter, 50000);
        }
    }
}
