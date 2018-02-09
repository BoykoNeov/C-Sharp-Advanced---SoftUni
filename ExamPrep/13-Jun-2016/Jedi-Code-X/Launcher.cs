namespace Jedi_Code_X
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Launcher
    {
        public static void Main()
        {
            StringBuilder sb = new StringBuilder();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                sb.Append(Console.ReadLine());
            }

            string jediInputPattern = Console.ReadLine();
            string messageInputPattern = Console.ReadLine();

            int[] jediMessagesIndex = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x) - 1).ToArray();

            string pattern = string.Format("(?<jedi>{0}[a-zA-Z]{{{1}}})(?![a-zA-Z])|(?<message>{2}[a-zA-Z0-9]{{{3}}})(?![a-zA-Z0-9])", jediInputPattern, jediInputPattern.Length, messageInputPattern, messageInputPattern.Length);

            List<string> jedis = new List<string>();
            List<string> messages = new List<string>();

            string messageToDecode = sb.ToString();

            MatchCollection matches = Regex.Matches(messageToDecode, pattern);

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