namespace Problem_15.Rubiks_Matrix
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string[] inputParams = Console.ReadLine().Split();
            int rows = int.Parse(inputParams[0]);
            int columns = int.Parse(inputParams[1]);
            int[, ] rubicMatrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    rubicMatrix[i, j] = (i * columns) + j + 1;
                }
            }

            int countLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < countLines; i++)
            {
                string input = Console.ReadLine();
                inputParams = input.Split();
                MoveVector(rubicMatrix, inputParams);
            }

            RearrangeRubicMatrix(rubicMatrix);
        }

        private static void RearrangeRubicMatrix(int[,] rubicMatrix)
        {
            int rows = rubicMatrix.GetLength(0);
            int columns = rubicMatrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int value = rubicMatrix[i, j];
                    int properValue = i * rows + j + 1;
                    if (value != properValue)
                    {
                        for (int k = 0; k < rows; k++)
                        {
                            for (int l = 0; l < columns; l++)
                            {
                                if (i != k || l != j)
                                {
                                    int local = rubicMatrix[k, l];
                                    if (local == properValue)
                                    {
                                        int swap = value;
                                        rubicMatrix[i, j] = properValue;
                                        rubicMatrix[k, l] = swap;
                                        Console.WriteLine($"Swap ({i}, {j}) with ({k}, {l})", i, j, k, l);
                                        break;
                                    }
                                }
                            }

                            if (rubicMatrix[i, j] == properValue)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                }
            }
        }

        private static void MoveRowRight(int[,] rubicMatrix, int moves, int row)
        {
            int columns = rubicMatrix.GetLength(1);
            int step = moves % columns;
            if (step == 0)
            {
                return;
            }

            int[] swap = new int[step];
            for (int i = step - 1; i >= 0; i--)
            {
                swap[i] = rubicMatrix[row, columns - (step - i)];
            }

            for (int i = columns - 1; i >= step; i--)
            {
                rubicMatrix[row, i] = rubicMatrix[row, i - step];
            }

            for (int i = 0; i < step; i++)
            {
                rubicMatrix[row, i] = swap[i];
            }
        }

        private static void MoveRowLeft(int[,] rubicMatrix, int moves, int row)
        {
            int columns = rubicMatrix.GetLength(1);
            int step = moves % columns;
            if (step == 0)
            {
                return;
            }

            int[] swap = new int[step];
            for (int i = 0; i < step; i++)
            {
                swap[i] = rubicMatrix[row, i];
            }

            for (int i = 0; i < columns - step; i++)
            {
                rubicMatrix[row, i] = rubicMatrix[row, i + step];
            }

            for (int i = 0; i < step; i++)
            {
                rubicMatrix[row, columns - step + i] = swap[i];
            }
        }

        private static void MoveColumnUp(int[,] rubicMatrix, int moves, int column)
        {
            int rows = rubicMatrix.GetLength(0);
            int step = moves % rows;
            if (step == 0)
            {
                return;
            }

            int[] swap = new int[step];
            for (int i = step - 1; i >= 0; i--)
            {
                swap[i] = rubicMatrix[i, column];
            }

            for (int i = 0; i < rows - step; i++)
            {
                rubicMatrix[i, column] = rubicMatrix[i + step, column];
            }

            for (int i = 0; i < step; i++)
            {
                rubicMatrix[rows - step + i, column] = swap[i];
            }
        }

        private static void MoveColumnDown(int[,] rubicMatrix, int moves, int column)
        {
            int rows = rubicMatrix.GetLength(0);
            int step = moves % rows;
            if (step == 0)
            {
                return;
            }

            int[] swap = new int[step];
            for (int i = 0; i < step; i++)
            {
                swap[i] = rubicMatrix[rows - (step - i), column];
            }

            for (int i = rows - 1; i >= step; i--)
            {
                rubicMatrix[i, column] = rubicMatrix[i - step, column];
            }

            for (int i = 0; i < step; i++)
            {
                rubicMatrix[i, column] = swap[i];
            }
        }

        private static void PrintRubicMatrix(int[,] rubicMatrix)
        {
            int rows = rubicMatrix.GetLength(0);
            int columns = rubicMatrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(rubicMatrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void MoveVector(int[,] rubicMatrix, string[] inputParams)
        {
            int vector = int.Parse(inputParams[0]);
            int moves = int.Parse(inputParams[2]);
            switch (inputParams[1]) {
            case "right" : {
                MoveRowRight(rubicMatrix, moves, vector);
    }

            break;

            case "left" : {
                MoveRowLeft(rubicMatrix, moves, vector);
}

            break;

            case "up" : {
                MoveColumnUp(rubicMatrix, moves, vector);
            }

            break;

            case "down" : {
                MoveColumnDown(rubicMatrix, moves, vector);
            }

            break;
        }
    }
    }
}
