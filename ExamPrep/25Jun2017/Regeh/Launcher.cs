namespace Regeh
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    public class Launcher
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string patternBrackets = @"\[[^\[\]\s]+<(\d+)REGEH(\d+)>[^\[\]\s]+\]";
            MatchCollection brackets = Regex.Matches(input, patternBrackets);

            List<int> indexes = new List<int>();

            foreach (Match m in brackets)
            {
                indexes.Add(int.Parse(m.Groups[1].ToString()));
                indexes.Add(int.Parse(m.Groups[2].ToString()));
            }

            StringBuilder sw = new StringBuilder();
            int aggregate = 0;

            foreach (int index in indexes)
            {
                aggregate += index;
                sw.Append(input[aggregate % (input.Length - 1)]);
            }

            Console.WriteLine(sw.ToString());
        }
    }
}