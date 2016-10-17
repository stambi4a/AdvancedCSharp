namespace Problem_02.Knights_Of_Honour
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            Action<string[]> newLinePrint = delegate (string[] line)
            {
                foreach (var element in line)
                {
                    Console.WriteLine("Sir " + element);
                }
            };
            newLinePrint(input);
        }
    }
}
