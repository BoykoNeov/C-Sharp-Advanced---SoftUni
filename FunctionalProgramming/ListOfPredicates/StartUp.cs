namespace ListOfPredicates
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int upperLimit = int.Parse(Console.ReadLine());
            HashSet<int> divisors = new HashSet<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            List<Predicate<int>> listOfPredicates = new List<Predicate<int>>();

            foreach (int divisor in divisors)
            {
                Predicate<int> newPredicate = x => x % divisor == 0;
                listOfPredicates.Add(newPredicate);
            }

            for (int i = 1; i <= upperLimit; i++)
            {
                bool isDivisableByAll = true;

                foreach (Predicate<int> check in listOfPredicates)
                {
                    isDivisableByAll = isDivisableByAll && check(i);
                }

                if (isDivisableByAll)
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
        }
    }
}