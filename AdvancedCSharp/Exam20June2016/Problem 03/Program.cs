namespace Problem_03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            var messages = new List<string>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("Over!"))
                {
                    break;
                }

                var length = int.Parse(Console.ReadLine());
                var pattern = $@"^(\d+)([a-zA-Z]{{{length}}})([^a-zA-Z]*)$";
                var regex = new Regex(pattern);
                if (!regex.IsMatch(input))
                {
                    continue;
                }

                var match = regex.Match(input);
                var message = match.Groups[2].Value;
                var lengthMessage = message.Length;
                var indicesBefore = match.Groups[1].Value;
                var verificationCode = indicesBefore.Select(ch => ch - '0').Select(digit => digit >= lengthMessage ? ' ' : message[digit]).ToList();
                var stringAfter = match.Groups[3].Value;
                var digitsAfter = Regex.Matches(stringAfter, "\\d");
                verificationCode.AddRange(from Match matchDigit in digitsAfter select int.Parse(matchDigit.Value) into digit select digit >= lengthMessage ? ' ' : message[digit]);

                var messageVerification = new string(verificationCode.ToArray());
                messages.Add($"{message} == {messageVerification}");
            }

            Console.WriteLine(string.Join(Environment.NewLine, messages));
        }
    }
}
