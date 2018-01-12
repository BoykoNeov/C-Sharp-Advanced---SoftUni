namespace ConcatenateStrings
{
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                sb.Append(Console.ReadLine() + " ");
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}