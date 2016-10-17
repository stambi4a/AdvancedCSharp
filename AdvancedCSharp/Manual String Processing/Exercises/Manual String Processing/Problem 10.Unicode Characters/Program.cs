namespace Problem_10.Unicode_Characters
{
    using System;
    using System.Text;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var strBuilder = new StringBuilder();

            foreach (char ch in text)
            {
                strBuilder.Append($"\\u{(int)ch:x4}");
            }

            Console.WriteLine(strBuilder.ToString());
        }
    }
}
