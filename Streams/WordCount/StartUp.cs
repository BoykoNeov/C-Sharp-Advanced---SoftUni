namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, int> wordsCounts = new Dictionary<string, int>();
            HashSet<string> words = new HashSet<string>();

            using (StreamReader wordsReader = new StreamReader("../words.txt"))
            {
                string currentWord = wordsReader.ReadLine();
                while (currentWord != null)
                {
                    words.Add(currentWord.ToLower());
                    currentWord = wordsReader.ReadLine();
                }
            }

            using (StreamReader textReader = new StreamReader("../text.txt"))
            {
                char[] separators = " .,-!?:;".ToCharArray();
                string line = string.Empty;

                while ((line = textReader.ReadLine()) != null)
                {
                    string[] lineWords = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string word in words)
                    {
                        foreach (string sentenceWord in lineWords)
                        {
                            if (word.ToLower().Equals(sentenceWord.ToLower()))
                            {
                                if (!wordsCounts.ContainsKey(word))
                                {
                                    wordsCounts.Add(word, 1);
                                }
                                else
                                {
                                    wordsCounts[word]++;
                                }
                            }
                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("../results.txt"))
            {
                foreach (KeyValuePair<string, int> pair in wordsCounts.OrderByDescending(p => p.Value))
                {
                    writer.WriteLine($"{pair.Key} - {pair.Value}");
                }
            }
        }
    }
}