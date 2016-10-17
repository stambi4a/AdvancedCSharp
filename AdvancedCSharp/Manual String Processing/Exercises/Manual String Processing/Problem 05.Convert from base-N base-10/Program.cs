namespace Problem_05.Convert_from_base_N_base_10
{
    using System;
    using System.Numerics;

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            BigInteger number = BigInteger.Parse(input[1]);
            int toBase = int.Parse(input[0]);
            BigInteger numberIn10Base = new BigInteger(0);
            BigInteger basePow = BigInteger.One;
            while (number > 0)
            {
                int digit = (int)BigInteger.Remainder(number, 10);
                numberIn10Base = digit * basePow + numberIn10Base;
                basePow *= toBase;
                number /= 10;
            }

            Console.WriteLine(numberIn10Base);
        }
    }
}
