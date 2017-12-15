namespace PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisonousPlantsStartUp
    {
        public static void Main()
        {
            Console.ReadLine();
            Queue<int> plants = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

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

            Console.WriteLine(cycleCounter - 1);
        }
    }
}