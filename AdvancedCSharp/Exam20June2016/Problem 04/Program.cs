namespace Problem_04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        private const long ConvertToHigherTypeCount = 1000000L;
        static void Main(string[] args)
        {
            var regionMeteors = new Dictionary<string, Dictionary<string, long>>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("Count em all"))
                {
                    break;
                }

                var splitPattern = new Regex(@"\s+->\s+");
                var attackParams = splitPattern.Split(input);
                /*var attackParams = input.Trim().Split(new[] { '-', '>', }, StringSplitOptions.RemoveEmptyEntries);*/
                var region = attackParams[0].Trim();
                var meteorsType = attackParams[1].Trim();
                var countMeteors = long.Parse(attackParams[2].Trim());
                if (!regionMeteors.ContainsKey(region))
                {
                    regionMeteors.Add(region, new Dictionary<string, long>()
                                                    {
                        {"Black", 0 },
                        {"Green", 0 },
                        { "Red", 0 }
                                                    });
                }

                regionMeteors[region][meteorsType] += countMeteors;
                if (regionMeteors[region]["Green"] >= ConvertToHigherTypeCount)
                {
                    var additionalReds = regionMeteors[region]["Green"] / ConvertToHigherTypeCount;
                    regionMeteors[region]["Green"] %= ConvertToHigherTypeCount;
                    regionMeteors[region]["Red"] += additionalReds;
                }

                if (regionMeteors[region]["Red"] >= ConvertToHigherTypeCount)
                {
                    var additionalReds = regionMeteors[region]["Red"] / ConvertToHigherTypeCount;
                    regionMeteors[region]["Red"] %= ConvertToHigherTypeCount;
                    regionMeteors[region]["Black"] += additionalReds;
                }
            }

            foreach (var region in regionMeteors)
            {
                /*if (region.Value["Green"] < 0)
                {
                    region.Value["Green"] = 0;
                }*/

               /* if (region.Value["Green"] > 0)
                {
                    var additionalReds = region.Value["Green"] / ConvertToHigherTypeCount;
                    region.Value["Green"] = region.Value["Green"] % ConvertToHigherTypeCount;
                    region.Value["Red"] += additionalReds;
                }*/

                /*if (region.Value["Red"] < 0)
                {
                    region.Value["Red"] = 0;
                    continue;
                }*/

                /*var additionalBlacks = region.Value["Red"] / ConvertToHigherTypeCount;
                region.Value["Red"] = region.Value["Red"] % ConvertToHigherTypeCount;
                region.Value["Black"] += additionalBlacks;*/

                /*if (region.Value["Black"] < 0)
                {
                    region.Value["Black"] = 0;
                }*/
            }

            var regionsByBlacksAndNames = regionMeteors.OrderByDescending(region => region.Value["Black"]).ThenBy(region => region.Key.Length).ThenBy(region => region.Key);

            foreach (var region in regionsByBlacksAndNames)
            {
                Console.WriteLine(region.Key);
                var orderedByMeteorsCountAndNames =
                    region.Value.OrderByDescending(meteorType => meteorType.Value).ThenBy(meteorType => meteorType.Key);
                foreach (var meteorType in orderedByMeteorsCountAndNames)
                {
                    Console.WriteLine($"-> {meteorType.Key} : {meteorType.Value}");
                }
            }
        }
    }
}
