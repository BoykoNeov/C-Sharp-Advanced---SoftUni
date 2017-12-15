/// <summary>
/// Solution Gives 77/100
/// </summary>
namespace PoisonousPlants
{
    using System.Collections.Generic;
    using System.Linq;

    public class QueueSolution
    {
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
    }
}