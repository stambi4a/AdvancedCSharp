namespace Problem_03.Jedi_Code_X
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private const int BufSize = 1024;
        private static void Main(string[] args)
        {
            var inStream = Console.OpenStandardInput(BufSize);
            Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, BufSize));

            var lineCount = int.Parse(Console.ReadLine());

            var textBuilder = new StringBuilder();
            for (var i = 0; i < lineCount; i++)
            {
                textBuilder.Append(Console.ReadLine());
            }

            var text = textBuilder.ToString();
            var namePrefix = Console.ReadLine();
            var namePrefixLength = namePrefix.Length;
            var messagePrefix = Console.ReadLine();
            var messagePrefixLength = messagePrefix.Length;
            var nameRegex = new Regex($"{namePrefix}([A-Za-z]{{{namePrefixLength}}})([^A-Za-z]*)");
            var messageRegex = new Regex($"{messagePrefix}([A-Za-z0-9]{{{messagePrefixLength}}})([^A-Za-z0-9]*)");
            /*var nameRegex = new Regex(Regex.Escape(namePrefix) + @"([a-zA-Z]{" + namePrefixLength + @"})(?![a-zA-Z])");
            var messageRegex = new Regex(Regex.Escape(messagePrefix) + @"([a-zA-Z0-9]{" + messagePrefixLength + @"})(?![a-zA-Z0-9])");*/
            var namesMatches = nameRegex.Matches(text);
            var names = (from Match name in namesMatches select name.Groups[1].Value).ToList();
            var messageMatches = messageRegex.Matches(text);
            var messages = (from Match message in messageMatches select message.Groups[1].Value).ToList();
            var correspondingIndices = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var countMessages = messages.Count;
            var countNames = names.Count;
           
            var jedisWithMessages = new List<string>();
            for (int i = 0, j = 0; i < correspondingIndices.Length && j < countNames; i++)
            {
                var index = correspondingIndices[i] - 1;
                if (index >= 0 && index < countMessages)
                {
                    jedisWithMessages.Add(names[j++] + " - " + messages[index]);
                } 
            }
            
            Console.WriteLine(string.Join(Environment.NewLine, jedisWithMessages));
        }
    }
}
