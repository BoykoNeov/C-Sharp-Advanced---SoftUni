namespace CryptoBlockchain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numberOfLines; i++)
            {
                sb.Append(Console.ReadLine());
            }

            string text = sb.ToString();
            string pattern = @"(?<opening>{|\[)\D*?(?<digits>\d+)\D*?(?<closing>}|\])";

            MatchCollection matches = Regex.Matches(text, pattern);
            List<char> extractedLetters = new List<char>();

            foreach (Match match in matches)
            {
                if (match.Groups["opening"].Value == "{" && match.Groups["closing"].Value == "]")
                {
                    continue;
                }

                if (match.Groups["opening"].Value == "[" && match.Groups["closing"].Value == "}")
                {
                    continue;
                }

                if (match.Groups["digits"].Value.Length % 3 != 0)
                {
                    continue;
                }

                string digits = match.Groups["digits"].Value;

                for (int i = 0; i < digits.Length / 3; i++)
                {
                    int currentChar = int.Parse(string.Join("", digits.Skip(i * 3).Take(3))) - match.Length;
                    extractedLetters.Add((char)currentChar);
                }
            }

            Console.WriteLine(string.Join("", extractedLetters));
        }
    }
}