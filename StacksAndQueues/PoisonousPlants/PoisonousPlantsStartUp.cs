namespace PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisonousPlantsStartUp
    {
        public static void Main()
        {
            Console.WriteLine(Tester.TestForDifference());
            Console.ReadLine();

            int arrayLength = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            Console.WriteLine(GetResult(input, arrayLength));
            Console.WriteLine(TrivialSolutionUsingLinkedList(input));


        }

            // test data, remove later
            //28
            //1 2 3 9 8 7 6 5 4 5 6 7 1 10 9 8 7 1 10 9 8 7 6 5 4 3 2 1

            //5
            //1 100 90 80 60

            //6
            //1 100 90 80 60 0

            //7
            //6 5 8 4 7 10 9

            //20
            //-1 -2 -3 1 0 1000 0 1900 1800 1700 1600 2000 -1000 3000 2999 2998 29997 100 200 300 

            //debug this
            //10
            //-7 -10 4 -8 9 6 -6 9 4 -8

            //and this
            //4
            //-5 1 8 -3
        internal static int GetResult(string input, int arrayLength)
        {
            int[] plants = input.Split().Select(int.Parse).ToArray();

            int minNumber = plants[0];
            int previousNumber = plants[0];
            int longestDiminishingSequence = 0;

            for (int i = 1; i < arrayLength; i++)
            {
                int currentLongestSequence = 0;

                if (plants[i] > plants[i - 1])
                {
                    currentLongestSequence = 1;
                    minNumber = plants[i - 1];
                  //  i++;

                    while (i+1 < arrayLength && plants[i+1] > minNumber && plants[i+1] <= plants[i])
                    {
                        currentLongestSequence++;
                        i++;
                    }

                    if (i < arrayLength && plants[i] < minNumber)
                    {
                        minNumber = plants[i];
                    }
                }
   
                if (currentLongestSequence > longestDiminishingSequence)
                {
                    longestDiminishingSequence = currentLongestSequence;
                }
            }

            return longestDiminishingSequence;
        }

        internal static int TrivialSolutionUsingLinkedList(string input)
        {
            LinkedList<int> plants = new LinkedList<int>(input.Split().Select(int.Parse));

            int cycleCounter = 0;
            bool plantsDying = true;

            while (plantsDying)
            {
                plantsDying = false;
                LinkedListNode<int> currentPlant = plants.Last;

                while (currentPlant.Previous != null)
                {
                    LinkedListNode<int> nextNodeToCheck = currentPlant.Previous;

                    if (nextNodeToCheck.Value < currentPlant.Value)
                    {
                        plantsDying = true;
                        plants.Remove(currentPlant);
                    }

                    currentPlant = nextNodeToCheck;
                }

                cycleCounter++;
            }

            return cycleCounter - 1;
        }
    }
}