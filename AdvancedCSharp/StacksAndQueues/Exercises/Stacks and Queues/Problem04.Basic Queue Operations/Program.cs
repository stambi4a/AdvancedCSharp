namespace Problem04.Basic_Queue_Operations
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
            var queue = new Queue<int>();

            pushCount = Math.Min(pushCount, numbers.Count());
            for (int i = 0; i < pushCount; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            popCount = Math.Min(popCount, queue.Count);
            for (int i = 0; i < popCount; i++)
            {
                queue.Dequeue();
            }

            int minElement = int.MaxValue;
            while (queue.Count > 0)
            {
                int poppedElement = queue.Dequeue();
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
