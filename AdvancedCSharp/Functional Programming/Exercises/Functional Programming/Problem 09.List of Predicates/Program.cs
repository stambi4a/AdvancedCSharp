namespace Problem_09.List_of_Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            /* var numbersLcm = numbers[0];
             numbers.ForEach(
                 num =>
                 { numbersLcm = FindLeastCommonMultiple(num, numbersLcm); });

             var list = new List<int>() ;
             var countList = Math.Abs(number / numbersLcm);
             list.AddRange(Enumerable.Range(1, countList));
             list = list.Select(num => num * numbersLcm).ToList();*/
            var list = new List<int>();
            for (var i = 1; i <= number; i++)
            {
                var isDivised = true;
                foreach (var num in numbers)
                {
                    if (i % num != 0)
                    {
                        isDivised = false;
                        break;
                    }
                }

                if (isDivised)
                {
                    list.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", list));

        }

        private static int FindGcd(int first, int second)
        {
            if (first == second)
            {
                return first;
            }

            var max = Math.Max(first, second);
            var min = Math.Min(first, second);
            first = max;
            second = min;
            while (first != second && second != 0)
            {
                var old = second;
                second = first % second;
                first = old;
            }
           
            return first;
        }

        private static int FindLeastCommonMultiple(int first, int second)
        {
            var gcd = FindGcd(first, second);
            var lcm = (first * second) / gcd;

            return lcm;
        }
    }
}
