namespace TriFunction
{
    using System;
    using System.Linq;

    public class StartUp
    {
        /// <summary>
        /// This is intentionally done in 3 lines...
        /// </summary>
        public static void Main()
        {
            int targetSum = int.Parse(Console.ReadLine());
            Func<string, int, bool> CheckCharSum = (name, sum) => name.Sum(Convert.ToInt32) >= sum;
            Console.WriteLine(Console.ReadLine().Split().Where(n => CheckCharSum(n, targetSum)).FirstOrDefault());
        }
    }
}