using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingAndSearchingArrayAlgorithms.Tests
{
    [TestClass]
    public class TestUtils
    {
        [TestMethod]
        public void SortCheckWorks()
        {
            DemandSorted(new int[] { });
            DemandSorted(new int[] { 1 });
            DemandSorted(new int[] { 1, 2 });
            DemandSorted(new int[] { 1, 2, 3 });
            DemandSorted(new int[] { 1, 2, 3, 4, 5 });
            Assert.IsFalse(CheckSorted(new int[] { 1, 2, 3, 5, 4 }));
            Assert.IsFalse(CheckSorted(new int[] { 2, 1, 3, 4, 5 }));
            Assert.IsFalse(CheckSorted(new int[] { 1, 2, 4, 3, 5 }));
            Assert.IsTrue(CheckSorted(new int[] { 1, 2, 3, 4, 5 }));
        }

        internal static bool CheckSorted(int[] data, bool assert = false)
        {
            if (data.Length <= 1) return true;
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i - 1] > data[i])
                {
                    if (assert)
                    {
                        Assert.IsTrue(data[i - 1] < data[i],
                           string.Format("Sorting Error: {0} <= {1} (indexes {2}, {3}",
                            data[i - 1], data[i], i - 1, i));
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }



        internal static void DemandSorted(int[] data)
        {
            CheckSorted(data, true);
        }
    }
}
