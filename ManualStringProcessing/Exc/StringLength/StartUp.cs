namespace StringLength
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            const int charCount = 20;

            char[] input = Console.ReadLine().Take(charCount).ToArray();
            char[] outputArray = new char[charCount];

            for (int i = 0; i < charCount; i++)
            {
                if (i < input.Length)
                {
                    outputArray[i] = input[i];
                }
                else
                {
                    outputArray[i] = '*';
                }
            }

            string output = new string(outputArray);
            Console.WriteLine(output);
        }
    }
}