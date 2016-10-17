namespace Basic_Stack_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] inputParams = Console.ReadLine().Split();
            int pushCount = int.Parse(inputParams[0]);
            int popCount = int.Parse(inputParams[1]);
            int elementToFind = int.Parse(inputParams[2]);

            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            var numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var stack = new Stack<int>();

            pushCount = Math.Min(pushCount, numbers.Count());
            for (int i = 0; i < pushCount; i++)
            {
                stack.Push(numbers[i]);
            }

            popCount = Math.Min(popCount, stack.Count);
            for (int i = 0; i < popCount; i++)
            {
                stack.Pop();
            }

            int minElement = int.MaxValue;
            while (stack.Count > 0)
            {
                int poppedElement = stack.Pop();
                if (poppedElement == elementToFind)
                {
                    Console.WriteLine("true");
                    return;
                }

                if (poppedElement < minElement)
                {
                    minElement = poppedElement;
                }
            }

            Console.WriteLine(minElement != int.MaxValue ? minElement : 0);
        }
    }
}
