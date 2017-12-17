namespace UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class UniqueUsernamesStartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                usernames.Add(Console.ReadLine());
            }

            foreach (string username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}