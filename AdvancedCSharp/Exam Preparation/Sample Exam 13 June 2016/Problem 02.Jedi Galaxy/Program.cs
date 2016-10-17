namespace Problem_02.Jedi_Galaxy
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var rows = int.Parse(input[0]);
            var columns = int.Parse(input[1]);
            var matrix = new int[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    matrix[i, j] = i * columns + j;
                }
            }

            /*for (var i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }*/

            var sumCollectedStars = 0L;
            while (true)
            {
                var line = Console.ReadLine();
                if (line.Equals("Let the Force be with you"))
                {
                    break;
                }

                input = line.Split();
                var ivoRow = int.Parse(input[0]);
                var ivoCol = int.Parse(input[1]);

                input = Console.ReadLine().Split();
                var evilRow = int.Parse(input[0]);
                var evilCol = int.Parse(input[1]);

                while (evilRow >= rows)
                {
                    evilRow--;
                    evilCol--;
                }

                while (evilCol >= columns)
                {
                    evilRow--;
                    evilCol--;
                }

                for (int i = evilRow, j = evilCol; i >= 0 && j >= 0; i--, j--)
                {
                    matrix[i, j] = 0;
                }

                while (ivoRow >= rows)
                {
                    ivoRow--;
                    ivoCol++;
                }

                while (ivoCol < 0)
                {
                    ivoRow--;
                    ivoCol++;
                }

                for (int i = ivoRow, j = ivoCol; i >= 0 && j < columns; i--, j++)
                {
                    sumCollectedStars += matrix[i, j];
                }
            }

            Console.WriteLine(sumCollectedStars);
        }
    }
}
