namespace Problem_08.HandsOfCards
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static Dictionary<string, int> suits;
        private static Dictionary<char, int> faces;
        static void Main(string[] args)
        {
            var personCards = new Dictionary<string, HashSet<string>>();
            while (true)
            {
                suits = new Dictionary<string, int>()
                            {
                    { "2", 2 },
                    { "3", 3 },
                    { "4", 4 },
                    { "5", 5 },
                    { "6", 6 },
                    { "7", 7 },
                    { "8", 8 },
                    { "9", 9 },
                    { "10", 10 },
                    { "J", 11 },
                    { "Q", 12 },
                    { "K", 13 },
                    { "A", 14 }
                            };

                faces = new Dictionary<char, int>()
                            {
                    { 'S', 4 },
                    { 'H', 3 },
                    { 'D', 2 },
                    { 'C', 1 }
                            };
                string input = Console.ReadLine();
                if (input.Equals("JOKER"))
                {
                    break;
                }

                string[] inputMainParams = input.Split(':');
                string[] inputParams = inputMainParams[1].Split(new [] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);

                string person = inputMainParams[0];
                if (!personCards.ContainsKey(person))
                {
                    personCards.Add(person, new HashSet<string>());
                }

                for (int i = 0; i < inputParams.Length; i++)
                {
                    personCards[person].Add(inputParams[i]);
                }
            }

            foreach (var person in personCards)
            {
                var cards = personCards[person.Key];
                int sumCards = 0;
                foreach (var card in cards)
                {
                    string suit = card.Substring(0, card.Length - 1);
                    char face = card[card.Length - 1];
                    sumCards += suits[suit] * faces[face];
                }

                Console.WriteLine($"{person.Key}: {sumCards}");
            }
        }
    }
}
