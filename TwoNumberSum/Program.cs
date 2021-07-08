using System;
using System.Collections;
using System.Collections.Generic;

namespace TwoNumberSum_
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 3, 5, -4, 8, 11, 1, -1, 6};
            int targetSum = 10;
            var answer = TwoNumberSum(array, targetSum);

            Console.WriteLine(answer);
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
                else if (currentSum <targetSum)
                {
                    left++;
                }
                else if (currentSum< targetSum)
                {
                    right--;
                }           
            }
            return new int[0];
        }

        
        //Using the HashSet table.

        // Using a hash table
        //public static int[] TwoNumberSum(int[] array,int targetSum)
        //{
        //    HashSet<int>  numbers = new HashSet<int>();

        //    foreach (var number in array)
        //    {
        //        int potentialMatch = targetSum - number;
        //        if (numbers.Contains(potentialMatch))
        //        {
        //            return new int[] { potentialMatch, number };
        //        }
        //        else
        //        {
        //            numbers.Add(number);
        //        }
        //    }
        //    return new int[0];
        //}


        // Using for loops
        //public static int[] TwoNumberSum(int[] array, int targerSum)
        //{
        //    for (int i = 0; i < array.Length - 1; i++)
        //    {
        //        int firstNumber = array[0];
        //        for (int j = 0; j < array.Length; j++)
        //        {
        //            int secondNum = array[j];
        //            if (firstNumber + secondNum == targerSum)
        //            {
        //                return new int[] { firstNumber, secondNum };
        //            }
        //        }
        //    }
        //    return new int[0];
        //}
    }
}
