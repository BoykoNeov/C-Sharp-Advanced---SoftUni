namespace KnightGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Launcher
    {
        public static void Main()
        {
            List<(int, int)> knigts = new List<(int, int)>();

            int n = int.Parse(Console.ReadLine());

            char[][] board = new char[n][];

            for (int i = 0; i < n; i++)
            {
                board[i] = Console.ReadLine().ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == 'K')
                    {
                        knigts.Add((i, j));
                    }
                }
            }

            Dictionary<(int, int), int> numberOfAttackedKnightByAttackerPosition = new Dictionary<(int, int), int>();
            CountAttackers(numberOfAttackedKnightByAttackerPosition, knigts, board);

            int knightRemoved = 0;

            while (numberOfAttackedKnightByAttackerPosition.Count > 0)
            {
                (int, int) positionToRemove = (numberOfAttackedKnightByAttackerPosition.OrderByDescending(k => k.Value)).First().Key;
                (int x, int y) = positionToRemove;
                numberOfAttackedKnightByAttackerPosition.Clear();
                knigts.Remove((x, y));
                board[x][y] = '0';
                CountAttackers(numberOfAttackedKnightByAttackerPosition, knigts, board);
                knightRemoved++;
            }

            Console.WriteLine(knightRemoved);
        }

        public static void CountAttackers(Dictionary<(int, int), int> attackersDict, List<(int,int)> knights, char[][] board)
        {
            foreach (var knight in knights)
            {
                List<(int, int)> PossibleAttakedPositions = new List<(int, int)>();

                (int x, int y) = knight;
                PossibleAttakedPositions.Add((x + 2, y + 1));
                PossibleAttakedPositions.Add((x + 2, y - 1));
                PossibleAttakedPositions.Add((x - 2, y + 1));
                PossibleAttakedPositions.Add((x - 2, y - 1));

                PossibleAttakedPositions.Add((x + 1, y + 2));
                PossibleAttakedPositions.Add((x - 1, y + 2));
                PossibleAttakedPositions.Add((x + 1, y - 2));
                PossibleAttakedPositions.Add((x - 1, y - 2));

                int attackedByThisKnightCount = 0;

                foreach (var position in PossibleAttakedPositions)
                {
                    (int xPos, int yPos) = position;

                    if (xPos >= 0 && xPos < board.Length && yPos >= 0 && yPos < board.Length)
                    {
                        if (board[xPos][yPos] == 'K')
                        {
                            attackedByThisKnightCount++;
                        }

                        if (attackedByThisKnightCount > 0)
                        {
                            attackersDict[(x, y)] = attackedByThisKnightCount;
                        }
                    }
                }
            }
        }
    }
}