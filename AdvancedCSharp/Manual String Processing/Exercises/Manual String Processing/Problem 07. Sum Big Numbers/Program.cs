namespace Problem_07.Sum_Big_Numbers
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private const int DecimalBase = 10;
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            string secondNumber = Console.ReadLine();

            int lengthFirst = firstNumber.Length;
            int lengthSecond = secondNumber.Length;

            int index = 0;
            var sum = new List<int>();
            int addition = 0;
            while (index < lengthFirst && index < lengthSecond)
            {
                int firstDigit = firstNumber[lengthFirst - index - 1] - '0';
                int secondDigit = secondNumber[lengthSecond - index - 1] - '0';
                int sumDigits = firstDigit + secondDigit + addition;
                addition = sumDigits / DecimalBase;
                sum.Add(sumDigits % DecimalBase);
                index++;
            }

            while (index < lengthFirst)
            {
                int firstDigit = firstNumber[lengthFirst - index - 1] - '0';
                int sumDigits = firstDigit + addition;
                sum.Add(sumDigits % DecimalBase);
                addition = sumDigits / DecimalBase;
                index++;
            }

            while (index < lengthSecond)
            {
                int secondDigit = secondNumber[lengthSecond - index - 1] - '0';
                int sumDigits = secondDigit + addition;
                sum.Add(sumDigits % DecimalBase);
                addition = sumDigits / DecimalBase;
                index++;
            }

            if (addition == 1)
            {
                sum.Add(addition);
            }

            int indexLastZero = sum.Count - 1;
            while(true)
            {
                if (sum[indexLastZero] != 0)
                {
                    break;
                }

                sum.RemoveAt(indexLastZero);
                indexLastZero--;
            }

            sum.Reverse();
            Console.WriteLine(string.Join("", sum));
        }
    }
}
