using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightSmallerThan
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        // O(n^2) time | O(n) space - where n is the length of the array
        public static List<int> RightSmallerThan(List<int> array) { List<int> rightSmallerCounts = new List<int>(); for (int i = 0; i < array.Count; i++) { int rightSmallerCount = 0; for (int j = i + 1; j < array.Count; j++) { if (array[j] < array[i]) { rightSmallerCount++; } } rightSmallerCounts.Add(rightSmallerCount); } return rightSmallerCounts; } 
    }
}
