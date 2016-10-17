namespace Problem_10.Use_Your_Chains
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private const string ExtractPattern = "<p>(.*?)</p>";
        private const string NonWordCharacterPattern = "[^a-z0-9]+";
        private const int HalfAlphabetLength = 13;

        private static void Main(string[] args)
        {
            byte[] inputBuffer = new byte[1024];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
            var text = Console.ReadLine();
            var matchCollection = Regex.Matches(text, ExtractPattern);
            var encryptedMessage = new StringBuilder();
            foreach (Match match in matchCollection)
            {
                var encryptedText = match.Groups[1].Value;
                encryptedText = Regex.Replace(encryptedText, NonWordCharacterPattern, " ");
                foreach (var character in encryptedText)
                {
                    if (character >= 'a' && character <= 'm')
                    {
                        encryptedMessage.Append((char)(character + HalfAlphabetLength));
                    }
                    else if (character >= 'n' && character <= 'z')
                    {
                        encryptedMessage.Append((char)(character - HalfAlphabetLength));
                    }
                    else
                    {
                        encryptedMessage.Append(character);
                    }
                }
            }

            Console.WriteLine(encryptedMessage.ToString());
        }
    }
}
