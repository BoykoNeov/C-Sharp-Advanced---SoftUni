namespace Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] matrixParamsInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = matrixParamsInput[0];
            int colsCount = matrixParamsInput[1];

            int?[][] matrix = new int?[rowsCount][];

            int counter = 1;
            for (int i = 0; i < rowsCount; i++)
            {
                int?[] currentRow = new int?[colsCount];

                for (int j = 0; j < colsCount; j++)
                {
                    currentRow[j] = counter++;
                }

                matrix[i] = currentRow;
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Nuke it from orbit")
            {
                int[] shot = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                long shotRow = shot[0];
                long shotColumn = shot[1];
                long shotPower = shot[2];

                if (IsWithinMatrix(shotRow, shotColumn, matrix))
                {
                    matrix[shotRow][shotColumn] = null;
                }

                for (int i = 1; i <= shotPower; i++)
                {
                    if (IsWithinMatrix(shotRow - i, shotColumn, matrix))
                    {
                        matrix[shotRow - i][shotColumn] = null;
                    }

                    if (IsWithinMatrix(shotRow + i, shotColumn, matrix))
                    {
                        matrix[shotRow + i][shotColumn] = null;
                    }

                    if (IsWithinMatrix(shotRow, shotColumn - i, matrix))
                    {
                        matrix[shotRow][shotColumn - i] = null;
                    }

                    if (IsWithinMatrix(shotRow, shotColumn + i, matrix))
                    {
                        matrix[shotRow][shotColumn + i] = null;
                    }
                }

                List<int?[]> newArrayAncestor = new List<int?[]>();

                for (int i = 0; i < matrix.Length; i++)
                {
                    List<int?> newRow = new List<int?>();

                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        if (matrix[i][j] != null)
                        {
                            newRow.Add(matrix[i][j]);
                        }
                    }
                    
                    if (newRow.Count > 0)
                    {
                        newArrayAncestor.Add(newRow.ToArray());
                    }
                }

                matrix = newArrayAncestor.ToArray();
                GC.Collect();
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]).Trim());
            }
        }

        private static bool IsWithinMatrix<T>(long row, long col, T[][] matrix)
        {
            if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}