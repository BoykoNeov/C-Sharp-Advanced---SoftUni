namespace InfernoIII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var g = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var co = new List<string>();

            string c;
            while ((c = Console.ReadLine()) != "Forge")
            {
                var commandParams = c
                    .Split(';');

                var mc = commandParams[0];
                var sc = commandParams[1];
                var nd = int.Parse(commandParams[2]);

                var nc = $"{sc};{nd}";

                switch (mc)
                {
                    case "Exclude":
                        co.Add(nc);
                        break;
                    case "Reverse":
                        var lastIndexOfGivenCommand = co.LastIndexOf(nc);
                        if (lastIndexOfGivenCommand != -1)
                        {
                            co.RemoveAt(lastIndexOfGivenCommand);
                        }
                        break;
                    default:
                        break;
                }
            }

            List<int> redfsd = new List<int>();

            foreach (var excludeCommand in co)
            {
                var cvfbbgbg = excludeCommand.Split(';')[0];
                var ion = int.Parse(excludeCommand.Split(';')[1]);

                switch (cvfbbgbg)
                {
                    case "Sum Left":
                        redfsd.AddRange(Dec(g, ion));
                        break;
                    case "Sum Right":
                        redfsd.AddRange(Reregrgreb(g, ion));
                        break;
                    case "Sum Left Right":
                        redfsd.AddRange(fbdfbgb(g, ion));
                        break;
                    default:
                        break;
                }
            }

            redfsd = redfsd.Distinct().ToList();

            var oro = new List<int>();

            for (int i = 0; i < g.Length; i++)
            {
                if (!redfsd.Contains(i))
                {
                    oro.Add(g[i]);
                }
            }

            Console.WriteLine(string.Join(" ", oro));
        }

        private static HashSet<int> fbdfbgb(int[] gems, int condition)
        {
            var result = new HashSet<int>();

            for (int i = 0; i < gems.Length; i++)
            {
                var dfgdfb = i == 0 ? 0 : gems[i - 1];
                int fbbgfbgfbf = i == gems.Length - 1 ? 0 : gems[i + 1];

                var bvvfbvbvb = dfgdfb + gems[i] + fbbgfbgfbf;

                if (bvvfbvbvb == condition)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        private static List<int> Reregrgreb(int[] gems, int condition)
        {
            var result = new HashSet<int>();

            for (int i = 0; i < gems.Length; i++)
            {
                int rightElement = i == gems.Length - 1 ? 0 : gems[i + 1];
                var currentSum = gems[i] + rightElement;

                if (currentSum == condition)
                {
                    result.Add(i);
                }
            }

            return result.ToList();
        }

        private static List<int> Dec(int[] gems, int condition)
        {
            var result = new HashSet<int>();

            for (int i = 0; i < gems.Length; i++)
            {
                var leftElement = i == 0 ? 0 : gems[i - 1];
                var currentSum = leftElement + gems[i];

                if (currentSum == condition)
                {
                    result.Add(i);
                }
            }

            return result.ToList();
        }
    }
}