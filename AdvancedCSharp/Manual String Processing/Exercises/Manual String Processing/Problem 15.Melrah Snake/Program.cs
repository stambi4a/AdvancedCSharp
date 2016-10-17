namespace Problem_15.Melrah_Snake
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var randomCharactersString = Console.ReadLine();
            var pattern = Console.ReadLine();
            var countShakes = 0;

            while (randomCharactersString.Length > 0 && pattern.Length > 0)
            {
                var indexFirst = randomCharactersString.IndexOf(pattern);
                var indexLast = randomCharactersString.LastIndexOf(pattern);

                if (indexFirst == -1 ||
                    indexLast == -1 ||
                    indexLast - indexFirst < pattern.Length)
                {
                    break;
                }

                var strBuilder = new StringBuilder();
                strBuilder.Append(randomCharactersString.Substring(0, indexFirst));
                strBuilder.Append(
                    randomCharactersString.Substring(indexFirst + pattern.Length, indexLast - indexFirst - pattern.Length));
                strBuilder.Append(randomCharactersString.Substring(indexLast + pattern.Length, randomCharactersString.Length - indexLast - pattern.Length));
                randomCharactersString = strBuilder.ToString();
                strBuilder.Clear();

                var indexRemoved = pattern.Length / 2;
                strBuilder.Append(pattern.Substring(0, indexRemoved));
                if (indexRemoved < pattern.Length - 1)
                {
                    strBuilder.Append(pattern.Substring(indexRemoved + 1, pattern.Length - indexRemoved - 1));
                }

                pattern = strBuilder.ToString();
                strBuilder.Clear();
                countShakes++;
            }

            for (var i = 0; i < countShakes; i++)
            {
                Console.WriteLine("Shaked it.");
            }

            Console.WriteLine("No shake.\n" + randomCharactersString);
        }
    }
}
