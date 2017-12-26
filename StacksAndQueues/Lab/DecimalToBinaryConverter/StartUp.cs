namespace DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            long inputNumber = long.Parse(Console.ReadLine());
            Stack<sbyte> remainders = new Stack<sbyte>();

            do
            {
                remainders.Push((sbyte)(inputNumber % 2));
                inputNumber = inputNumber / 2;
            }
            while (inputNumber != 0);

            Console.WriteLine(string.Join("", remainders));
        }
    }
}