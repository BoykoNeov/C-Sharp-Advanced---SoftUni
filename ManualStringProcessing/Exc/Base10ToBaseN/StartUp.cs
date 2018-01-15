namespace Base10ToBaseN
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            BigInteger[] inputs = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse).ToArray();

            byte baseN = (byte)inputs[0];
            BigInteger number = inputs[1];

            byte remainder = 0;
            Stack<byte> digits = new Stack<byte>();

            while (number != 0)
            {
                remainder = (byte)(number % baseN);
                digits.Push(remainder);
                number = number / baseN;
            }

            StringBuilder output = new StringBuilder();

            while (digits.Count > 0)
            {
                output.Append(digits.Pop());
            }

            Console.WriteLine(output.ToString());
        }
    }
}