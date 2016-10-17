namespace Problem_04.Replace_a_tag
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private const string UrlPattern = "<\\s*a(.|\\n)*?(href\\s*=(.|\\n)*?)>((.|\\n)*?)<\\s*\\/\\s*a\\s*>";
        private static void Main(string[] args)
        {
            var strBuilder = new StringBuilder();
            while (true)
            {
                var htmlLine = Console.ReadLine();
                if (htmlLine.Equals("end"))
                {
                    break;
                }

                strBuilder.Append(htmlLine);
            }

            var htmlText = strBuilder.ToString();
            while (true)
            {
                var match = Regex.Match(htmlText, UrlPattern);
                if (!match.Success)
                {
                    break;
                }

                htmlText = Regex.Replace(htmlText, UrlPattern, "[URL$1$2]$4[/URL]");
            }

            htmlText = Regex.Replace(htmlText, " {2,}", "");
            /*htmlText = Regex.Replace(htmlText, UrlPattern, "[URL $1]$2[/URL]");*/
            /*htmlText = Regex.Replace(htmlText, QuotationMarkReplacePattern, "$1$2");*/
            Console.WriteLine(htmlText);
        }
    }
}
