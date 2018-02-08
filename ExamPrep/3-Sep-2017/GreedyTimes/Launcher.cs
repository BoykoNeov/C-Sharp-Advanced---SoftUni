namespace GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Launcher
    {
        public static void Main()
        {
            bool goldInput = false;
            bool gemInput = false;
            bool cashInput = false;


            ulong maxBagCapacity = ulong.Parse(Console.ReadLine());

            string[] treasureInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            ulong currentBagContentSize = 0;
            ulong totalGold = 0;
            ulong totalGems = 0;
            ulong totalCash = 0;

            Dictionary<string, ulong> gems = new Dictionary<string, ulong>();
            Dictionary<string, ulong> cash = new Dictionary<string, ulong>();

            for (int i = 0; i < treasureInput.Length - 1; i+= 2)
            {
                string currentItem = treasureInput[i];

                if (currentItem.ToLower() == "gold")
                {
                    ulong goldAmount = ulong.Parse(treasureInput[i + 1]);
                    if ((currentBagContentSize + goldAmount) <= maxBagCapacity)
                    {
                        totalGold += goldAmount;
                        currentBagContentSize += goldAmount;
                        goldInput = true;
                    }

                    continue;
                }

                if (currentItem.Length >= 4 && currentItem.Substring(currentItem.Length - 3, 3).ToLower() == "gem")
                {
                    ulong currentGemAmount = ulong.Parse(treasureInput[i + 1]);
                    if ((currentBagContentSize + currentGemAmount) <= maxBagCapacity && totalGems + currentGemAmount <= totalGold)
                    {
                        gemInput = true;
                        if (!gems.ContainsKey(currentItem))
                        {
                            gems.Add(currentItem, 0);
                        }

                        totalGems += currentGemAmount;
                        currentBagContentSize += currentGemAmount;
                        gems[currentItem] += currentGemAmount;
                    }

                    continue;
                }

                if (currentItem.Length == 3)
                {
                    ulong currentCashAmount = ulong.Parse(treasureInput[i + 1]);

                    if (currentBagContentSize + currentCashAmount <= maxBagCapacity && totalCash + currentCashAmount <= totalGems)
                    {
                        cashInput = true;
                        if (!cash.ContainsKey(currentItem))
                        {
                            cash.Add(currentItem, 0);
                        }

                        totalCash += currentCashAmount;
                        currentBagContentSize += currentCashAmount;
                        cash[currentItem] += currentCashAmount;
                    }
                }
            }

            if (totalGold > 0 || goldInput)
            {
                Console.WriteLine($"<Gold> ${totalGold}");
                Console.WriteLine($"##Gold - {totalGold}");
            }

            if (totalGems > 0 || gemInput)
            {
                Console.WriteLine($"<Gem> ${totalGems}");

                foreach (KeyValuePair<string, ulong> gem in gems.OrderByDescending(g => g.Key).ThenBy(g => g.Value))
                {
                    Console.WriteLine($"##{gem.Key} - {gem.Value}");
                }
            }

            if (totalCash > 0 || cashInput)
            {
                Console.WriteLine($"<Cash> ${totalCash}");

                foreach (KeyValuePair<string, ulong> currency in cash.OrderByDescending(c => c.Key).ThenBy(c => c.Value))
                {
                    Console.WriteLine($"##{currency.Key} - {currency.Value}");
                }
            }
        }
    }
}