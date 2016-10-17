namespace Problem_05.Applied_Arithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var numbers = (IEnumerable<int>)Console.ReadLine().Split().Select(int.Parse).ToArray();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                switch (input)
                {
                    case "add":
                        {
                            numbers = numbers.Select(x => x + 1);
                        }

                        break;
                    case "subtract":
                        {
                            numbers = numbers.Select(x => x - 1);
                        }

                        break;
                    case "multiplty":
                        {
                            numbers = numbers.Select(x => x * 2);
                        }

                        break;
                    case "print":
                        {
                            Console.WriteLine(string.Join(" ", numbers));
                        }

                        break;
                }               
            }
        }
    }
}
