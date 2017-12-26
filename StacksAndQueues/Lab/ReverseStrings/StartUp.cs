namespace ReverseStrings
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            Stack<char> stack = new Stack<char>(Console.ReadLine().ToCharArray());

            StringBuilder sb = new StringBuilder();

            while (stack.Count > 0)
            {
                sb.Append(stack.Pop());
            }

            Console.WriteLine(sb.ToString());
        }
    }
}