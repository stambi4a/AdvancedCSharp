namespace Problem_05.Calculate_sequence_with_Queue
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            var elements = new List<long>();
            var queueOperatingElements = new Queue<long>();
            elements.Add(number);
            queueOperatingElements.Enqueue(number);
            while (true)
            {
                number = queueOperatingElements.Dequeue();
                elements.Add(number + 1);
                queueOperatingElements.Enqueue(number + 1);
                if (elements.Count == 50)
                {
                    break;
                }

                elements.Add(2 * number + 1);
                queueOperatingElements.Enqueue(2 * number + 1);
                if (elements.Count == 50)
                {
                    break;
                }

                elements.Add(number + 2);
                queueOperatingElements.Enqueue(number + 2);
                if (elements.Count == 50)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
