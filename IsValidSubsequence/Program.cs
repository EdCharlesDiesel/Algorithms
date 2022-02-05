using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsValidSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        // O(n) time | O(1) space - where n is the length of the array
        public static bool IsValidSubsequence(List<int> array, List<int> sequence)
        {
            int arrIdx = 0;
            int seqIdx = 0;
            while (arrIdx < array.Count && seqIdx < sequence.Count)
            {
                if (array[arrIdx] == sequence[seqIdx])
                {
                    seqIdx++;
                }
                arrIdx++;
            }
            return seqIdx == sequence.Count;
        }

        // O(n) time | O(1) space - where n is the length of the array
        public static bool IsValidSubsequence2(List<int> array, List<int> sequence)
        {
            int seqIdx = 0;
            foreach (var val in array)
            {
                if (seqIdx == sequence.Count)
                {
                    break;
                }
                if (sequence[seqIdx] == val)
                {
                    seqIdx++;
                }
            }
            return seqIdx == sequence.Count;
        }
    }
}
