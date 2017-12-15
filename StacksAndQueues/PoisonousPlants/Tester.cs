namespace PoisonousPlants
{
    using System;

    public class Tester
    {
        public static string TestForDifference()
        {
            Random rnd = new Random();
            int[] testArray = new int[10];


            int resultA = -1;
            int resultB = -1;

            while (resultA == resultB)
            {
                resultA = PoisonousPlantsStartUp.GetResult(string.Join(" ", testArray), testArray.Length);
                resultB = PoisonousPlantsStartUp.TrivialSolutionUsingLinkedList(string.Join(" ", testArray));

                testArray = randomizeArray(4, rnd, -10, 10);
            }

            return (string.Join(" ", testArray));
        }

        private static int[] randomizeArray (int arraySize, Random randomInstance, int minValue, int maxValue)
        {
            int[] testArray = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                testArray[i] = randomInstance.Next(minValue, maxValue);
            }

            return testArray;
        }

    }
}