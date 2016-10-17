namespace Problems_03.Custom_Min_Function
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> findMin = delegate (int[] elements)
            {
                var min = elements[0];
                for (var i = 1; i < elements.Length; i++)
                {
                    if (numbers[i] < min)
                    {
                        min = numbers[i];
                    }
                }

                return min;
            };
            var minElement = findMin(numbers);
            Console.WriteLine(minElement);
        }
    }
}
