namespace RadioactiveMutantVampireBunnies
{
    using System;
    using System.Collections.Generic;
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
                lair[i] = Console.ReadLine().Trim().Select(x => new string(x, 1)).ToArray();
            }

            List<char> playerMoves = Console.ReadLine().ToCharArray().ToList();
            playerMoves.Reverse();

            bool gameEnded = false;
            bool playerAlive = true;

            (int PlayerRow, int PlayerColumn) lastPlayerPosition = (-1, -1);

            while (!gameEnded)
            {
                // Locate player
                lastPlayerPosition = LocatePlayer(lair);
                (int playerRow, int playerColumn) = lastPlayerPosition;

                // Move player

                char movingDirection = playerMoves[playerMoves.Count - 1];

                // This should be safe, becasue no stalemates are allowed as per definition
                playerMoves.RemoveAt(playerMoves.Count - 1);

                lair[playerRow][playerColumn] = ".";

                switch (movingDirection)
                {
                    case 'L':
                        playerColumn--;
                        break;

                    case 'R':
                        playerColumn++;
                        break;

                    case 'U':
                        playerRow--;
                        break;

                    case 'D':
                        playerRow++;
                        break;

                    default:
                        break;
                }

                // Check if player has escaped the lair
                if (playerColumn >= colsCount || playerColumn < 0 || playerRow >= rowsCount || playerRow < 0)
                {
                    gameEnded = true;
                }
                // Check if player has hit a bunny
                else if (lair[playerRow][playerColumn] == "B")
                {
                    gameEnded = true;
                    playerAlive = false;
                    lastPlayerPosition.PlayerRow = playerRow;
                    lastPlayerPosition.PlayerColumn = playerColumn;
                }
                else
                {
                    lair[playerRow][playerColumn] = "P";
                }

                // Grow Bunnies
                GrowBunnies(lair);

                // Check if player has died during bunny growth
                if (!gameEnded && playerAlive)
                {
                    if (lair[playerRow][playerColumn] == "B")
                    {
                        gameEnded = true;
                        playerAlive = false;
                        lastPlayerPosition.PlayerRow = playerRow;
                        lastPlayerPosition.PlayerColumn = playerColumn;
                    }
                }
            }

            foreach (string[] row in lair)
            {
                Console.WriteLine(string.Join("", row));
            }

            if (playerAlive)
            {
                Console.WriteLine($"won: {lastPlayerPosition.PlayerRow} {lastPlayerPosition.PlayerColumn}");
            }
            else
            {
                Console.WriteLine($"dead: {lastPlayerPosition.PlayerRow} {lastPlayerPosition.PlayerColumn}");
            }
        }

        private static void GrowBunnies(string[][] lair)
        {
            List<int[]> bunnies = new List<int[]>();
            for (int i = 0; i < lair.Length; i++)
            {
                for (int j = 0; j < lair[i].Length; j++)
                {
                    if (lair[i][j] == "B")
                    {
                        bunnies.Add(new int[2] { i, j });
                    }
                }
            }

            foreach (int[] bunnyPosition in bunnies)
            {
                if (bunnyPosition[0] > 0)
                {
                    lair[bunnyPosition[0] - 1][bunnyPosition[1]] = "B";
                }

                if (bunnyPosition[0] < lair.Length - 1)
                {
                    lair[bunnyPosition[0] + 1][bunnyPosition[1]] = "B";
                }

                if (bunnyPosition[1] > 0)
                {
                    lair[bunnyPosition[0]][bunnyPosition[1] - 1] = "B";
                }

                if (bunnyPosition[1] < lair[0].Length - 1)
                {
                    lair[bunnyPosition[0]][bunnyPosition[1] + 1] = "B";
                }
            }
        }

        private static (int playerRow, int playerColumn) LocatePlayer(string[][] lair)
        {
            for (int i = 0; i < lair.Length; i++)
            {
                for (int j = 0; j < lair[i].Length; j++)
                {
                    if (lair[i][j] == "P")
                    {
                        return (i, j);
                    }
                }
            }

            return (-1, -1);
        }
    }
}