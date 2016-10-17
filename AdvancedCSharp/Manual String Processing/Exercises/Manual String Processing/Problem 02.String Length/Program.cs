namespace Problem_02.String_Length
{
    using System;

    class Program
    {
        public const int TextLengthUpperLimit = 20;
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int length = text.Length;
            int lengthExcerpt = length > TextLengthUpperLimit ? TextLengthUpperLimit : length;
            string textExcerpt = text.Substring(0, lengthExcerpt);
            textExcerpt = textExcerpt.PadRight(20, '*');
            Console.WriteLine(textExcerpt);
        }
    }
}
