namespace SimpleTextEditor
{
    using System;
    using System.Collections.Generic;

    public class SimpleTextEditorStartUp
    {
        public static void Main()
        {
            Stack<string> text = new Stack<string>();
            text.Push(string.Empty);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputCommandCodes = Console.ReadLine().Split();

                switch (inputCommandCodes[0])
                {
                    case "1":
                        text.Push(text.Peek() + inputCommandCodes[1]);
                        break;

                    case "2":
                        string currentText = text.Peek();
                        text.Push(currentText.Substring(0, currentText.Length - int.Parse(inputCommandCodes[1])));
                        break;

                    case "3":
                        Console.WriteLine(text.Peek()[int.Parse(inputCommandCodes[1]) - 1]);
                        break;

                    case "4":
                        text.Pop();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}