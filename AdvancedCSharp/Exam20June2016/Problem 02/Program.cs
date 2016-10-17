namespace Problem_02
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var cube = new int[size, size, size];
            var hitCells = new bool[size, size, size]; 
            var sumCells = 0L;
            var countHitCells = Math.Pow(size, 3);
            while (true)
            {
                var inputLine = Console.ReadLine();
                if (inputLine.Equals("Analyze"))
                {
                    break;
                }

                var input = inputLine.Split();
                var xCoord = int.Parse(input[0]);
                var yCoord = int.Parse(input[1]);
                var zCoord = int.Parse(input[2]);
                var particles = int.Parse(input[3]);
                if (xCoord >= 0 && xCoord < size && yCoord >= 0 && yCoord < size && zCoord >= 0 && zCoord < size
                    && !hitCells[xCoord, yCoord, zCoord])
                {
                    cube[xCoord, yCoord, zCoord] = particles;
                    sumCells += particles;
                    if (particles != 0)
                    {
                        countHitCells--;
                    }

                    hitCells[xCoord, yCoord, zCoord] = true;
                }
            }

            Console.WriteLine(sumCells);
            Console.WriteLine(countHitCells);
        }
    }
}
