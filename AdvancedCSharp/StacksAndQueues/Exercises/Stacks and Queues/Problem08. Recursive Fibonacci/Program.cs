namespace Problem08.Recursive_Fibonacci
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int fibonacciNumber = int.Parse(Console.ReadLine());
            var fibonacciQueue = new Queue<long>();
            fibonacciQueue.Enqueue(0);
            if (fibonacciNumber == 0)
            {
                Console.WriteLine(0);
            }

            fibonacciQueue.Enqueue(1);
            if (fibonacciNumber == 1)
            {
                Console.WriteLine(1);
            }

            int index = 2;
            while (index <= fibonacciNumber)
            {
                fibonacciQueue.Enqueue(fibonacciQueue.Dequeue() + fibonacciQueue.Peek());
                index++;
            }

            fibonacciQueue.Dequeue();
            Console.WriteLine(fibonacciQueue.Dequeue());
        }
    }
}
