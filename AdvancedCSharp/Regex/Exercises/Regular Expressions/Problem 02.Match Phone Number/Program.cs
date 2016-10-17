namespace Problem_02.Match_Phone_Number
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var phoneNumbers = new List<string>();
            while (true)
            {
                var stringToCheck = Console.ReadLine();
                if (stringToCheck.Equals("end"))
                {
                    break;
                }

                var match = Regex.Match(stringToCheck, "^\\+359([\\s-])2\\1\\d{3}\\1\\d{4}\\b");
                if (match.Success)
                {
                    phoneNumbers.Add(match.Value);
                }
            }

            if (phoneNumbers.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, phoneNumbers));
            }
        }
    }
}
