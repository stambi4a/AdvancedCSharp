using System;

namespace Problem_14.Dragon_Army
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    class Program
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dragons = new Dictionary<string, SortedDictionary<string, Dragon>>();
            int dragonCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < dragonCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                string type = input[0];
                string name = input[1];
                int parseableValue = 0;
                int? damage = int.TryParse(input[2], out parseableValue) ? (int?)parseableValue : null;
                int? health = int.TryParse(input[3], out parseableValue) ? (int?)parseableValue : null;
                int? armor = int.TryParse(input[4], out parseableValue) ? (int?)parseableValue : null;

                Dragon dragon = new Dragon(name, damage, health, armor);
                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new SortedDictionary<string, Dragon>());
                }

                if (dragons[type].ContainsKey(name))
                {
                    dragons[type].Remove(name);
                }

                dragons[type].Add(name, dragon);
            }

            foreach (var dragonType in dragons)
            {
                double? averageDamage = dragonType.Value.Values.Sum(x=>x.Damage) / (double)dragonType.Value.Count;
                double? averageHealth = dragonType.Value.Values.Sum(x => x.Health) / (double)dragonType.Value.Count;
                double? averageArmor = dragonType.Value.Values.Sum(x => x.Armor) / (double)dragonType.Value.Count;
                Console.WriteLine($"{dragonType.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");
                foreach (var dragon in dragons[dragonType.Key])
                {
                    Console.WriteLine(dragon.Value);
                }
            }
        }
    }
}

public class Dragon
{
    private const int DefaultDamage = 45;
    private const int DefaultHealth = 250;
    private const int DefaultArmor = 10;

    public Dragon(string name, int? damage, int? health, int? armor)
    {
        this.Name = name;
        this.Damage = damage ?? DefaultDamage;
        this.Health = health ?? DefaultHealth;
        this.Armor =  armor ?? DefaultArmor;
    }

    public string Name { get; }

    public int? Damage { get; }

    public int? Health { get; set; }

    public int? Armor { get; set; }

    public override string ToString()
    {
        return $"-{this.Name} -> damage: {this.Damage}, health: {this.Health}, armor: {this.Armor}";
    }
}
