namespace MaximalSum
{
    using System;
    using System.Linq;
    using System.Text;

    public class MaximalSumStartUp
    {
        public static void Main()
        {
            short[] input = Console.ReadLine().Split().Select(short.Parse).ToArray();
            int rows = input[0];
            int columns = input[1];

            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[i] = currentRow;
            }

            long maximalSum = long.MinValue;
            Tuple<short, short> startingElement = null;

            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < columns - 2; j++)
                {
                    long currentSum = 0;
                    currentSum += matrix[i][j] + matrix[i][j + 1] + matrix[i][j + 2];
                    currentSum += matrix[i + 1][j] + matrix[i + 1][j + 1] + matrix[i + 1][j + 2];
                    currentSum += matrix[i + 2][j] + matrix[i + 2][j + 1] + matrix[i + 2][j + 2];

                    if (currentSum > maximalSum)
                    {
                        maximalSum = currentSum;
                        //Using short just for fun
                        startingElement = new Tuple<short, short>((short)i, (short)j);
                    }
                }
            }

            Console.WriteLine($"Sum = {maximalSum}");
            for (short i = startingElement.Item1, rowCounter = 0; rowCounter < 3; i++, rowCounter++)
            {
                StringBuilder sb = new StringBuilder();
                for (short j = startingElement.Item2, columnCounter = 0; columnCounter < 3; j++, columnCounter++)
                {
                    sb.Append(matrix[i][j] + " ");
                }

                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }
    }
}