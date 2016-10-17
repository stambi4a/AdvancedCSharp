namespace Problem_04.Count_Symbols
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var characterOccurences = new SortedDictionary<char, int>();

            string input = Console.ReadLine();
            foreach (char ch in input)
            {
                if(!characterOccurences.ContainsKey(ch))
                {
                    characterOccurences.Add(ch, 0);
                }

                characterOccurences[ch]++;
            }

            foreach (var character in characterOccurences)
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }
        }
    }
}
