namespace OddLines
{
    using System;
    using System.IO;

    public static class StartUp
    {
        public static void Main()
        {
            using (StreamReader sr = new StreamReader(@"../text.txt"))
            {
                int lineNumber = 0;
                string line = string.Empty;

                while ((line = sr.ReadLine()) != null)
                {
                    if (lineNumber++ % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}