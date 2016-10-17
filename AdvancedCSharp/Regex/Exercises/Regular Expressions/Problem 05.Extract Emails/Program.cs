namespace Problem_05.Extract_Emails
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private const string EmailPattern = "(?<=\\s)([0-9A-Za-z]+)([_\\-.][0-9A-Za-z]+)*@(([A-Za-z])+(\\-[A-Za-z]+)?\\.)+([A-Za-z])+(-[A-Za-z]+)?";

        /*private const string EmailPattern = "\\b(\\b[\\w.\\w]+\\b)@(\\b[\\w.\\w]+\\b)\\b";*/
        /* private const string EmailPattern = "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";*/
        private static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var matches = Regex.Matches(text, EmailPattern);
            var emails = (from Match emailMatch in matches where emailMatch.Success select emailMatch.Value).ToList()   ;
            Console.WriteLine(string.Join(Environment.NewLine, emails));
        }
    }
}
