namespace FormattingNumbers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] inputs = Console.ReadLine().Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int a = int.Parse(inputs[0]);
            decimal b = decimal.Parse(inputs[1]);
            decimal c = decimal.Parse(inputs[2]);

            string hexValue = a.ToString("X");
            string binValue = new string(Convert.ToString(a, 2).Take(10).ToArray()).PadLeft(10, '0');

            Console.WriteLine("|{0,-10}|{1,10}|{2,10:f2}|{3,-10:f3}|", hexValue, binValue, b, c);

        }
    }
}