/// <summary>
/// Solution Gives 77/100 in Judge
/// </summary>
namespace PoisonousPlants
{
    using System.Collections.Generic;
    using System.Linq;

    public class ListSolution
    {
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