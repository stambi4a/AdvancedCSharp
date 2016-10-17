namespace Problem_01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var capacity = int.Parse(Console.ReadLine());
            var bunkerStorages = new Queue<Queue<int>>();
            var bunkerNames = new Queue<string>();
            var bunkers = new Dictionary<string, int>();
            var overflowedBunkers = new Dictionary<string, Queue<int>>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("Bunker Revision"))
                {
                    break;
                }

                var inputParams = input.Split();
                var length = inputParams.Length;
                
                for (var i = 0; i < length; i++)
                {
                    var weaponCapacity = 0;
                    bool isNumber = int.TryParse(inputParams[i], out weaponCapacity);
                    if (!isNumber)
                    {
                        var bunkerName = inputParams[i];
                        bunkerNames.Enqueue(bunkerName);
                        bunkers.Add(bunkerName, 0);
                        bunkerStorages.Enqueue(new Queue<int>());
                        continue;
                    }
                    if (isNumber)
                    {
                        var isWeaponTaken = false;
                        while (bunkerStorages.Count > 1)
                        {
                            var currentBunker = bunkerStorages.Peek();
                            var bunkerName = bunkerNames.Peek();
                            var sum = bunkers[bunkerName];
                            if (sum + weaponCapacity <= capacity)
                            {
                                isWeaponTaken = true;
                                currentBunker.Enqueue(weaponCapacity);
                                bunkers[bunkerName] += weaponCapacity;
                                break;
                            }

                            bunkerName = bunkerNames.Dequeue();
                            var bunkerStorage = bunkerStorages.Dequeue();
                            overflowedBunkers.Add(bunkerName, bunkerStorage);
                        }

                        if (!isWeaponTaken)
                        {
                            if (weaponCapacity > capacity)
                            {
                                continue;
                            }

                            var currentBunker = bunkerStorages.Peek();
                            var bunkerName = bunkerNames.Peek();
                            var sum = bunkers[bunkerName];
                            while (sum + weaponCapacity > capacity && currentBunker.Count > 0)
                            {
                                sum -= currentBunker.Dequeue();
                            }

                            currentBunker.Enqueue(weaponCapacity);
                            bunkers[bunkerName] += weaponCapacity;
                        }
                    }
                }           
            }

            foreach (var bunker in overflowedBunkers)
            {
                Console.Write($"{bunker.Key} -> ");
                if (bunker.Value.Count == 0)
                {
                    Console.WriteLine("Empty");
                }
                else
                {
                    Console.WriteLine(string.Join(", ", bunker.Value));
                }
            }
        }
    }
}
