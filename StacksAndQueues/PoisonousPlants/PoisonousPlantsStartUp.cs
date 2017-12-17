namespace PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisonousPlantsStartUp
    {
        public static void Main()
        {
            //   Console.WriteLine(Tester.TestForDifference());

            int arrayLength = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            Console.WriteLine(GetResult(input, arrayLength));
            //Console.WriteLine(LnkedListSolution.TrivialSolutionUsingLinkedList(input));
            //Console.WriteLine(ListSolution.TrivialSolutionUsingLists(input));
            //Console.WriteLine(QueueSolution.TrivialSolutionUsingQueue(input));
        }

        internal static int GetResult(string input, int arrayLength)
        {
            int[] plants = input.Split().Select(int.Parse).ToArray();
            int[] days = new int[arrayLength];
            Stack<int> plantsOfInterestPosition = new Stack<int>();
            plantsOfInterestPosition.Push(0);

            for (int i = 1; i < arrayLength; i++)
            {
                int maxDaysToDie = 0;

                while (plantsOfInterestPosition.Count > 0 && plants[i] <= plants[plantsOfInterestPosition.Peek()])
                {
                    maxDaysToDie = Math.Max(maxDaysToDie, days[plantsOfInterestPosition.Pop()]);
                }

                if (plantsOfInterestPosition.Count > 0)
                {
                    days[i] = maxDaysToDie + 1;
                }

                plantsOfInterestPosition.Push(i);
            }

            return days.Max();
        }
    }
}