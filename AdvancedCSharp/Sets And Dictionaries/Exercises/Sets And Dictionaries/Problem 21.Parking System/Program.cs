namespace Problem_21.Parking_System
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            ParkACar();
        }

        public static void ParkACar()
        {
            string[] input = Console.ReadLine().Split();
            int rows = int.Parse(input[0]);
            int columns = int.Parse(input[1]);

            var parkingLot = new byte[rows, columns];
            while (true)
            {
                string line = Console.ReadLine();
                if (line.Equals("stop"))
                {
                    break;
                }

                input = line.Split();
                int entryRow = int.Parse(input[0]);
                int parkingRow = int.Parse(input[1]);
                int parkingColumn = int.Parse(input[2]);
                if (entryRow >= 0 || entryRow < rows && parkingRow >= 0 && parkingRow < rows && parkingColumn >= 1
                    || parkingColumn < columns)
                {
                    int passedSpots = CheckParkingSpot(parkingLot, entryRow, parkingRow, parkingColumn);
                    if (passedSpots == 0)
                    {
                        Console.WriteLine($"Row {parkingRow} full");
                    }
                    else
                    {
                        Console.WriteLine(passedSpots);
                    }
                }
            }

        }

        public static int CheckParkingSpot(byte[,] parkingLot, int entryRow, int parkingRow, int parkingColumn)
        {
            int columns = parkingLot.GetLength(1);
            int passedSpots = 1 + Math.Abs(parkingRow - entryRow);
            if (parkingLot[parkingRow, parkingColumn] == 0)
            {
                parkingLot[parkingRow, parkingColumn] = 1;
                return passedSpots + parkingColumn;
            }

            int j = 1;
            while (true)
            {
                if (parkingColumn - j <= 0 && parkingColumn + j >= columns)
                {
                    break;
                }

                int i = parkingColumn - j;
                if (i > 0 && parkingLot[parkingRow, i] == 0)
                {
                    parkingLot[parkingRow, i] = 1;
                    return passedSpots + i;
                }

                i = parkingColumn + j;
                if (i < columns && parkingLot[parkingRow, i] == 0)
                {
                    parkingLot[parkingRow, i] = 1;
                    return passedSpots + i;
                }

                j++;
            }

            return 0;
        }
    }
}
