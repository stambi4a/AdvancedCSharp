namespace Problem_11.Palindroem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var palindromes = new SortedSet<string>();
            char[] delimiters = { ' ', ',', '.', '?', '!' };

            var wordsToCheck = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);


            foreach (var wordToCheck in wordsToCheck)
            {
                var reveresedWord = new string(wordToCheck.Reverse().ToArray());

                if (wordToCheck.Equals(reveresedWord))
                {
                    palindromes.Add(wordToCheck);
                }
            }

            Console.WriteLine("[" + string.Join(", ", palindromes) + "]");
        }
    }
}
