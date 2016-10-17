namespace Problem_03.Formatting_Numbers
{
    using System;
    using System.Globalization;
    using System.Threading;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string[] input = Console.ReadLine().Trim().Split(new[] { '\t', ' '}, StringSplitOptions.RemoveEmptyEntries);
            int numA = int.Parse(input[0]);
            int numABinary = numA;
            if (numA >= 1024)
            {
                numABinary >>= 1;
            }

            if (numA >= 2048)
            {
                numABinary >>= 1;
            }

            double numB = double.Parse(input[1]);
            double numC = double.Parse(input[2]);
            /*double.TryParse(input[1], out numB);
            double.TryParse(input[2], out numC);
            numB = numB == 0 ? double.Parse(input[0]) : numB;
            numC = numC == 0 ? double.Parse(input[0]) : numC;*/

            Console.WriteLine(
                $"|{numA:X}".PadRight(11, ' ') + $"|{Convert.ToString(numABinary, 2).PadLeft(10, '0')}|"
                + $"{numB:F2}".PadLeft(10, ' ') + $"|{numC:F3}".PadRight(11, ' ') + "|");
        }
    }
}
