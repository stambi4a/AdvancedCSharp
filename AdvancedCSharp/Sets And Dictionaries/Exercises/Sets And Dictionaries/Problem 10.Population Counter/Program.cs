using System;
using System.Collections.Generic;

namespace Problem_10.Population_Counter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var populationRegister = new Dictionary<string, SortedDictionary<int, string>>();
            var countriesPopulation = new Dictionary<string,long>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("report"))
                {
                    break;
                }

                string[] inputParams = input.Split('|');
                string country = inputParams[1];
                string city = inputParams[0];
                int population = int.Parse(inputParams[2]);

                if (!populationRegister.ContainsKey(country))
                {
                    populationRegister.Add(country, new SortedDictionary<int, string>(new DescendinOrderComparer()));
                    countriesPopulation.Add(country, 0);
                }

                if (!populationRegister[country].ContainsKey(population))
                {
                    populationRegister[country].Add(population, city);
                }

                countriesPopulation[country] += population;
            }

            var entries = SortCountriesByPopulation(countriesPopulation);
            foreach (var entry in entries)
            {
                string countryToPrint = entry.Key;
                Console.WriteLine($"{entry.Key} (total population: {entry.Value})");

                foreach (var cityToPrint in populationRegister[countryToPrint])
                {
                    Console.WriteLine($"=>{cityToPrint.Value}: {cityToPrint.Key}");

                }
            }
        }

        private static IEnumerable<KeyValuePair<string,  long>> SortCountriesByPopulation(Dictionary<string, long> countriesByPopulation)
        {
            var entries = countriesByPopulation.OrderByDescending(x=>x.Value);

            return entries;
        }
    }
}

internal class DescendinOrderComparer : IComparer<int>
{
    public int Compare(int str1, int str2)
    {
        return str2 - str1;
    }
}
