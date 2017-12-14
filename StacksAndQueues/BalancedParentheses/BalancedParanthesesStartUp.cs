namespace BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParanthesesStartUp
    {
        public static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();
            Stack<char> bracketsAndParantheses = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    switch (input[i])
                    {
                        case '{':
                        case '(':
                        case '[':
                            bracketsAndParantheses.Push(input[i]);
                            break;

                        case ')':
                        case '}':
                        case ']':
                            if (input[i] - bracketsAndParantheses.Pop() > 2)
                            {
                                throw new Exception();
                            }
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            Console.WriteLine("YES");
        }
    }
}