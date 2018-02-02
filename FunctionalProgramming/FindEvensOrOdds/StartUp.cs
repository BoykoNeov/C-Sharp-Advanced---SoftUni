namespace FindEvensOrOdds
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            Predicate<long> EvenOrOdd;

            long[] limits = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            long lowerLimit = limits[0];
            long upperLimit = limits[1];

            string condition = Console.ReadLine();

            if (condition == "even")
            {
                EvenOrOdd = x => x % 2 == 0;
            }
            else if(condition == "odd")
            {
                EvenOrOdd = x => x % 2 != 0;
            }
            else
            {
                throw new ArgumentException("No valid even or odd condition given");
            }

            List<long> result = new List<long>();

            for (long i = lowerLimit; i <= upperLimit; i++)
            {
                if (EvenOrOdd(i))
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
        }
    }
}