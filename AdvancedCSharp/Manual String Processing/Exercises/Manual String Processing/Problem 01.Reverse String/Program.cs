namespace Problem_01.Reverse_String
{
    using System;
    using System.Text;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var stringToReverse = Console.ReadLine();
            var strBuilder = new StringBuilder();
            for (int i = stringToReverse.Length - 1; i >= 0; i--)
            {
                strBuilder.Append(stringToReverse[i]);
            }

            Console.WriteLine(strBuilder.ToString());
        }
    }
}
