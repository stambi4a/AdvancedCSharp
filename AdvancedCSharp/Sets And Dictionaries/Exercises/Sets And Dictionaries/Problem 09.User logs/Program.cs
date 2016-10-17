namespace Problem_09.User_Logs
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            var userLogs = new SortedDictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("end"))
                {
                    break;
                }

                string[] inputParams = input.Split();
                Regex regex = new Regex("IP=([A-Za-z0-9.:]+)");
                string ipAddress = regex.Replace(inputParams[0], "$1");

                regex = new Regex("message=([^'])'");
                string message = regex.Replace(inputParams[1], "$1");

                regex = new Regex("user=([a-zA-Z]{3,50})");
                string userName = regex.Replace(inputParams[2], "$1");

                if (!userLogs.ContainsKey(userName))
                {
                    userLogs.Add(userName, new Dictionary<string, int>());
                }

                if (!userLogs[userName].ContainsKey(ipAddress))
                {
                    userLogs[userName].Add(ipAddress, 0);
                }

                userLogs[userName][ipAddress]++;
            }

            foreach (var user in userLogs.Keys)
            {
                Console.WriteLine($"{user}:");
                var ipAddresses = new List<string>();
                foreach (var ipAddress in userLogs[user])
                {
                    ipAddresses.Add(ipAddress.Key + " => " + ipAddress.Value);
                }

                Console.WriteLine(string.Join(", ", ipAddresses) + ".");
            }
        }
    }
}
