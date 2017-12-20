namespace GroupNumbers
{
    using System;
    using System.Linq;
    using System.Text;

    public class GroupNumbersStartUp
    {
        public static void Main()
        {
            int[] inputNumbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            StringBuilder remainderZero = new StringBuilder();
            StringBuilder remainderOne = new StringBuilder();
            StringBuilder remainderTwo = new StringBuilder();

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                int remainder = Math.Abs(inputNumbers[i] % 3);
                switch (remainder)
                {
                    case 0:
                        remainderZero.Append(inputNumbers[i] + " ");
                        break;

                    case 1:
                        remainderOne.Append(inputNumbers[i] + " ");
                        break;

                    case 2:
                        remainderTwo.Append(inputNumbers[i] + " ");
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine(remainderZero.ToString().Trim());
            Console.WriteLine(remainderOne.ToString().Trim());
            Console.WriteLine(remainderTwo.ToString().Trim());
        }
    }
}