namespace Problem_07.Predicate_for_names
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var length = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split().ToList();
            input = input.Where(x => x.Length <= length).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
