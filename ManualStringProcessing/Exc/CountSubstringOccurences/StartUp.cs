namespace CountSubstringOccurences
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string substring = Console.ReadLine().ToLower();
            int substringCount = 0;
            int currentSubstringIndex = 0;


            do
            {
                currentSubstringIndex = text.IndexOf(substring, currentSubstringIndex);
                currentSubstringIndex++;

                if (currentSubstringIndex > 0)
                {
                    substringCount++;
                }
            }
            while (currentSubstringIndex > 0 && currentSubstringIndex < text.Length);

            Console.WriteLine(substringCount);
        }
    }
}