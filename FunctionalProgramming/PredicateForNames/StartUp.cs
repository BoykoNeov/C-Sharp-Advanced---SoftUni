namespace PredicateForNames
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int maxLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            bool isNameShorterOrEqual(string name) => name.Length <= maxLength;

            foreach (string name in names)
            {
                if (isNameShorterOrEqual(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}