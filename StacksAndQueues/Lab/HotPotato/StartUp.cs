namespace HotPotato
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string[] childNames = Console.ReadLine().Split(new char[] {' '} , StringSplitOptions.RemoveEmptyEntries);
            Queue<string> game = new Queue<string>(childNames);
            int n = int.Parse(Console.ReadLine());
            int counter = 1;

            while (game.Count > 1)
            {
                string currentChild = game.Dequeue();

                if (counter == n)
                {
                    Console.WriteLine($"Removed {currentChild}");
                    counter = 1;
                }
                else
                {
                    game.Enqueue(currentChild);
                    counter++;
                }
            }

            Console.WriteLine($"Last is {game.Dequeue()}");
        }
    }
}