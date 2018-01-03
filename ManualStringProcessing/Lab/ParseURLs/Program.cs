namespace ParseURLs
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string[] splitByProtocol = input.Split(new string[] { "://" }, StringSplitOptions.None);

            if (splitByProtocol.Length != 2)
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                string[] splitByServer = splitByProtocol[1].Split(new char[] { '/' }, StringSplitOptions.None);

                if (splitByServer.Length < 2)
                {
                    Console.WriteLine("Invalid URL");
                }
                else
                {
                    Console.WriteLine($"Protocol = {splitByProtocol[0]}");
                    Console.WriteLine($"Server = {splitByServer[0]}");
                    Console.WriteLine($"Resources = {string.Join("/", splitByServer.Skip(1))}");
                }
            }
        }
    }
}