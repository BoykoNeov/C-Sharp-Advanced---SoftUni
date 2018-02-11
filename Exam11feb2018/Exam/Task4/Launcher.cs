namespace HitList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, string>> victims = new Dictionary<string, Dictionary<string, string>>();

            int targetInfoIndex = int.Parse(Console.ReadLine());
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end transmissions")
            {
                List<string> firstInputStage = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                string[] NameAndFirstParam = firstInputStage[0].Split(new char[] {'=' });
                firstInputStage.RemoveAt(0);

                string name = NameAndFirstParam[0];

                firstInputStage.Insert(0, NameAndFirstParam[1]);

                if (!victims.ContainsKey(name))
                {
                    victims.Add(name, new Dictionary<string, string>());
                }

                foreach (string victimInfo in firstInputStage)
                {
                    string[] victimParams = victimInfo.Split(new char[] { ':' });

                    string key = victimParams[0];
                    string value = victimParams[1];

                    victims[name][key] = value;
                }
            }

            string[] targetNameInput = Console.ReadLine().Split(new char[] {' ' });
            string targetName = targetNameInput[1];

            int infoIndex = 0;
            Console.WriteLine($"Info on {targetName}:");

            foreach (KeyValuePair<string, string> targetInfo in victims[targetName].OrderBy(v => v.Key))
            {
                infoIndex += targetInfo.Key.Length + targetInfo.Value.Length;
                Console.WriteLine($"---{targetInfo.Key}: {targetInfo.Value}");

            }

            Console.WriteLine($"Info index: {infoIndex}");

            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");


            }
            else
            {
                int moreInfoNeeded = targetInfoIndex - infoIndex;
                Console.WriteLine($"Need {moreInfoNeeded} more info.");
            }

        }
    }
}