namespace MaximumSumOf2by2Submatrix
{
    using System;
    using System.Linq;

    public class MaximumSumOf2by2SubmatrixStartUp
    {
        public static void Main()
        {
            int[] inputSizes = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = inputSizes[0];
            int colsCount = inputSizes[1];

            int[,] matrix = new int[rowsCount, colsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                int[] currentRow = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < colsCount; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            long biggestSum = long.MinValue;
            int biggestSubmatrixTopLeftRow = 0;
            int biggestSubmatrixTopLeftColumn = 0;
            for (int i = 0; i < rowsCount-1; i++)
            {
                for (int j = 0; j < colsCount-1; j++)
                {
                    long currentSum = matrix[i, j] + matrix[i+1, j] + matrix[i, j+1] + matrix[i+1, j+1];
                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        biggestSubmatrixTopLeftRow = i;
                        biggestSubmatrixTopLeftColumn = j;
                    }
                }
            }

            Console.WriteLine(matrix[biggestSubmatrixTopLeftRow, biggestSubmatrixTopLeftColumn] + " " + matrix[biggestSubmatrixTopLeftRow, biggestSubmatrixTopLeftColumn+1]);
            Console.WriteLine(matrix[biggestSubmatrixTopLeftRow+1, biggestSubmatrixTopLeftColumn] + " " + matrix[biggestSubmatrixTopLeftRow+1, biggestSubmatrixTopLeftColumn+1]);
            Console.WriteLine(biggestSum);
        }
    }
}