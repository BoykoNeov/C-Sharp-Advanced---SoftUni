namespace PartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List <string> guests = Console.ReadLine().Split().ToList();

            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string filtersInput;
            while ((filtersInput = Console.ReadLine()) != "Print")
            {
                string[] filterInputs = filtersInput.Split(new char[] { ';' });

                string condition = filterInputs[1];
                string argument = filterInputs[2];

                Predicate<string> currentPredicate;

                if (condition == "Starts with")
                {
                    currentPredicate = x => x.StartsWith(argument);
                }
                else if (condition == "Ends with")
                {
                    currentPredicate = x => x.EndsWith(argument);
                }
                else if (condition == "Length")
                {
                    currentPredicate = x => x.Length == int.Parse(argument);
                }
                else if (condition == "Contains")
                {
                    currentPredicate = x => x.Contains(argument);
                }
                else
                {
                    throw new ArgumentException("Invalid requirement!");
                }

                string operationOnFilters = filterInputs[0];

                if (operationOnFilters == "Add filter")
                {
                    filters.Add(condition + argument, currentPredicate);
                }
                else if (operationOnFilters == "Remove filter")
                {
                    filters.Remove(condition + argument);
                }
                else
                {
                    throw new ArgumentException("Invalid filter operation!");
                }
            }

            List<string> filteredGuests = new List<string>();

            foreach (string guest in guests)
            {
                bool guestIsAllowed = true;

                foreach (Predicate<string> filter in filters.Values)
                {
                    guestIsAllowed = guestIsAllowed && !filter(guest);

                    if (!guestIsAllowed)
                    {
                        break;
                    }
                }

                if (guestIsAllowed)
                {
                    filteredGuests.Add(guest);
                }
            }

            Console.WriteLine(string.Join(" ", filteredGuests));
        }
    }
}