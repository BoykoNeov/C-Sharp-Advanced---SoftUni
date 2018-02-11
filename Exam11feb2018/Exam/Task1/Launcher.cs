namespace KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
       public static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            // bulets go back to front
            int[] bulletsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int initialBulletsCount = bulletsInput.Length;

            // lock go front to back
            int[] locksInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> bullets = new Stack<int>(bulletsInput);
            Queue<int> locks = new Queue<int>(locksInput);

            int intelligenceValue = int.Parse(Console.ReadLine());

            int currentBarrelSize = gunBarrelSize;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                int bullet = bullets.Pop();
                currentBarrelSize--;

                int currentLock = locks.Peek();

                if (currentLock < bullet)
                {
                    Console.WriteLine("Ping!");
                }
                else
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }

                if (currentBarrelSize == 0 && bullets.Count > 0)
                {
                    currentBarrelSize = gunBarrelSize;
                    Console.WriteLine("Reloading!");
                }
            }

            if (bullets.Count == 0 && locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                long spentOnBullets = (initialBulletsCount - bullets.Count) * bulletPrice;
                long moneyLeft = intelligenceValue - spentOnBullets;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyLeft}");
            }
        }
    }
}