namespace Problem_04.Convert_from_base_10_base_N
{
    using System;
    using System.Numerics;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            BigInteger number = BigInteger.Parse(input[1]);
            int toBase = int.Parse(input[0]);
            string converted = null;
            while (number > 0)
            {
                converted = number % toBase + converted;
                number /= toBase;
            }

            Console.WriteLine(converted);
        }
    }
}
