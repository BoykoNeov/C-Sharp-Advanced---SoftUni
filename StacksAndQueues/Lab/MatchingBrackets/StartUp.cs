namespace MatchingBrackets
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Stack<int> openingBracketsIndexes = new Stack<int>();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    openingBracketsIndexes.Push(i);
                }

                if (input[i] == ')')
                {
                    int startIndex = openingBracketsIndexes.Pop();
                    sb.AppendLine(input.Substring(startIndex, (i - startIndex + 1)));
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}