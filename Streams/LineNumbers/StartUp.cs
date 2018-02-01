namespace LineNumbers
{
    using System;
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            using (StreamReader sr = new StreamReader(@"../text.txt"))
            {
                using (StreamWriter sw = new StreamWriter("../target.txt"))
                {
                    int lineNumber = 1;
                    string line = string.Empty;

                    while ((line = sr.ReadLine()) != null)
                    {
                        sw.WriteLine($"Line {lineNumber}: {line}");
                        lineNumber++;
                    }
                }
            }
        }
    }
}