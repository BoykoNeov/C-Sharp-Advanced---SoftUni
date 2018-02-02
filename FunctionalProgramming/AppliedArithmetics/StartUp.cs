namespace AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<Action<int[]>> arithmeticOperations = new List<Action<int[]>>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "add")
                {
                    arithmeticOperations.Add(AddOperation);
                }
                else if(command == "subtract")
                {
                    arithmeticOperations.Add(SubtractOperation);
                }
                else if(command == "multiply")
                {
                    arithmeticOperations.Add(MultiplyOperation);
                }
                else if (command == "print")
                {
                    arithmeticOperations.Add(PrintOperation);
                }
            }

            foreach (Action<int[]> operation in arithmeticOperations)
            {
                operation(numbers);
            }
        }

        private static void AddOperation(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i]++;
            }
        }

        private static void SubtractOperation(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i]--;
            }
        }

        private static void MultiplyOperation(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] *= 2;
            }
        }

        private static void PrintOperation(int[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}