namespace Problem_14.Letters_Change_Numbers
{
    using System;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private const int EnglishAlphabetLength = 26;
        private static void Main(string[] args)
        {
            var strings = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            /*var strings = new[] { "a100d", "A500A" };*/
            double totalSum = 0;
            foreach (var stringHoldingNumber in strings)
            {
                var length = stringHoldingNumber.Length;
                var number = int.Parse(stringHoldingNumber.Substring(1, length - 2));
                double sumString = number;
                var charBeforeNumber = stringHoldingNumber[0];
                var charAfterNumber = stringHoldingNumber[length - 1];

                if (charBeforeNumber - 'A' >= 0 && charBeforeNumber - 'A' <= EnglishAlphabetLength - 1)
                {
                    sumString /= charBeforeNumber - 'A' + 1;
                }
                else
                {
                    sumString *= charBeforeNumber - 'a' + 1;
                }

                if (charAfterNumber - 'A' >= 0 && charAfterNumber - 'A' <= EnglishAlphabetLength - 1)
                {
                    sumString -= charAfterNumber - 'A' + 1;
                }
                else
                {
                    sumString += charAfterNumber - 'a' + 1;
                }

                totalSum += sumString;
            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
