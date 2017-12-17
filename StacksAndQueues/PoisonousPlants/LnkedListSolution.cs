namespace PoisonousPlants
{
    using System.Collections.Generic;
    using System.Linq;

    public class LnkedListSolution
    {
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