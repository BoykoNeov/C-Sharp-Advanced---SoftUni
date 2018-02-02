namespace ActionPrint
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            Action<string> Print = i => Console.WriteLine(i);
            foreach (string name in input)
            {
                Print(name);
            }
        }
    }
}