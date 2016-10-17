namespace Problem_08.Multiply_Big_Number
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private const int DecimalBase = 10;
        private static void Main(string[] args)
        {
            var number = new List<int>();
            var firstNumber = Console.ReadLine();
            var multiplier = int.Parse(Console.ReadLine());

            var numberLength = firstNumber.Length;
            var power = 0;
            for (var i = numberLength - 1; i >= 0; i--)
            {
                int multiplication = (firstNumber[i] - '0') * multiplier;
                number.Add((multiplication + power) % 10);
                power = (multiplication + power) / 10;
            }

            number.Add(power);

            var indexLastZero = number.Count - 1;
            while (indexLastZero > 0)
            {
                if (number[indexLastZero] != 0)
                {
                    break;
                }

                number.RemoveAt(indexLastZero);
                indexLastZero--;
            }

            number.Reverse();
            Console.WriteLine(string.Join("", number));


        }
    }
}
