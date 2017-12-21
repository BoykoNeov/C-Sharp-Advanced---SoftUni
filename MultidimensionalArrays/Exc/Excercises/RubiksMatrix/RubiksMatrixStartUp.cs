namespace RubiksMatrix
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class RubiksMatrixStartUp
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = input[0];
            int columnsCount = input[1];

            int[][] matrix = new int[rowsCount][];

            int counter = 1;
            for (int i = 0; i < rowsCount; i++)
            {
                int[] currentRow = new int[columnsCount];
                for (int j = 0; j < columnsCount; j++)
                {
                    currentRow[j] = counter++;
                }

                matrix[i] = currentRow;
            }

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int rowOrCol = int.Parse(commandParams[0]);
                string direction = commandParams[1];
                int movesCount = int.Parse(commandParams[2]) % columnsCount;

                switch (direction)
                {
                    case "up":
                        RotateVertically(matrix, rowOrCol, matrix.Length - movesCount);
                        break;

                    case "down":
                        RotateVertically(matrix, rowOrCol, movesCount);
                        break;

                    case "left":
                        matrix[rowOrCol] = RotateHorizontally(matrix[rowOrCol], matrix[rowOrCol].Length - movesCount);
                        break;

                    case "right":
                        matrix[rowOrCol] = RotateHorizontally(matrix[rowOrCol], movesCount);
                        break;

                    default:
                        break;
                }
            }

            Dictionary<int, int[]> positions = new Dictionary<int, int[]>(columnsCount * rowsCount);

            // Runs through the matrix and saves each integer coordinates into a dictionary
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    positions[matrix[i][j]] = new int[2];
                    positions[matrix[i][j]][0] = i;
                    positions[matrix[i][j]][1] = j;
                }
            }

            counter = 1;

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    int numberAtCurrentPosition = matrix[i][j];

                    if (numberAtCurrentPosition == counter)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        int[] saughtNumberPositionos = positions[counter];
                        Console.WriteLine($"Swap ({i}, {j}) with ({saughtNumberPositionos[0]}, {saughtNumberPositionos[1]})");
                        matrix[i][j] = counter;
                        positions[counter][0] = i;
                        positions[counter][1] = j;

                        matrix[saughtNumberPositionos[0]][saughtNumberPositionos[1]] = numberAtCurrentPosition;
                        positions[numberAtCurrentPosition][0] = saughtNumberPositionos[0];
                        positions[numberAtCurrentPosition][1] = saughtNumberPositionos[1];
                    }

                    counter++;
                }
            }
        }

        private static void RotateVertically<T>(T[][] matrix, int rowOrCol, int movesCount)
        {
            // T[][] result = (T[][])matrix.Clone();
            T[] movedColumn = new T[matrix.Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                movedColumn[i] = matrix[i][rowOrCol];
            }

            movedColumn = RotateHorizontally(movedColumn, movesCount);

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i][rowOrCol] = movedColumn[i];
            }
        }

        private static T[] RotateHorizontally<T>(T[] matrixRow, int moves)
        {
            moves = moves % matrixRow.Length;

            T[] newRow = new T[matrixRow.Length];

            for (int i = 0; i < matrixRow.Length; i++)
            {
                newRow[i] = matrixRow[(i + matrixRow.Length - moves) % matrixRow.Length];
            }

            return newRow;
        }
    }
}