namespace Problem_11.Semantic_HTML
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private const string DivPattern = "((.|\\n)*)<(div)(.*?)(id|class)(\\s*=\\s*)\"(main|header|nav|article|section|aside|footer)\"(.*?)>((.|\\n)*?)</(div)>(\\s*<!--\\s*\\7\\s*-->)((.|\\n)*)";
        private const string ReplacePattern = "$1<$7$4$8>$9</$7>$13";
        private const string MultipleSpaceReducePattern = "<(main|header|nav|article|section|aside|footer)(.*?) {2,}";
        private static void Main(string[] args)
        {
            var webTextBuilder = new StringBuilder();
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("END"))
                {
                    break;
                }

                webTextBuilder.Append(input + Environment.NewLine);
            }

            var webText = webTextBuilder.ToString();
            while (true)
            {
                var match = Regex.Match(webText, DivPattern);
                if (!match.Success)
                {
                    break;
                }

                webText = Regex.Replace(webText, DivPattern, ReplacePattern);
            }

            while (true)
            {
                var match = Regex.Match(webText, MultipleSpaceReducePattern);
                if (!match.Success)
                {
                    break;
                }

                webText = Regex.Replace(webText, MultipleSpaceReducePattern, "<$1$2 ");
            }

            webText = Regex.Replace(webText, "<(/?)(main|header|nav|article|section|aside|footer)(.*?) +>", "<$1$2$3>");
            
            Console.WriteLine(webText);
        }
    }
}
