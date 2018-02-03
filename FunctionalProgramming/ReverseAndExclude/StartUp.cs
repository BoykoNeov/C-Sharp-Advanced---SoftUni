namespace ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string inputNumbers = Console.ReadLine();
            int divisor = int.Parse(Console.ReadLine());

            Predicate<int> isDivisable = (x) => x % divisor != 0;

            Func<string, List<int>> FilterAndReverse = x => {
                List<int> list = x.Split().Select(int.Parse).ToList();
                list = list.Where(y => isDivisable(y)).ToList();
                list.Reverse();
                return list;
            };

            Console.WriteLine(string.Join(" ", FilterAndReverse(inputNumbers)));
        }
    }
}