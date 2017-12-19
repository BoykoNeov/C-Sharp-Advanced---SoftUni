namespace SumMatrixElements
{
    using System;
    using System.Linq;

    public class SumMatrixElementsStartUp
    {
        public static void Main()
        {
            int[] inputSizes = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = inputSizes[0];
            int colsCount = inputSizes[1];

            int[][] matrix = new int[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                matrix[i] = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            long totalSum = 0;

            foreach (int[] row in matrix)
            {
                foreach (int number in row)
                {
                    totalSum += number;
                }
            }

            Console.WriteLine(rowsCount);
            Console.WriteLine(colsCount);
            Console.WriteLine(totalSum);
        }
    }
}