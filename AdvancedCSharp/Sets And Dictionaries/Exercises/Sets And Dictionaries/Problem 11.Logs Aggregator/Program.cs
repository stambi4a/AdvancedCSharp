namespace Problem_11.Logs_Aggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var userLogs = new SortedDictionary<string, SortedDictionary<string, int>>();
            int logsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < logsCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                string ipAddress = input[0];
                string user = input[1];
                int duration = int.Parse(input[2]);

                if (!userLogs.ContainsKey(user))
                {
                    userLogs.Add(user, new SortedDictionary<string, int>());
                }

                if (!userLogs[user].ContainsKey(ipAddress))
                {
                    userLogs[user].Add(ipAddress, 0);
                }

                userLogs[user][ipAddress] += duration;
            }

            foreach (var user in userLogs.Keys)
            {
                int totalDuration = userLogs[user].Values.Sum();
                Console.WriteLine($"{user}: {totalDuration} [{string.Join(", ", userLogs[user].Keys)}]");
            }
        }
    }
}
