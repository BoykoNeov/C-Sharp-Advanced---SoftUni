/// <summary>
/// I was just unable to force myself to use queues for this problem
/// </summary>
namespace TruckTour
{
    using System;
    using System.Linq;

    public class TruckTourStartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[,] inputData = new int[n,2];

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                inputData[i, 0] = input[0];  // Current petrol station provides this fuel
                inputData[i, 1] = input[1]; // Distance to next petrol station
            }

            for (int i = 0; i < n; i++)
            {
                int availableFuel = 0;

                for (int j = 0; j < n; j++)
                {
                    int currentPetrolPumpNumber = (i + j) % n;

                    availableFuel += inputData[currentPetrolPumpNumber, 0];
                    int distanceToCover = inputData[currentPetrolPumpNumber, 1];

                    if (availableFuel - distanceToCover < 0)
                    {
                        i = currentPetrolPumpNumber;
                        break;
                    }
                    else
                    {
                        availableFuel -= distanceToCover;

                        if (j == n - 1)
                        {
                            Console.WriteLine(i);
                            return;
                        }
                    }
                }
            }
        }
    }
}