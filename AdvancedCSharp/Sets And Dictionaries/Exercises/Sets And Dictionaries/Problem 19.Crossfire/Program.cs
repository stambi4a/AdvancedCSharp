namespace Problem_19.Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var inputParams = Console.ReadLine().Split();
            var rows = int.Parse(inputParams[0]);
            var columns = int.Parse(inputParams[1]);
            var matrix = new int[rows][];

            for (var i = 0; i < rows; i++)
            {
                matrix[i] = new int[columns];
                for (int j = 0; j < columns; j++)
                {
                    matrix[i][j] = i * columns + j + 1;
                }
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("Nuke it from orbit"))
                {
                    break;
                }

                inputParams = input.Split();
                var row = int.Parse(inputParams[0]);
                var column = int.Parse(inputParams[1]);
                var radius = int.Parse(inputParams[2]);
                DestroyCells(matrix, row, column, radius);
            }

            PrintMatrix(matrix);
        }

        private static void DestroyCells(IList<int[]> matrix, int row, int column, int radius)
        {
            var rows = matrix.Count;
            var crossUp = row - radius;
            var crossDown = row + radius;
            if (crossUp >= rows || crossDown < 0)
            {
                return;
            }

            crossDown = crossDown < rows - 1 ? crossDown : rows - 1;
            crossUp = crossUp > 0 ? crossUp : 0;
            for (var i = crossDown; i >= crossUp; i--)
            {
                if (matrix[i] == null)
                {
                    continue;
                }

                var columns = matrix[i].Length;
                if (i == row)
                {
                    var crossRight = column + radius;
                    var crossLeft = column - radius;
                    if (crossRight < 0 || crossLeft >= columns)
                    {
                        continue;
                    }

                    crossLeft = crossLeft > 0 ? crossLeft : 0;
                    crossRight = crossRight < columns - 1 ? crossRight : columns - 1;

                    var crossSpan = crossRight - crossLeft + 1;

                    for (var j = crossLeft; j < columns - crossSpan; j++)
                    {
                        matrix[i][j] = matrix[i][j + crossSpan];
                    }

                    matrix[i] = matrix[i].Take(columns - crossSpan).ToArray();
                    if (matrix[i].Length > 0)
                    {
                        continue;
                    }

                    for (var j = i; j < rows - 1; j++)
                    {
                        matrix[j] = matrix[j + 1];
                    }

                    matrix[rows - 1] = null;

                    continue;
                }

                if (column == columns - 1)
                {
                    matrix[i] = matrix[i].Take(columns - 1).ToArray();
                    continue;
                }

                if (column >= 0 && column < columns - 1)
                {
                    for (var j = column; j < columns - 1; j++)
                    {
                        matrix[i][j] = matrix[i][j + 1];
                    }

                    matrix[i] = matrix[i].Take(columns - 1).ToArray();
                }

                if (matrix[i].Length > 0)
                {
                    continue;
                }

                for (var j = i; j < rows - 1; j++)
                {
                    matrix[j] = matrix[j + 1];
                }

                matrix[rows - 1] = null;
            }     
        }

        private static void PrintMatrix(IReadOnlyList<int[]> matrix)
        {
            var rows = matrix.Count;
            for (var i = 0; i < rows; i++)
            {
                if (matrix[i] == null)
                {
                    continue;
                }

                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }
    }
}
