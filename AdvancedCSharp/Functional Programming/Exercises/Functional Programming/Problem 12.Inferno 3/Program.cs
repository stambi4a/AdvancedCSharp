namespace Problem_12.Inferno_3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var gemPowers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var listOfFilters = new Dictionary<string, List<int>>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("Forge"))
                {
                    break;
                }

                var commands = input.Trim().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var command = commands[0];
                var filterName = commands[1];
                var gemPower = int.Parse(commands[2]);
                Action<Dictionary<string, List<int>>, int, string, string> workWithFilters = WorkWithFilters;
                workWithFilters(listOfFilters, gemPower, command, filterName);
            }

            Func<Dictionary<string, List<int>>, List<int>, List<int>> applyFilters = ApplyFilters;
            var gemsLeft = applyFilters(listOfFilters, gemPowers);
            Action<IEnumerable<int>> printGemPowers = PrintGemPowers;
            printGemPowers(gemsLeft);
        }

        private static void PrintGemPowers(IEnumerable<int> gemPowers)
        {
            if (gemPowers.Any())
            {
                Console.WriteLine(string.Join(" ", gemPowers));
            }
        }


        private static void WorkWithFilters(Dictionary<string, List<int>> listOfFilters, int gemPower, string command, string filterName)
        {
            switch (command)
            {
                case "Exclude":
                    {
                        if (!listOfFilters.ContainsKey(filterName))
                        {
                            listOfFilters.Add(filterName, new List<int>());
                        }

                        listOfFilters[filterName].Add(gemPower);
                    }

                    break;
                case "Reverse":
                    {
                        listOfFilters[filterName].Remove(listOfFilters[filterName].FirstOrDefault(param => param == gemPower));
                        if (listOfFilters.ContainsKey(filterName))
                        {
                            if (listOfFilters[filterName].Contains(gemPower))
                                listOfFilters[filterName].Remove(gemPower);
                        }
                    }

                    break;
            }
        }

        private static List<int> ApplyFilters(Dictionary<string, List<int>> listOfFilters, List<int> gemPowers)
        {
            var count = gemPowers.Count;
            var gemsToRemoveIndices = new List<int>();
            foreach (var filterType in listOfFilters)
            {
                switch (filterType.Key)
                {
                    case "Sum Left Right":
                        {
                            foreach (var filterParameter in filterType.Value)
                            {
                                var startPower = gemPowers[0];
                                if (count > 1)
                                {
                                    startPower += gemPowers[1];
                                }

                                if (startPower == filterParameter)
                                {
                                    gemsToRemoveIndices.Add(0);
                                }
                                for (var i = 1; i < gemPowers.Count - 1; i++)
                                {
                                    var power = gemPowers[i - 1] + gemPowers[i] + gemPowers[i + 1];
                                    if (power == filterParameter)
                                    {
                                        gemsToRemoveIndices.Add(i);
                                    }
                                }

                                var endPower = gemPowers[count - 1];
                                if (count > 1)
                                {
                                    endPower += gemPowers[count - 2];
                                }

                                if (endPower == filterParameter)
                                {
                                    gemsToRemoveIndices.Add(count - 1);
                                }
                            }
                        }

                        break;
                    case "Sum Left":
                        {
                            foreach (var filterParameter in filterType.Value)
                            {
                                if (gemPowers[0] == filterParameter)
                                {
                                    gemsToRemoveIndices.Add(0);
                                }
                                for (var i = 1; i < gemPowers.Count; i++)
                                {
                                    var power = gemPowers[i - 1] + gemPowers[i];
                                    if (power == filterParameter)
                                    {
                                        gemsToRemoveIndices.Add(i);
                                    }
                                }
                            }
                        }

                        break;

                    case "Sum Right":
                        {
                            foreach (var filterParameter in filterType.Value)
                            {
                                for (var i = 0; i < gemPowers.Count - 1; i++)
                                {
                                    var power = gemPowers[i] + gemPowers[i + 1];
                                    if (power == filterParameter)
                                    {
                                        gemsToRemoveIndices.Add(i);
                                    }
                                }

                                if (gemPowers[count - 1] == filterParameter)
                                {
                                    gemsToRemoveIndices.Add(count - 1);
                                }
                            }
                        }

                        break;
                } 
            }

            var gemsToForge = new List<int>();
            for (var i = 0; i < count; i++)
            {
                if (gemsToRemoveIndices.Contains(i))
                {
                    continue;
                }

                gemsToForge.Add(gemPowers[i]);
            }

            return gemsToForge;
        }
    }
}
