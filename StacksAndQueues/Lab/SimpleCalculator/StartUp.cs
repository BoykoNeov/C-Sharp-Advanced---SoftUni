namespace SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Stack<string> input = new Stack<string>(Console.ReadLine().Split().Reverse());
            decimal result = 0;

            sbyte multiplier = 1;
            while (input.Count > 0)
            {
                if (input.Peek() == "+")
                {
                    multiplier = 1;
                    input.Pop();
                }
                else if(input.Peek() == "-")
                {
                    multiplier = -1;
                    input.Pop();
                }
                else if (decimal.TryParse(input.Pop(), out decimal number))
                {
                    result += number * multiplier;
                }
            }

            Console.WriteLine(result);

        }
    }
}