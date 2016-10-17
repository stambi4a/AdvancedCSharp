namespace Problem_01.Match_Full_Name
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var names = new List<string>();
            while (true)
            {
                var probableName = Console.ReadLine();
                if (probableName.Equals("end"))
                {
                    break;
                }

                var match = Regex.Match(probableName, "\\b[A-Z][a-z]+\\s[A-Z][a-z]+\\b");
                if (match.Success && match.Value.Length == probableName.Length)
                {
                    Console.WriteLine(match);
                }                
            }

            if (names.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, names));
            }
        }
    }
}
