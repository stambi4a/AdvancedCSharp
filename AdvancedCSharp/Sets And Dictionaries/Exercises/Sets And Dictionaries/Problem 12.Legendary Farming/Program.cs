namespace Problem_12.Legendary_Farming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private const int QuantityToBuyLegendary = 250;
        static void Main(string[] args)
        {
            var legendaryMaterials = new Dictionary<string, int>()
                                         {
                                             { "fragments", 0 },
                                             { "motes", 0 },
                                             { "shards", 0 }
                                         };
            var junkMaterials = new SortedDictionary<string, int>();
            var materialsLegendaryItems = new Dictionary<string, string>()
                                              {
                                                  { "shards", "Shadowmourne" },
                                                  { "fragments", "Valanyr" },
                                                  { "motes", "Dragonwrath" }
                                              };
            string boughtLegendary = null;
            while (true)
            {
                string input = Console.ReadLine().ToLower();
               /* if (string.IsNullOrEmpty(input))
                {
                    break;
                }*/

                string[] inputParams = input.Split();
                for (int i = 0; i < inputParams.Length; i = i + 2)
                {
                    string material = inputParams[i + 1];
                    int quantity = int.Parse(inputParams[i]);

                    if (legendaryMaterials.ContainsKey(material))
                    {
                        legendaryMaterials[material] += quantity;
                        if (legendaryMaterials[material] >= QuantityToBuyLegendary)
                        {
                            boughtLegendary = materialsLegendaryItems[material];
                            legendaryMaterials[material] -= QuantityToBuyLegendary;
                            break;
                        }

                        continue;
                    }

                    
                    if (!junkMaterials.ContainsKey(material))
                    {
                        junkMaterials.Add(material, 0);
                    }

                    junkMaterials[material] += quantity;
                }

                if (boughtLegendary != null)
                {
                    break;
                }
            }

            Console.WriteLine($"{boughtLegendary} obtained!");
            var sortedLegendaryItems = legendaryMaterials.OrderByDescending(x => x.Value);
            foreach (var material in sortedLegendaryItems)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            foreach (var material in junkMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
