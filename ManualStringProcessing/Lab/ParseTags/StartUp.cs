namespace ParseTags
{
    using System;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            const string Pattern = @"(<upcase>)(.*?)(<\/upcase>)";
            Regex regex = new Regex(Pattern);
            string input = Console.ReadLine();
            
            string replaced = Regex.Replace(input, Pattern, m => m.Groups[2].Value.ToUpper());
            Console.WriteLine(replaced);
        }
    }
}