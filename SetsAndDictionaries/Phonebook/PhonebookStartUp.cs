namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PhonebookStartUp
    {
        public static void Main()
        {
            string command = string.Empty;
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "search")
            {
                string[] data = input
                    .Split(new char[] { '-' }, StringSplitOptions
                    .RemoveEmptyEntries)
                    .ToArray();

                string name = data[0];
                string number = data[1];

                phonebook[name] = number;
            }

            string searchName = string.Empty;
            while ((searchName = Console.ReadLine()) != "stop")
            {
                if (!phonebook.ContainsKey(searchName))
                {
                    Console.WriteLine($"Contact {searchName} does not exist.");
                }
                else
                {
                    Console.WriteLine($"{searchName} -> {phonebook[searchName]}");
                }
            }
        }
    }
}