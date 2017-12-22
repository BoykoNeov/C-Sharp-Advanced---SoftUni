namespace TargetPractice
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            // Read input data
            int[] matrixParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = matrixParams[0];
            int columnsCount = matrixParams[1];

            char[] snake = Console.ReadLine().ToCharArray();

            int[] shotParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int impactRow = shotParams[0];
            int impactColumn = shotParams[1];
            int radius = shotParams[2];

            // Generate matrix
            char[][] matrix = new char[rowsCount][];

            // Fill it with 'snake'
            int snakeIndex = 0;
            for (int i = rowsCount - 1; i >= 0; i--)
            {
                int currentRowEvenless = (rowsCount - 1 - i) % 2;
                char[] currentRow = new char[columnsCount];

                if (currentRowEvenless == 0)
                {
                    for (int j = currentRow.Length - 1; j >= 0; j--)
                    {
                        currentRow[j] = snake[snakeIndex++];
                        snakeIndex = snakeIndex % snake.Length;
                    }
                }
                else
                {
                    for (int j = 0; j < currentRow.Length; j++)
                    {
                        currentRow[j] = snake[snakeIndex++];
                        snakeIndex = snakeIndex % snake.Length;
                    }
                }

                matrix[i] = currentRow;
            }

            // Destroy snake elements
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    double calculatedDistanceFromShot = Math.Sqrt(Math.Pow(i - impactRow, 2) + Math.Pow(j - impactColumn, 2));

                    if (calculatedDistanceFromShot <= radius)
                    {
                        matrix[i][j] = ' ';
                    }
                }
            }

            // Make elements fall
            for (int i = matrix.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == ' ')
                    {
                        int upsearchIndex = i;

                        while (upsearchIndex > 0 && matrix[upsearchIndex][j] == ' ')
                        {
                            upsearchIndex--;
                        }

                        char fallingDownValue = matrix[upsearchIndex][j];
                        matrix[upsearchIndex][j] = ' ';
                        matrix[i][j] = fallingDownValue;
                    }
                }
            }

            // Print the matrix
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }
    }
}