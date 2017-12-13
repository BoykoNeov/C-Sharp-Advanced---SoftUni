namespace MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumElementStartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());


            Stack<int> workingStack = new Stack<int>(n);
            Stack<int> maxNumbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                switch (input[0])
                {
                    case 1:
                        workingStack.Push(input[1]);
                        if (maxNumbers.Count == 0 || maxNumbers.Peek() <= input[1])
                        {
                            maxNumbers.Push(input[1]);
                        }

                        break;

                    case 2:
                        int poppedNumber = workingStack.Pop();
                        if (poppedNumber == maxNumbers.Peek())
                        {
                            maxNumbers.Pop();
                        }

                        break;

                    case 3:
                        Console.WriteLine(maxNumbers.Peek());
                        break;

                    default:
                        break;
                }
            }
        }
    }
}