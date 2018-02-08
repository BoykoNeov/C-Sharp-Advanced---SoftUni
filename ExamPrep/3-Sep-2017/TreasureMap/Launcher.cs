namespace TreasureMap
{
    using System;
    using System.Text.RegularExpressions;

    public class Launcher
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            // this does not work
            //   string pattern = @"(!|#)[^!#]*?\b(?<street>[A-Za-z]{4})\b[^!#]*[^\d](?<number>\d{3})-(?<password>\d{6}|\d{4})(?:[^\d!#]*)?(?!\1)(#|!)";

            string pattern =      @"(!|#)[^!#]*?\b(?<street>[A-Za-z]{4})\b[^!#]*[^\d](?<number>\d{3})-(?<password>\d{6}|\d{4})(?:[^\d!#][^!#]*)?(?!\1)(#|!)";

            for (int i = 0; i < n; i++)
            {
                MatchCollection matches = Regex.Matches(Console.ReadLine(), pattern);

                if (matches.Count > 0)
                {
                    Match a = matches[matches.Count / 2];
                    Console.WriteLine($"Go to str. {a.Groups["street"].Value.ToString()} {a.Groups["number"].Value.ToString()}. Secret pass: {a.Groups["password"].Value.ToString()}.");
                }
            }
        }
    }
}