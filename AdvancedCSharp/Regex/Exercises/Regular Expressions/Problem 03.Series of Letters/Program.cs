namespace Problem_03.Series_of_Letters
{
    using System;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private const string pattern = "(([a-zA-Z])\\2{1,})";

        private static void Main(string[] args)
        {
            var charSequence = Console.ReadLine();
            charSequence = Regex.Replace(charSequence, pattern, "$2");

            Console.WriteLine(charSequence);
        }
    }
}
