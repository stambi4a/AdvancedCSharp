namespace Problem_06.Count_Substring_Occurrences
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string key = Console.ReadLine().ToLower();

            int occurencesCount = 0;
            int index = -1;

            while (true)
            {
                index = text.IndexOf(key, index + 1);
                if (index == -1)
                {
                    break;
                }

                occurencesCount++;
            }

            Console.WriteLine(occurencesCount);
        }
    }
}
