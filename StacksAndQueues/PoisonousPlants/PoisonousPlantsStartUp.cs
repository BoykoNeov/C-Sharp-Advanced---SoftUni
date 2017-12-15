namespace PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisonousPlantsStartUp
    {
        public static void Main()
        {
            int arrayLength = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            if (input.Length > 20000)
            {
                Console.WriteLine(GetResult(input, arrayLength));
            }
            else
            {
                Console.WriteLine(TrivialSolutionUsingLinkedList(input));
            }

            //  Console.WriteLine(TrivialSolutionUsingQueue(input));
            //  Console.WriteLine(TrivialSolutionUsingLists(input));



        }

        private static int GetResult(string input, int arrayLength)
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
                    i++;

                    while (i < arrayLength && plants[i] > minNumber && plants[i] < plants[i-1])
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

        public static int TrivialSolutionUsingLinkedList(string input)
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

        public static int TrivialSolutionUsingQueue(string input)
        {
            Queue<int> plants = new Queue<int>(input.Split().Select(int.Parse));

            int cycleCounter = 0;
            bool plantsDying = true;

            while (plantsDying)
            {
                int previousNumber = int.MaxValue;
                int queueSize = plants.Count;
                plantsDying = false;

                for (int i = 0; i < queueSize; i++)
                {
                    int currentNumber = plants.Dequeue();
                    if (currentNumber <= previousNumber)
                    {
                        plants.Enqueue(currentNumber);
                    }
                    else
                    {
                        plantsDying = true;
                    }

                    previousNumber = currentNumber;
                }

                cycleCounter++;
            }

            return cycleCounter - 1;
        }

        public static int TrivialSolutionUsingLists(string input)
        {
            List<int> plants = input.Split().Select(int.Parse).ToList();

            int cycleCounter = 0;
            bool anyPlantsDying = true;

            while (anyPlantsDying)
            {
                List<int> nextCyclePlants = new List<int>(plants.Count);
                nextCyclePlants.Add(plants[0]);
                anyPlantsDying = false;

                for (int i = 0; i < plants.Count - 1; i++)
                {
                    if (plants[i] < plants[i + 1])
                    {
                        anyPlantsDying = true;
                    }
                    else
                    {
                        nextCyclePlants.Add(plants[i + 1]);
                    }
                }

                if (anyPlantsDying)
                {
                    cycleCounter++;
                }

                plants = new List<int>(nextCyclePlants);
            }

            return cycleCounter;
        }
    }
}