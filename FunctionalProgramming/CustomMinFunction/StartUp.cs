namespace CustomMinFunction
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Func<string, int> ReturnMin = i => i.Split().Select(int.Parse).Min();
            Console.WriteLine(ReturnMin(Console.ReadLine()));
        }
    }
}