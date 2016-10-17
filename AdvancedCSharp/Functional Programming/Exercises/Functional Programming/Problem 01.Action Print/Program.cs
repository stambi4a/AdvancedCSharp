namespace Problem_01.Action_Print
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            Action<string[]> newLinePrint = delegate(string[] line)
                {
                    foreach (var element in line)
                    {
                        Console.WriteLine(element);
                    }
                };
            newLinePrint(input);
        }
    }
}
