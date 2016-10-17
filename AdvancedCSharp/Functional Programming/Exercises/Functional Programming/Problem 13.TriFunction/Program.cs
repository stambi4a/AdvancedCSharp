namespace Problem_13.TriFunction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var sum = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split().ToList();
            Func<string, int, bool> nameCheck = CheckSumOfName;
            Func<List<string>, Func<string, int, bool>, string> findFirstName = (listOfNames, findNameSum) =>
                { return listOfNames.FirstOrDefault(name => findNameSum(name, sum)); };
            var firstName = findFirstName(names, nameCheck);
            Console.WriteLine(firstName);
        }

        private static bool CheckSumOfName(string name, int sum)
        {
            var sumCharacters = 0;
            var nameCharacters = new List<char>(name);
            nameCharacters.ForEach(
                character =>
                    { sumCharacters += character; });
            return sumCharacters >= sum;
        }
    }
}
