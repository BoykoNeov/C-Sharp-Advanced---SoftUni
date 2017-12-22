namespace RadioactiveMutantVampireBunnies
{
    using System;
    using System.Linq;

    public class StartUp
    {
       public static void Main()
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = input[0];
            int colsCount = input[1];

            string[][] lair = new string[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                lair[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            string playerMoves = Console.ReadLine();

        }
    }
}