namespace Problem03.Maximum_Element
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var stack = new Stack<int>();
            var maxElements = new Stack<int>();
            maxElements.Push(int.MinValue);
            int queryCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < queryCount; i++)
            {
                var queryParams = Console.ReadLine().Split();
                int queryIndex = int.Parse(queryParams[0]);
              
                switch (queryIndex)
                {
                    case 1:
                        {
                            int queryNumber = int.Parse(queryParams[1]);
                            stack.Push(queryNumber);
                            if (queryNumber >= maxElements.Peek())
                            {
                                maxElements.Push(queryNumber);
                            }
                        }

                        break;
                    case 2:
                        {
                            int queryNumber = stack.Pop();
                            if (queryNumber == maxElements.Peek())
                            {
                                maxElements.Pop();
                            }
                        }

                        break;
                    case 3:
                        {
                            Console.WriteLine(maxElements.Peek());
                        }

                        break;
                }
            }
        }
    }
}
