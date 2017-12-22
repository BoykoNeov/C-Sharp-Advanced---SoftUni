namespace LegoBlocks
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[][] firstArray = new string[n][];

            // Read the first array
            for (int i = 0; i < n; i++)
            {
                firstArray[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            // Read the second array, reverse its rows and add it to the first
            for (int i = 0; i < n; i++)
            {
                string[] secondArrayRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] newRow = new string[secondArrayRow.Length + firstArray[i].Length];
                Array.Reverse(secondArrayRow);
                firstArray[i].CopyTo(newRow, 0);
                secondArrayRow.CopyTo(newRow, firstArray[i].Length);
                firstArray[i] = newRow;
            }

            // Check for symmetry
            bool symmetrical = true;
            int firstRowLength = firstArray[0].Length;
            int totalNumberOfCells = firstRowLength;

            for (int i = 1; i < firstArray.Length; i++)
            {
                totalNumberOfCells += firstArray[i].Length;

                if (firstArray[i].Length != firstRowLength)
                {
                    symmetrical = false;
                }
            }

            if (symmetrical)
            {
                for (int i = 0; i < firstArray.Length; i++)
                {
                    Console.Write("[");
                    Console.WriteLine(string.Join(", ", firstArray[i]) + "]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {totalNumberOfCells}");
            }
        }
    }
}