namespace BaseNToBase10
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class StartUp
    {
        public static void Main()
        {
            string[] inputs = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            byte baseN = byte.Parse(inputs[0]);
            string number = inputs[1];
            BigInteger output = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                // Built in Math.Pow overflows on very big numbers
                BigInteger baseToTheNthPower = 1;
                for (int j = 0; j < number.Length - 1 - i; j++)
                {
                    baseToTheNthPower *= baseN;
                }

                output += baseToTheNthPower * (number[i] - 48);
            }

            Console.WriteLine(output);
        }
    }
}