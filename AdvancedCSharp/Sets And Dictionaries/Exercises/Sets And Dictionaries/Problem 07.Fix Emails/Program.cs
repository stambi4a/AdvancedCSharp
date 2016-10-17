namespace Problem_07.Fix_Emails
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var phonebook = new Dictionary<string, string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("stop"))
                {
                    break;
                }

                string email = Console.ReadLine();
                if (!email.EndsWith("us") && !email.EndsWith("uk"))
                {
                    if (!phonebook.ContainsKey(input))
                    {
                        phonebook.Add(input, null);
                    }

                    phonebook[input] = email;
                }         
            }

            foreach (var contact in phonebook)
            {
                Console.WriteLine($"{contact.Key} -> {contact.Value}");
            }
        }
    }
}
