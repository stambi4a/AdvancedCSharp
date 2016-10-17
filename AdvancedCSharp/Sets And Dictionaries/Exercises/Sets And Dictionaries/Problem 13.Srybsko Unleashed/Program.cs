namespace Problem_13.Srybsko_Unleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class Program
    {
        static void Main(string[] args)
        {
            FindFavoriteSerbianSinger();
        }

        public static void FindFavoriteSerbianSinger()
        {
            Dictionary<string, Dictionary<string, int>> venues = new Dictionary<string, Dictionary<string, int>>(StringComparer.InvariantCulture);
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                string[] input = line.Split(' ');

                bool isValidInput = CheckValidInput(input);
                if (isValidInput)
                {
                    AddMoneyToSingerToVenue(input, venues);
                }
            }

            PrintVenuesSingersMoney(venues);
        }

        private static void PrintVenuesSingersMoney(Dictionary<string, Dictionary<string, int>> venues)
        {
            foreach (var pair in venues)
            {
                Console.WriteLine(pair.Key);
                var singers = pair.Value.OrderByDescending(x => x.Value);
                foreach (var singer in singers)
                {
                    Console.WriteLine("#  {0} -> {1}", singer.Key, singer.Value);
                }
            }
        }

        private static void AddMoneyToSingerToVenue(string[] input, Dictionary<string, Dictionary<string, int>> venues)
        {
            int length = input.Length;
            string singerName = input[0];
            int index = 1;

            while (true)
            {
                if (input[index].StartsWith("@"))
                {
                    break;
                }

                singerName += " " + input[index];
                index++;
            }

            string venueName = input[index].TrimStart('@');
            index++;
            var i = index;
            for (index = i; index < length - 2; index++)
            {
                venueName += " " + input[index];
            }

            int ticketPrice = int.Parse(input[index]);

            index++;
            int ticketsCount = int.Parse(input[index]);

            int venueSingerTotalMoney = ticketPrice * ticketsCount;
            if (venues.ContainsKey(venueName))
            {
                if (venues[venueName].ContainsKey(singerName))
                {
                    venues[venueName][singerName] += venueSingerTotalMoney;
                }
                else
                {
                    venues[venueName].Add(singerName, venueSingerTotalMoney);
                }
            }
            else
            {
                Dictionary<string, int> singersByVenue = new Dictionary<string, int>(StringComparer.InvariantCulture);
                singersByVenue.Add(singerName, venueSingerTotalMoney);
                venues.Add(venueName, singersByVenue);
            }
        }

        private static bool CheckValidInput(string[] input)
        {
            int index = 0;
            bool isValid = input.Length >= 4;
            if (!isValid)
            {
                return false;
            }

            string pattern = @"[A-Za-z]+";
            isValid = Regex.Match(input[index], pattern).ToString() == input[index];
            if (!isValid)
            {
                return false;
            }

            index++;
            while (true)
            {
                isValid = Regex.Match(input[index], pattern).ToString() == input[index];
                if (!isValid)
                {
                    break;
                }

                index++;
            }

            pattern = @"@[A-Za-z]+";
            isValid = Regex.Match(input[index], pattern).ToString() == input[index];
            if (!isValid)
            {
                return false;
            }

            index++;

            pattern = @"[A-Za-z]+";
            while (true)
            {
                isValid = Regex.Match(input[index], pattern).ToString() == input[index];
                if (!isValid)
                {
                    break;
                }

                index++;
            }

            int number;
            bool isValidNumber = int.TryParse(input[index], out number);
            if (!isValidNumber)
            {
                return false;
            }

            index++;
            isValidNumber = int.TryParse(input[index], out number);
            if (!isValidNumber)
            {
                return false;
            }

            return isValidNumber;
        }
    }
}
