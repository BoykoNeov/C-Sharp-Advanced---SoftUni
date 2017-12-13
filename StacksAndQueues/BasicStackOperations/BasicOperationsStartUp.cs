namespace BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicOperationsStartUp
    {
        public static void Main()
        {
            int[] input = ReadNumbersFromConsole();

            int s = input[1];
            int x = input[2];

            int[] numbers = ReadNumbersFromConsole();

            Stack<int> workingStack = new Stack<int>(numbers);

            for (int i = 0; workingStack.Count > 0 && i < s; i++)
            {
                workingStack.Pop();
            }

            if (workingStack.Contains(x))
            {
                Console.Write("true");
            }
            else
            {
                Console.WriteLine(workingStack.Count > 0 ? workingStack.Min() : 0);
            }
        }

        private static int[] ReadNumbersFromConsole()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ' }, options: StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}