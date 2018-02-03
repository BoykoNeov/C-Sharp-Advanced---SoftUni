namespace PredicateParty
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            List<string> guests = Console.ReadLine().Split().ToList();

            string input;

            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] inputs = input.Split();

                string action = inputs[0];
                string condition = inputs[1];
                string argument = inputs[2];

                Predicate<string> currentPredicate;

                if (condition == "StartsWith")
                {
                    currentPredicate = x => x.StartsWith(argument);
                }
                else if(condition == "EndsWith")
                {
                    currentPredicate = x => x.EndsWith(argument);
                }
                else if(condition == "Length")
                {
                    currentPredicate = x => x.Length == int.Parse(argument);
                }
                else
                {
                    throw new ArgumentException("Invalid requirement!");
                }

                Func<int, int> DoubleOrRemove;

                if (action == "Double")
                {
                    DoubleOrRemove = (int index) =>
                    {
                        guests.Insert(index, guests[index]);
                        return index + 2;
                    };
                }
                else if (action == "Remove")
                {
                    DoubleOrRemove = (int index) =>
                    {
                        guests.RemoveAt(index);
                        return index;
                    };
                }
                else
                {
                    throw new ArgumentException("Invalid action!");
                }

                int guestListCount = guests.Count;

                for (int i = 0; i < guestListCount;)
                {
                    if (currentPredicate(guests[i]))
                    {
                        i = DoubleOrRemove(i);
                    }
                    else
                    {
                        i++;
                    }

                    guestListCount = guests.Count;
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}