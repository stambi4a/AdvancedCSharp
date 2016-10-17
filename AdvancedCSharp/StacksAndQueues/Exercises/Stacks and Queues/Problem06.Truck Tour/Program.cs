namespace Problem06.Truck_Tour
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int countPomps = int.Parse(Console.ReadLine());
            var queue = new Queue<int>();
            for (int i = 0; i < countPomps; i++)
            {
                string[] input = Console.ReadLine().Split();
                int reserve = int.Parse(input[0]);
                int distance = int.Parse(input[1]);
                int remain = reserve - distance;
                queue.Enqueue(remain);
            }

            int index = 0;

            var transfer = new Queue<int>();
            while (true)
            {
                int unusedFuelFromPomp = queue.Dequeue();
                transfer.Enqueue(unusedFuelFromPomp);
                long truckReserve = unusedFuelFromPomp;

                while (truckReserve >= 0 && queue.Count > 0)
                {
                    unusedFuelFromPomp = queue.Dequeue();
                    transfer.Enqueue(unusedFuelFromPomp);
                    truckReserve += unusedFuelFromPomp;
                }

                if (queue.Count == 0)
                {
                    break;
                }

                index += transfer.Count;
                while (transfer.Count > 0)
                {
                    queue.Enqueue(transfer.Dequeue());
                }
            }

            Console.WriteLine(index);
        }
    }
}
