namespace MatrixOfPalindromes
{
    using System;
    using System.Linq;

    public class MatrixOfPalindromesStartUp
    {
        public static void Main()
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            sbyte[] input = Console.ReadLine().Split().Select(sbyte.Parse).ToArray();
            sbyte rowsCount = input[0];
            sbyte columnsCount = input[1];

            string[][] matrix = new string[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                string[] row = new string[columnsCount];
                for (int j = 0; j < columnsCount; j++)
                {
                    row[j] = alphabet[i].ToString() + alphabet[i + j] + alphabet[i];
                }

                matrix[i] = row;
            }

            foreach (string[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}