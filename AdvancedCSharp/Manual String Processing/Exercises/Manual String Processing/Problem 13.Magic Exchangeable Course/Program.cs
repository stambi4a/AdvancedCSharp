namespace Problem_13.Magic_Exchangeable_Course
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var firstString = input[0];
            var secondString = input[1];

            if (firstString.Length != secondString.Length)
            {
                if (firstString.Distinct().Count() != secondString.Distinct().Count())
                {
                    Console.WriteLine("false");
                    return;
                }

                Console.WriteLine("true");
                return;
            }

            var exchangeableWords = new Dictionary<char, char>();
            var index = 0;
            while (index < firstString.Length)
            {
                if (!exchangeableWords.ContainsKey(firstString[index]))
                {
                    exchangeableWords.Add(firstString[index], secondString[index]);
                }
                else
                {
                    if (exchangeableWords[firstString[index]] != secondString[index])
                    {
                        Console.WriteLine("false");
                        return;
                    }
                }

                index++;
            }

            Console.WriteLine("true");
        }
    }
}
