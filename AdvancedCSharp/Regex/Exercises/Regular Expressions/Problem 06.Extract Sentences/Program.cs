namespace Problem_06.Extract_Sentences
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private const string KeywordPattern = "[\\w\\s-,\'\"]*\\b{0}\\b[\\w\\s-,\'\"]*[.?!]";
        private static void Main(string[] args)
        {
       
            var sentencesWithKeyWord = new List<string>();
            var keyWord = Console.ReadLine();
            var text = Console.ReadLine();
            var matchCollection = Regex.Matches(text, string.Format(KeywordPattern, keyWord), RegexOptions.IgnoreCase);
            foreach (Match match in matchCollection)
            {
                sentencesWithKeyWord.Add(match.Value);
            }
           

            Console.WriteLine(string.Join(Environment.NewLine, sentencesWithKeyWord));
        }
    }
}

