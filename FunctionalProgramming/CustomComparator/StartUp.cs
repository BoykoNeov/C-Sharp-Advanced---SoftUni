namespace CustomComparator
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(arr, new Comparator());
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}