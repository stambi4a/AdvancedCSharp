namespace Problem_04.Find_Even_or_Odds
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static int startNumber;

        private static int endNumber;
        private static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            startNumber = int.Parse(input[0]);
            endNumber = int.Parse(input[1]);
            var numType = Console.ReadLine();
            Func<int, bool> predicate;

            Action<int, int> printListOfNumbers = delegate(int sNumber, int eNumber)
                {
                    var list = Enumerable.Range(startNumber, endNumber - startNumber + 1);
                    if (numType == "odd")
                    {
                        predicate = IsOdd;
                        list = list.Where(predicate);
                    }
                    else
                    {
                        predicate = IsEven;
                        list = list.Where(predicate);
                    }
                    Console.WriteLine(string.Join(" ", list));
                };

            printListOfNumbers(startNumber, endNumber);

        }

        private static bool IsOdd(int number)
        {
            return number % 2 == 1 || number % 2 == -1;
        }


        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
    }
}
