namespace Problem_08.Custom_Comparator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(numbers, new SpecialComparator());
            Console.WriteLine(string.Join(" ", numbers));
        }
    }

    public class SpecialComparator : IComparer<int>
    {
        public int Compare(int first, int second)
        {
            var firstIsEven = first % 2 == 0;
            var secondIsEven = second % 2 == 0;
            if (firstIsEven)
            {
                if (secondIsEven)
                {
                    return first - second;
                }

                return -1;
            }
            if (secondIsEven)
            {
                return 1;
            }

            return first - second;
        }
    }
}
