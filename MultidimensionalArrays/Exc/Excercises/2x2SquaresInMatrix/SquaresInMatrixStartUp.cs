namespace SquaresInMatrix
{
    using System;
    using System.Linq;

    public class SquaresInMatrixStartUp
    {
        public static void Main()
        {
            short[] input = Console.ReadLine().Split().Select(short.Parse).ToArray();
            int rows = input[0];
            int columns = input[1];

            string[][] matrix = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                string[] currentRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                matrix[i] = currentRow;
            }

            int squaresFound = 0;
            for (int i = 0; i < rows-1; i++)
            {
                for (int j = 0; j < columns-1; j++)
                {
                    if (matrix[i][j] == matrix[i + 1][j] &&
                        matrix[i][j] == matrix[i][j + 1] &&
                        matrix[i][j] == matrix[i + 1][j + 1]
                        )
                    {
                        squaresFound++;
                    }
                }
            }

            Console.WriteLine(squaresFound);
        }
    }
}