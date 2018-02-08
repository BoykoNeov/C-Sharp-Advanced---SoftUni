namespace CryptoMaster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Launcher
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int longestSequence = 1;
            HashSet<int> passedNumbers = new HashSet<int>();

            // Starting number
            for (int i = 0; i < numbers.Count; i++)
            {
                // Size of the step
                for (int j = 1; j < numbers.Count; j++)
                {
                    int currentLongestSequence = 1;

                    int iterator = i;

                    while (true)
                    {
                        int currentNumber = numbers[iterator % numbers.Count];
                        iterator += j;

                        int nextNumber = numbers[(iterator) % numbers.Count];

                        if (nextNumber <= currentNumber)
                        {
                            break;
                        }

                        currentLongestSequence++;
                    }

                    if (currentLongestSequence > longestSequence)
                    {
                        longestSequence = currentLongestSequence;
                    }
                }
            }

            Console.WriteLine(longestSequence);
        }
    }
}