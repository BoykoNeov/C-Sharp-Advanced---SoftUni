namespace StringMatrixRotation
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            int rotation = int.Parse(input[1]) % 360;

            List<char[]> inputRawMatrix = new List<char[]>();

            string matrixLines = string.Empty;

            int longestRow = 0;
            int rowsCount = 0;

            while ((matrixLines = Console.ReadLine()) != "END")
            {
                rowsCount++;
                inputRawMatrix.Add(matrixLines.ToCharArray());

                if (matrixLines.Length > longestRow)
                {
                    longestRow = matrixLines.Length;
                }

            }

            char[][] matrix = new char[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                // Super important to fill the matrix with empty spaces, then leave default values instead - in that case Judge gives only 40/100
                matrix[i] = Enumerable.Repeat(' ', longestRow).ToArray();

                for (int j = 0; j < inputRawMatrix[i].Length; j++)
                {
                    matrix[i][j] = inputRawMatrix[i][j];
                }
            }

            StringBuilder sb = new StringBuilder();

            switch (rotation)
            {
                case 0:
                    for (int i = 0; i < rowsCount; i++)
                    {
                        for (int j = 0; j < longestRow; j++)
                        {
                            sb.Append(matrix[i][j]);
                        }

                        sb.Append(Environment.NewLine);
                    }

                    Console.Write(sb.ToString());
                    break;

                case 90:
                    for (int j = 0; j < longestRow; j++)
                    {
                        for (int i = rowsCount - 1; i >= 0; i--)
                        {
                            sb.Append(matrix[i][j]);
                        }

                        sb.Append(Environment.NewLine);
                    }

                    Console.Write(sb.ToString());
                    break;

                case 180:
                    for (int i = rowsCount - 1; i >= 0; i--)
                    {
                        for (int j = longestRow - 1; j >= 0; j--)
                        {
                            sb.Append(matrix[i][j]);
                        }

                        sb.Append(Environment.NewLine);
                    }

                    Console.Write(sb.ToString());
                    break;

                case 270:
                    for (int j = longestRow - 1; j >= 0; j--)
                    {
                        for (int i = 0; i < rowsCount; i++)
                        {
                            sb.Append(matrix[i][j]);
                        }

                        sb.Append(Environment.NewLine);
                    }

                    Console.Write(sb.ToString());
                    break;

                default:
                    break;
            }
        }
    }
}