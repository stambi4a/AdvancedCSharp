namespace Problem_01.Poisonous_Plants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            var numbers = input.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var stack = new Stack<int>();

            foreach (int number in numbers)
            {
                stack.Push(number);
            }

            while (stack.Count > 1)
            {
                Console.Write(stack.Pop() + " ");
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
