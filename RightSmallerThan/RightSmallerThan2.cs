using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightSmallerThan
{
    class RightSmallerThan2
    {
        // Average case: when the created BST is balanced  // O(nlog(n)) time | O(n) space - where n is the length of the array  // --  // Worst case: when the the created BST is like a linked list  // O(n^2) time | O(n) space
        public static List<int> RightSmallerThan(List<int> array)
        {
            if (array.Count == 0) return new List<int>();
            List<int> rightSmallerCounts = new List<int>(array); int lastIdx = array.Count - 1; SpecialBST bst = new SpecialBST(array[lastIdx]); rightSmallerCounts[lastIdx] = 0; for (int i = array.Count - 2; i >= 0; i--) { bst.insert(array[i], i, rightSmallerCounts); } return rightSmallerCounts;
        }
        public class SpecialBST
        {
            public int value; public int leftSubtreeSize; public SpecialBST left; public SpecialBST right;
            public SpecialBST(int value) { this.value = value; leftSubtreeSize = 0; left = null; right = null; }
            public void insert(int value, int idx, List<int> rightSmallerCounts) { insertHelper(value, idx, rightSmallerCounts, 0); }
            public void insertHelper(int value, int idx, List<int> rightSmallerCounts, int numSmallerAtInsertTime) { if (value < this.value) { leftSubtreeSize++; if (left == null) { left = new SpecialBST(value); rightSmallerCounts[idx] = numSmallerAtInsertTime; } else { left.insertHelper(value, idx, rightSmallerCounts, numSmallerAtInsertTime); } } else { numSmallerAtInsertTime += leftSubtreeSize; if (value > this.value)          numSmallerAtInsertTime++; if (right == null) { right = new SpecialBST(value); rightSmallerCounts[idx] = numSmallerAtInsertTime; } else { right.insertHelper(value, idx, rightSmallerCounts, numSmallerAtInsertTime); } } }
        } 
    }
}
