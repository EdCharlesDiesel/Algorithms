using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region TwoNumberSum
            //int[] array = new int[] { 3, 5, -4, 8, 11, 1, -1, 6 };
            //int targetSum = 10;
            //var answer = TwoNumberSum(array, targetSum);
            //Console.WriteLine(answer);
            #endregion

            #region ValidateSubssequence
            //List<int> array = new List<int> { 3, 5, -4, 8, 11, 1, -1, 6 };
            //List<int> sequence= new List<int> {  -4, 8,  1,  6 };

            //var answer = IsValidateSbseuence(array, sequence);
            //Console.WriteLine(answer);
            //Console.ReadLine();
            #endregion
        }

        // Validate Subsequence using while loop
        // Space Time complexity is O(n) | 0(1) space
        public static bool IsValidateSbseuence(List<int> array, List<int> sequence)
        {
            int arrayIndex = 0;
            int sequenceIndex = 0;

            while (arrayIndex < array.Count && sequenceIndex < sequence.Count)
            {
                if (array[arrayIndex] == sequence[sequenceIndex])
                {
                    sequenceIndex++;
                }
                arrayIndex++;

            }
            return sequenceIndex == sequence.Count;
        }

        // Validate Subsequence using for loop
        // Space Time complexity is O(n) | 0(1) space
        public static bool IsValidateSbseuence_loop(List<int> array, List<int> sequence)
        {
            int sequenceIndex = 0;

            foreach (var value in array)
            {
                if (sequenceIndex == sequence.Count)
                {
                    return true;
                }
                if (sequence[sequenceIndex] == value)

                    sequenceIndex++;
            }
            return sequenceIndex == sequence.Count;

        }

        //Using while loop
        public static int[] TwoNumberSum(int[] array, int targetSum)
        {
            Array.Sort(array);
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                int currentSum = array[left] + array[right];
                if (currentSum == targetSum)
                {
                    return new int[] { array[left], array[right] };
                }
                else if (currentSum < targetSum)
                {
                    left++;
                }
                else if (currentSum < targetSum)
                {
                    right--;
                }
            }
            return new int[0];
        }

        //Using the HashSet table.
        public static int[] TwoNumberSum_HashSet(int[] array, int targetSum)
        {
            HashSet<int> numbers = new HashSet<int>();

            foreach (var number in array)
            {
                int potentialMatch = targetSum - number;
                if (numbers.Contains(potentialMatch))
                {
                    return new int[] { potentialMatch, number };
                }
                else
                {
                    numbers.Add(number);
                }
            }
            return new int[0];
        }

        // Using for loops
        public static int[] TwoNumberSumFor(int[] array, int targerSum)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int firstNumber = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    int secondNum = array[j];
                    if (firstNumber + secondNum == targerSum)
                    {
                        return new int[] { firstNumber, secondNum };
                    }
                }
            }
            return new int[0];
        }
    }
}
