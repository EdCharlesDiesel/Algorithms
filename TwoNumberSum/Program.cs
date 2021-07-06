using System;

namespace TwoNumberSum_
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 3, 5, -4, 8, 11, 1, -1, 6};
            int targetSum = 5;
            var answer = TwoNumberSum(array, targetSum);

            Console.WriteLine(answer);
        }

        public static int[] TwoNumberSum(int[] array, int targerSum)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int firstNumber = array[0];
                for (int j = 0; j < array.Length; j++)
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
