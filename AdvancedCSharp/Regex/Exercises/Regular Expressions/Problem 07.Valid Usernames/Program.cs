namespace Problem_07.Valid_Usernames
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private const string UsernamePattern = "\\b[A-Za-z]\\w{2,24}\\b";
        private static void Main(string[] args)
        {
            var delimiters = new[] { '/', '\\', '(', ')', ' ' };
            var possibleUserNames = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var validUserNames = (
                from word in possibleUserNames
                select Regex.Match(word, UsernamePattern)
                into match where match.Success
                select match.Value).ToList();

            var maxConsecutiveSum = 0;
            var indexMaxConsecutive = 0;
            for (var i = 0; i < validUserNames.Count - 1; i++)
            {
                var consecutiveLength = validUserNames[i].Length + validUserNames[i + 1].Length;
                if (consecutiveLength <= maxConsecutiveSum)
                {
                    continue;
                }

                maxConsecutiveSum = consecutiveLength;
                indexMaxConsecutive = i;
            }

            Console.WriteLine(
                validUserNames[indexMaxConsecutive] + Environment.NewLine + validUserNames[indexMaxConsecutive + 1]);
        }
    }
}
