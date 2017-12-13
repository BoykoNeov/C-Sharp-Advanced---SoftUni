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

                        // It would have been so much better if all types of opening and closing parantheses were separeted by a constant in the ASCII table...
                        case ')':
                            if (bracketsAndParantheses.Pop() != input[i] - 1)
                            {
                                throw new Exception();
                            }
                            break;

                        case '}':
                        case ']':
                            if (bracketsAndParantheses.Pop() != input[i] - 2)
                            {
                                throw new Exception();
                            }
                            break;

                        default:
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