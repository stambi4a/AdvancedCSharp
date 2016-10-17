namespace Problem_10.Predicate_Party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private const string EndPhrase = " going to the party!";
        private const string NobodyMessage = "Nobody is";

        private static void Main(string[] args)
        {
            var names = new HashSet<string>(Console.ReadLine().Trim().Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            var listOfPeople = new List<string>(names);
            Action<List<string>, string, string, string> getPeople = AddPeople;
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("Party!"))
                {
                    break;
                }

                var commands = input.Trim().Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = commands[0];
                var containCommand = commands[1];
                var searchParameter = commands[2];
                getPeople(listOfPeople, searchParameter, command, containCommand);
            }

            Action<IEnumerable<string>> print = PrintPeople;
            /*listOfPeople.Sort();*/
            print(listOfPeople);
        }

        private static void PrintPeople(IEnumerable<string> people)
        {
            if (people.Any())
            {
                Console.WriteLine(string.Join(", ", people) + " are" + EndPhrase);
                return;
            }
           
            Console.WriteLine(NobodyMessage + EndPhrase);
        }

        private static void AddPeople(List<string> people, string searchParameter, string command, string containCommand)
        {
            IEnumerable<string> found = new List<string>();
            switch (containCommand)
            {
                case "Length":
                    {
                        var length = int.Parse(searchParameter);
                        found = new List<string>(people.Where(human => human.Length == length));
                    }
                    break;
                case "StartsWith":
                    {
                        found = new List<string>(people.Where(human => human.StartsWith(searchParameter)));
                    }
                    break;
                case "EndsWith":
                    {
                        found = new List<string>(people.Where(human => human.EndsWith(searchParameter)));
                    }
                    break;
            }

            if (!found.Any())
            {
                return;
            }

            switch (command)
            {
                case "Double":
                    {
                        people.AddRange(found);
                    }
                    break;
                case "Remove":
                    {
                        foreach (var human in found)
                        {
                            people.Remove(human);
                        }
                    }
                    break;
            }
        }
    }
}
