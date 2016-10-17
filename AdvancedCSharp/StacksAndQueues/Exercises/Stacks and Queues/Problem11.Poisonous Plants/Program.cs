namespace Problem11.Poisonous_Plants
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.ReadLine();
            int[] pesticideQuantities = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int maxDays = 0;
            int index = 1;
            while (index < pesticideQuantities.Length && pesticideQuantities[index - 1] >= pesticideQuantities[index])
            {
                index++;
            }

            if (index == pesticideQuantities.Length)
            {
                Console.WriteLine(maxDays);
                return;
            }

            int pesticideMinimum = pesticideQuantities[index - 1];
            int days = 1;
            while (index < pesticideQuantities.Length)
            {
                while (index < pesticideQuantities.Length && pesticideQuantities[index] > pesticideMinimum)
                {
                    if (pesticideQuantities[index - 1] >= pesticideQuantities[index])
                    {
                        days++;
                    }

                    index++;
                }

                if (days > maxDays)
                {
                    maxDays = days;
                }

                while (index < pesticideQuantities.Length && pesticideQuantities[index - 1] >= pesticideQuantities[index])
                {
                    index++;
                }

                if (index == pesticideQuantities.Length)
                {                   
                    break;
                }

                pesticideMinimum = pesticideQuantities[index - 1];
                days = 1;
            }

            Console.WriteLine(maxDays);
        }
    }
}
