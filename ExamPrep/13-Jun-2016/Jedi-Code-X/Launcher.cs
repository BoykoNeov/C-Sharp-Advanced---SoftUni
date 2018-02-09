namespace Jedi_Code_X
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;

    public class Launcher
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[] lines = new string[n];

            for (int i = 0; i < n; i++)
            {
                lines[i] = Console.ReadLine();
            }

            string jediInputPattern = Console.ReadLine();
            string messageInputPattern = Console.ReadLine();

            int[] jediMessagesIndex = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x) - 1).ToArray();



            //string pattern = string.Format("(?<message>{0}[a-zA-Z0-9]{{{1}}})[^a-zA-Z0-9]?|(?<jedi>{2}[a-zA-Z]{{{3}}})[^a-zA-Z]?", messageInputPattern, messageInputPattern.Length, jediInputPattern, jediInputPattern.Length);

            string pattern = string.Format("(?<message>{0}[a-zA-Z0-9]{{{1}}})(?![a-zA-Z0-9])|(?<jedi>{2}[a-zA-Z]{{{3}}})(?![a-zA-Z])", messageInputPattern, messageInputPattern.Length, jediInputPattern, jediInputPattern.Length);

            List<string> jedis = new List<string>();
            List<string> messages = new List<string>();


            for (int i = 0; i < n; i++)
            {
                MatchCollection matches = Regex.Matches(lines[i], pattern);

                foreach (Match match in matches)
                {
                    if (match.Groups["message"].Value.Length > 0)
                    {
                        messages.Add(match.Groups["message"].Value.Substring(messageInputPattern.Length));
                    }

                    if (match.Groups["jedi"].Value.Length > 0)
                    {
                        jedis.Add(match.Groups["jedi"].Value.Substring(jediInputPattern.Length));
                    }
                }
            }

            Dictionary<string, string> jediMessages = new Dictionary<string, string>();

            int jediIndex = 0;

            for (int i = 0; i < jediMessagesIndex.Length; i++)
            {
                if (jediMessagesIndex[i] < 0 || jediMessagesIndex[i] >= messages.Count)
                {
                    continue;
                }
                else
                {
                    if (jediIndex < jedis.Count)
                    {
                        jediMessages[jedis[jediIndex]] = messages[jediMessagesIndex[i]];
                        jediIndex++;
                    }
                    else
                    {
                        break;
                    }

                }
            }

            foreach (string jedi in jedis)
            {
                if (jediMessages.ContainsKey(jedi))
                {
                    Console.WriteLine($"{jedi} - {jediMessages[jedi]}");
                }
            }
        }
    }
}