namespace StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class StackFibonacciStartUp
    {
        public static void Main()
        {
            Stack<long> fibonacciStack = new Stack<long>();
            fibonacciStack.Push(0);
            fibonacciStack.Push(1);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                long firstNumber = fibonacciStack.Pop();
                long secondNumber = fibonacciStack.Pop();

                secondNumber = firstNumber + secondNumber;

                fibonacciStack.Push(firstNumber);
                fibonacciStack.Push(secondNumber);
            }

            fibonacciStack.Pop();
            Console.WriteLine(fibonacciStack.Pop());
        }
    }
}