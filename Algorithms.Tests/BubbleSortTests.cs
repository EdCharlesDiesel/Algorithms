using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingAndSearchingArrayAlgorithms.Tests
{
    [TestClass]
    public class BubbleSortTests
    {
        BaseSortTests<BubbleSort<int>> test = new BaseSortTests<BubbleSort<int>>();
        BubbleSort<int> sorter = new BubbleSort<int>();

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
