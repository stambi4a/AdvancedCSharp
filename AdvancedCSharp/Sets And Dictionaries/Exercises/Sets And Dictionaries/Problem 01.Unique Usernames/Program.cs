namespace Problem_01.Unique_Usernames
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var usernames = new HashSet<string>();
            int userNamesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < userNamesCount; i++)
            {
                usernames.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }
    }
}
