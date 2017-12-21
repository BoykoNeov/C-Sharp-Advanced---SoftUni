namespace DiagonalDifference
{
    using System;
    using System.Linq;

    public class DiagonalDifferenceStartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                //Some 'nice guy' has left empty spaces in the input, so an exception is thrown (except in the zero tests) if empty entries are not removed
                int[] row = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            long primaryDiagonal = 0;
            long secondaryDiagonal = 0;

            for (int i = 0; i < n; i++)
            {
                primaryDiagonal += matrix[i, i];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                secondaryDiagonal += matrix[i, n - 1 - i];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}