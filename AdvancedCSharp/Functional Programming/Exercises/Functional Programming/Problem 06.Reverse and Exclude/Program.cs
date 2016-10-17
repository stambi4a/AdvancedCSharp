namespace Problem_06.Reverse_and_Exclude
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            numbers.Reverse();
            var number = int.Parse(Console.ReadLine());
            numbers = numbers.Where(x => x != 0 && x % number != 0).ToList();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
