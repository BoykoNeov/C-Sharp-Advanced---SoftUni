/// <summary>
/// I guess some smartass who is mentally challenged placed a task which cannot be solved with a two-dimensional array into multidimensional arrays' excercise
/// </summary>
namespace ParkingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] parkingParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = parkingParams[0];
            int columsCount = parkingParams[1];

            Dictionary<int, HashSet<int>> parking = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < rowsCount; i++)
            {
                parking[i] = new HashSet<int>();
                parking[i].Add(0);
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "stop")
            {
                int[] commandParams = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int entryRow = commandParams[0];
                int targetRow = commandParams[1];
                int targetColumn = commandParams[2];

                int cellsPassingCount = 1;

                while (entryRow < targetRow)
                {
                    cellsPassingCount++;
                    entryRow++;
                }

                while (entryRow > targetRow)
                {
                    cellsPassingCount++;
                    entryRow--;
                }

                targetColumn = FindAFreeCell(parking, targetRow, targetColumn, columsCount);

                if (parking[targetRow].Contains(targetColumn))
                {
                    Console.WriteLine($"Row {targetRow} full");
                    continue;
                }
                else
                {
                    parking[targetRow].Add(targetColumn);
                    cellsPassingCount += targetColumn;
                    Console.WriteLine(cellsPassingCount);
                }
            }
        }

        private static int FindAFreeCell(Dictionary<int, HashSet<int>> parking, int targetRow, int targetColumn, int maxColumns)
        {
            int searchCounter = 1;
            while (parking[targetRow].Contains(targetColumn) && searchCounter < maxColumns)
            {
                int searchIndex = targetColumn - searchCounter;
                if (searchIndex >= 0 && !parking[targetRow].Contains(searchIndex))
                {
                    return searchIndex;
                }

                searchIndex = targetColumn + searchCounter;
                if (searchIndex < maxColumns && !parking[targetRow].Contains(searchIndex))
                {
                    return searchIndex;
                }

                searchCounter++;
            }

            return targetColumn;
        }
    }
}