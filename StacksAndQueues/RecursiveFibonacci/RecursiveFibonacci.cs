namespace RecursiveFibonacci
{
    using System;

    public class RecursiveFibonacci
    {
        static long[] fibonacciLookup = new long[50];

        public static void Main()
        {
            fibonacciLookup[0] = 1;
            fibonacciLookup[1] = 1;

            Console.WriteLine(GetFibonacci(int.Parse(Console.ReadLine()) - 1));
        }

        private static long GetFibonacci(int n)
        {
            if (fibonacciLookup[n] != 0)
            {
                return fibonacciLookup[n];
            }
            else
            {
                long result = GetFibonacci(n - 1) + GetFibonacci(n - 2);
                fibonacciLookup[n] = result;
                return result;
            }
        }
    }
}