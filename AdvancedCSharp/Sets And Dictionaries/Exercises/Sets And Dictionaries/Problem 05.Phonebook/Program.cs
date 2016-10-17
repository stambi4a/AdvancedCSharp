namespace Problem_05.Phonebook
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var phonebook = new Dictionary<string, string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("search"))
                {
                    break;
                }
                string[] inputParams = input.Split('-', '+');
                if(!phonebook.ContainsKey(inputParams[0]))
                {
                    phonebook.Add(inputParams[0], null);
                }

                phonebook[inputParams[0]] = inputParams[1];
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("stop"))
                {
                    return;
                }

                if (phonebook.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {phonebook[input]}");
                }
                else
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }
            }
            
        }
    }
}
