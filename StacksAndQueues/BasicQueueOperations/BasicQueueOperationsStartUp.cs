namespace BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicQueueOperationsStartUp
    {
        public static void Main()
        {
            int[] input = ReadNumbersFromConsole();

            int s = input[1];
            int x = input[2];

            int[] numbers = ReadNumbersFromConsole();

            Queue<int> workingQueue = new Queue<int>(numbers);

            for (int i = 0; workingQueue.Count > 0 && i < s; i++)
            {
                workingQueue.Dequeue();
            }

            if (workingQueue.Contains(x))
            {
                Console.Write("true");
            }
            else
            {
                Console.WriteLine(workingQueue.Count > 0 ? workingQueue.Min() : 0);
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