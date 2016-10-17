namespace Problem_01.Jedi_Meditation
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var countLines = int.Parse(Console.ReadLine());
            var masters = new List<string>();
            var knights = new List<string>();
            var padowans = new List<string>();
            var toshkosAndSlavsBeforeYodaArrives = new List<string>();
            var toshkosAndSlavsAfterYodaArrives = new List<string>();
            var yodaIsArrived = false;
            for (var i = 0; i < countLines; i++)
            {
                var jedis = Console.ReadLine().Split();
                foreach (var jedi in jedis)
                {
                    if (jedi.StartsWith("m"))
                    {
                        masters.Add(jedi);
                    }

                    if (jedi.StartsWith("k"))
                    {
                        knights.Add(jedi);
                    }

                    if (jedi.StartsWith("p"))
                    {
                        padowans.Add(jedi);
                    }

                    if (jedi.StartsWith("s") || jedi.StartsWith("t"))
                    {
                        toshkosAndSlavsBeforeYodaArrives.Add(jedi);
                    }

                    if (jedi.StartsWith("y") && !yodaIsArrived)
                    {
                        yodaIsArrived = true;
                    }
                }
            }

            var jediOrder = new List<string>();
            if (!yodaIsArrived)
            {
                jediOrder.AddRange(toshkosAndSlavsBeforeYodaArrives);
            }

            jediOrder.AddRange(masters);
            jediOrder.AddRange(knights);

            if (yodaIsArrived)
            {
                jediOrder.AddRange(toshkosAndSlavsBeforeYodaArrives);
            }

            jediOrder.AddRange(padowans);

            Console.WriteLine(string.Join(" ", jediOrder));
        }
    }
}
