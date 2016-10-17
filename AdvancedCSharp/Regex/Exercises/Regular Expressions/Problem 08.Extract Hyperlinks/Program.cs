namespace Problem_08.Extract_HyperLinks
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var extractedLinks = new List<string>();
            var strBuilder = new StringBuilder();
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("END"))
                {
                    break;
                }

                strBuilder.Append(input);
            }

            var webText = strBuilder.ToString();
            var regex = new Regex("(<a[^>]*?href\\s*=\\s*)((([\'\"])(.*?)\\4)|((.*?)[\\s>]))");
            var matchCollection = regex.Matches(webText);
            for (var i = 0; i < matchCollection.Count; i++)
            {
                var link = matchCollection[i].Groups[5].ToString();
                if (matchCollection[i].Groups[7].ToString() != string.Empty)
                {
                    link = matchCollection[i].Groups[7].ToString();
                }

                extractedLinks.Add(link);
            }

            Console.WriteLine(string.Join(Environment.NewLine, extractedLinks));
        }
    }
}
