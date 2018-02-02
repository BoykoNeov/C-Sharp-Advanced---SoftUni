namespace KnightsOfHonor
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            Action<string> AddSirAndPrint = i => Console.WriteLine("Sir " + i);
            foreach (string name in input)
            {
                AddSirAndPrint(name);
            }
        }
    }
}