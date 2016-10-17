namespace Problem09.Stack_Fibonacci
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int fibonacciNumber = int.Parse(Console.ReadLine());
            var fibonacciStack = new Stack<long>();

            if (fibonacciNumber == 0)
            {
                Console.WriteLine(0);
            }

            if (fibonacciNumber == 1)
            {
                Console.WriteLine(1);
            }

            fibonacciStack.Push(0);
            fibonacciStack.Push(1);

            int index = 2;
            while(index <= fibonacciNumber)
            {
                long fibonacciSecond = fibonacciStack.Pop();
                long fibonacciCurrent = fibonacciStack.Pop() + fibonacciSecond;
                fibonacciStack.Push(fibonacciSecond);
                fibonacciStack.Push(fibonacciCurrent);
                index++;
            }

            Console.WriteLine(fibonacciStack.Pop());
        }
    }
}
