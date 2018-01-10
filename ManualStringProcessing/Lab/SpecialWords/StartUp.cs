namespace SpecialWords
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            char[] separators = new char[] { '(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' ' };
            string[] words = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            string[] textWords = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                wordCounts[word] = 0;
            }

            foreach (string textWord in textWords)
            {
                if (wordCounts.ContainsKey(textWord))
                {
                    wordCounts[textWord]++;
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string,int> wordCount in wordCounts)
            {
                sb.AppendLine(wordCount.Key + " - " + wordCount.Value);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}