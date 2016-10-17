namespace Problem_06.A_Miner_Task
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var resources = new Dictionary<string, long>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("stop"))
                {
                    break;
                }

                string resource = input;
                if (!resources.ContainsKey(resource))
                {
                    resources.Add(resource, 0);
                }

                int quantity = int.Parse(Console.ReadLine());
                resources[resource] += quantity;
            }

            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
