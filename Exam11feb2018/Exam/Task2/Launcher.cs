namespace Sneaking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Launcher
    {
        public static void Main()
        {
            int columnsCount = int.Parse(Console.ReadLine());
            string[][] room = new string[columnsCount][];

            for (int i = 0; i < columnsCount; i++)
            {
                room[i] = Console.ReadLine().Select(x => x.ToString()).ToArray();
            }

            Queue<char> samMoves = new Queue<char>(Console.ReadLine().ToCharArray());

            bool samAlive = true;
            bool svaAllive = true;

            while (samAlive && svaAllive)
            {
                // move enemies
                for (int i = 0; i < columnsCount; i++)
                {
                    for (int j = 0; j < room[i].Length; j++)
                    {
                        if (room[i][j] == "d")
                        {
                            bool moved = false;

                            if (j == 0)
                            {
                                room[i][j] = "b";
                                moved = true;
                            }

                            if (!moved)
                            {
                                room[i][j] = ".";
                                room[i][j - 1] = "d";
                                break;
                            }
                        }
                        else if (room[i][j] == "b")
                        {
                            bool moved = false;

                            if (j == room[i].Length - 1)
                            {
                                room[i][j] = "d";
                                moved = true;
                            }

                            if (!moved)
                            {
                                room[i][j] = ".";
                                room[i][j + 1] = "b";
                                break;
                            }
                        }
                    }
                }

                // Locate Sam
                int samX = 0;
                int samY = 0;

                for (int i = 0; i < columnsCount; i++)
                {
                    for (int j = 0; j < room[i].Length; j++)
                    {
                        if (room[i][j] == "S")
                        {
                            samX = i;
                            samY = j;
                        }
                    }
                }

                samAlive = SamAliveAfterEnemyAction(room[samX], samY);

                //Move sam
                if (samAlive)
                {
                    room[samX][samY] = ".";

                    char currentMove = samMoves.Dequeue();

                    if (currentMove == 'U')
                    {
                        samX--;
                    }
                    else if (currentMove == 'D')
                    {
                        samX++;
                    }
                    else if (currentMove == 'R')
                    {
                        samY++;
                    }
                    else if (currentMove == 'L')
                    {
                        samY--;
                    }

                    room[samX][samY] = "S";
                    svaAllive = SvanidzeAliveAftereSamAction(room[samX]);
                }


                //test
                //Console.WriteLine("***********");
                //PrintRoom(room);
                //Console.WriteLine("***********");
            }

            // One of the two must be death by now
            if (!samAlive)
            {
                int deathX = LocateDeathX(room);
                int deathY = LocateDeathY(room);

                Console.WriteLine($"Sam died at {deathX}, {deathY}");
                PrintRoom(room);
            }
            else
            {
                Console.WriteLine("Nikoladze killed!");
                PrintRoom(room);
            }
        }

        private static void PrintRoom(string[][] room)
        {
            for (int i = 0; i < room.Length; i++)
            {
                Console.WriteLine(string.Join("", room[i]));
            }
        }

        private static int LocateDeathX(string[][] room)
        {
            for (int i = 0; i < room.Length; i++)
            {
                for (int j = 0; j < room[i].Length; j++)
                {
                    if (room[i][j] == "X")
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        private static int LocateDeathY(string[][] room)
        {
            for (int i = 0; i < room.Length; i++)
            {
                for (int j = 0; j < room[i].Length; j++)
                {
                    if (room[i][j] == "X")
                    {
                        return j;
                    }
                }
            }

            return -1;
        }

        private static bool SvanidzeAliveAftereSamAction(string[] row)
        {
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] == "N")
                {
                    row[i] = "X";
                    return false;
                }
            }

            return true;
        }

        private static bool SamAliveAfterEnemyAction(string[] row, int samColumn)
        {
            for (int i = samColumn; i < row.Length; i++)
            {
                if (row[i] == "d")
                {
                    row[samColumn] = "X";
                    return false;
                }
            }

            for (int i = samColumn; i >= 0; i--)
            {
                if (row[i] == "b")
                {
                    row[samColumn] = "X";
                    return false;
                }
            }

            return true;
        }

        //private static bool CheckForSam(string[] row, int i, int j)
        //{
        //    string facing = row[j];
        //    if (facing == "b")
        //    {
        //        for (int x = j; x < row.Length; x++)
        //        {
        //            if (row[x] == "S")
        //            {
        //                row[x] = "X";
        //                return true;
        //            }
        //        }
        //    }
        //    else if (facing == "d")
        //    {
        //        for (int x = j; x >= 0; x--)
        //        {
        //            if (row[x] == "S")
        //            {
        //                row[x] = "X";
        //                return true;
        //            }
        //        }
        //    }

        //    return false;
        //}
    }
}