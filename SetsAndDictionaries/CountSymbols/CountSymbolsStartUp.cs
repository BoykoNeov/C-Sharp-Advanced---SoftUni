namespace CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSymbolsStartUp
    {
        public static void Main()
        {
            Dictionary<char, int> charCounts = new Dictionary<char, int>();

            string input = Console.ReadLine();

            foreach (char character in input)
            {
                if (!charCounts.ContainsKey(character))
                {
                    charCounts.Add(character, 1);
                }
                else
                {
                    charCounts[character] += 1;
                }
            }

            foreach (KeyValuePair<char, int> kvp in charCounts.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}