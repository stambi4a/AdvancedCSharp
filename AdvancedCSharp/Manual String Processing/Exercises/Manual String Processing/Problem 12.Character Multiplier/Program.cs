namespace Problem_12.Character_Multiplier
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            var firstWord = words[0];
            var secondWord = words[1];

            var firstLength = firstWord.Length;
            var secondLength = secondWord.Length;
            var index = 0;
            var totalCharacterSum = 0;

            while (index < firstLength && index < secondLength)
            {
                totalCharacterSum += firstWord[index] * secondWord[index];
                index++;
            }

            while (index < firstLength)
            {
                totalCharacterSum += firstWord[index];
                index++;
            }

            while (index < secondLength)
            {
                totalCharacterSum += secondWord[index];
                index++;
            }

            Console.WriteLine(totalCharacterSum);
        }
    }
}
