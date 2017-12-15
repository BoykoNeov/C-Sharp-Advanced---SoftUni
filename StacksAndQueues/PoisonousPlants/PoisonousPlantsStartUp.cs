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
            List<int> plants = Console.ReadLine().Split().Select(int.Parse).ToList();

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

            Console.WriteLine(cycleCounter);
        }
    }
}