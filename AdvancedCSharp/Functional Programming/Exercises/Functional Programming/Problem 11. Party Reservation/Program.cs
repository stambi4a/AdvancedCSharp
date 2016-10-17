namespace Problem_11.Party_Reservation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var names = new List<string>(Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            var listOfFilters = new Dictionary<string, List<string>>();
            Action<Dictionary<string, List<string>>, string, string, string> getPeople = WorkWithFilters;
            Action<Dictionary<string, List<string>>, List<string>> applyFilters = ApplyFilters;
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("Print"))
                {
                    break;
                }

                var commands = input.Trim().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var command = commands[0];
                var filterName = commands[1];
                var searchParameter = commands[2];
                getPeople(listOfFilters, searchParameter, command, filterName);
            }

            applyFilters(listOfFilters, names);
            Action<List<string>> print = PrintPeople;
            print(names);
        }

        private static void PrintPeople(IEnumerable<string> people)
        {
            if (people.Any())
            {
                Console.WriteLine(string.Join(" ", people));
            }
        }

        private static void ApplyFilters(Dictionary<string, List<string>> listOfFilters, List<string> names)
        {
            var peopleToRemove = new List<string>();
            foreach (var filterType in listOfFilters)
            {
                switch (filterType.Key)
                {
                    case "Starts with":
                        {
                            foreach (var filterParameter in filterType.Value)
                            {
                                foreach (var human in names)
                                {
                                    if (human.StartsWith(filterParameter))
                                    {
                                        peopleToRemove.Add(human);
                                    }
                                }
                            }                            
                        }

                        break;
                    case "Ends with":
                        {
                            foreach (var filterParameter in filterType.Value)
                            {
                                foreach (var human in names)
                                {
                                    if (human.EndsWith(filterParameter))
                                    {
                                        peopleToRemove.Add(human);
                                    }
                                }
                            }
                        }

                        break;

                    case "Length":
                        {
                            foreach (var filterParameter in filterType.Value)
                            {
                                var length = int.Parse(filterParameter);
                                foreach (var human in names)
                                {
                                    if (human.Length == length)
                                    {
                                        peopleToRemove.Add(human);
                                    }
                                }
                            }
                        }

                        break;

                    case "Contains":
                        {
                            foreach (var filterParameter in filterType.Value)
                            {
                                foreach (var human in names)
                                {
                                    if (human.Contains(filterParameter))
                                    {
                                        peopleToRemove.Add(human);
                                    }
                                }
                            }
                        }

                        break;
                }

                foreach (var human in peopleToRemove)
                {
                    if (names.Contains(human))
                    {
                        names.Remove(human);
                    }
                }
            }
        }

        private static void WorkWithFilters(Dictionary<string, List<string>> listOfFilters, string searchParameter, string command, string filterName)
        {
            switch (command)
            {
                case "Add filter":
                    {
                        if (!listOfFilters.ContainsKey(filterName))
                        {
                            listOfFilters.Add(filterName, new List<string>());
                        }

                        listOfFilters[filterName].Add(searchParameter);
                    }

                    break;
                case "Remove filter":
                    {
                        listOfFilters[filterName].Remove(listOfFilters[filterName].FirstOrDefault(param=>param == searchParameter));
                        if (listOfFilters.ContainsKey(filterName))
                        {
                            if(listOfFilters[filterName].Contains(searchParameter))
                            listOfFilters[filterName].Remove(searchParameter);
                        }
                    }

                    break;
            }
        }
    }
}
