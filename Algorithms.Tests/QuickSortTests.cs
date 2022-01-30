using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingAndSearchingArrayAlgorithms.Tests
{
    [TestClass]
    public class QuickSortTests
    {
        BaseSortTests<QuickSort<int>> test = new BaseSortTests<QuickSort<int>>();
        QuickSort<int> sorter = new QuickSort<int>();

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
