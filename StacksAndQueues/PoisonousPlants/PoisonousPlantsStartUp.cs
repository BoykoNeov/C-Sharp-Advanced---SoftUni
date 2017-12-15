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
            LinkedList<int> plants = new LinkedList<int>(Console.ReadLine().Split().Select(int.Parse));

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

            Console.WriteLine(cycleCounter - 1);
        }
    }
}