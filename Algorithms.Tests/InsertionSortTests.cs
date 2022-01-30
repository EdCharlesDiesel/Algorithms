using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingAndSearchingArrayAlgorithms.Tests
{
    [TestClass]
    public class InsertionSortTests
    {
        BaseSortTests<InsertionSort<int>> test = new BaseSortTests<InsertionSort<int>>();
        InsertionSort<int> sorter = new InsertionSort<int>();

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
    }
}
