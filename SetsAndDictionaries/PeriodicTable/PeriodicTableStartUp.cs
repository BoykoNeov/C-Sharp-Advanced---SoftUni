namespace PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PeriodicTableStartUp
    {
       public static void Main()
        {
            int inputSize = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();

            for (int i = 0; i < inputSize; i++)
            {
                elements.UnionWith(Console.ReadLine().Split());
            }

            Console.WriteLine(string.Join(" ", elements.OrderBy(e => e)));
        }
    }
}