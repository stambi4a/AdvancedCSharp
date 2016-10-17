namespace Problem_18.Radioactive_Mutant_Bunnies
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            EscapeTheBunnies();
        }

        public static void EscapeTheBunnies()
        {
            char[,] lair = InputLair();
            char[] directions = Console.ReadLine().ToCharArray();
            int[] playerCoordinates = FindPlayerCoordinates(lair);
            lair[playerCoordinates[0], playerCoordinates[1]] = '.';
            int length = directions.Length;
            string finalScore = "won";
            foreach (var direction in directions)
            {
                ExecuteCommand(lair, direction, playerCoordinates);
                BreedBunnies(lair);

                if (CheckIfExcapedLair(lair, playerCoordinates))
                {
                    CheckPlayerCoordinates(lair, playerCoordinates);
                    break;
                }

                if (CheckIfKilledByABunny(lair, playerCoordinates))
                {
                    finalScore = "dead";
                    break;
                }
            }

            PrintLair(lair);
            Console.Write("{0}: {1} {2}", finalScore, playerCoordinates[0], playerCoordinates[1]);
        }

        private static void CheckPlayerCoordinates(char[,] lair, int[] playerCoordinates)
        {
            int rows = lair.GetLength(0);
            int columns = lair.GetLength(1);
            if (playerCoordinates[0] == -1)
            {
                playerCoordinates[0] = 0;
            }

            if (playerCoordinates[0] == rows)
            {
                playerCoordinates[0] = rows - 1;
            }

            if (playerCoordinates[1] == -1)
            {
                playerCoordinates[1] = 0;
            }

            if (playerCoordinates[1] == columns)
            {
                playerCoordinates[1] = columns - 1;
            }
        }

        private static char[,] InputLair()
        {
            string[] lairSizes = Console.ReadLine().Split(' ');
            int rows = int.Parse(lairSizes[0]);
            int columns = int.Parse(lairSizes[1]);
            char[,] lair = new char[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < columns; j++)
                {
                    lair[i, j] = input[j];
                }
            }

            return lair;
        }

        private static int[] FindPlayerCoordinates(char[,] lair)
        {
            int rows = lair.GetLength(0);
            int columns = lair.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (lair[i, j] == 'P')
                    {
                        return new[] { i, j };
                    }
                }
            }

            return new[] { 0, 0 };
        }

        private static void ExecuteCommand(char[,] lair, char direction, int[] playerCoordinates)
        {
            switch (direction)
            {
                case 'U':
                    {
                        playerCoordinates[0]--;
                    }

                    break;
                case 'D':
                    {
                        playerCoordinates[0]++;
                    }

                    break;
                case 'L':
                    {
                        playerCoordinates[1]--;
                    }

                    break;
                case 'R':
                    {
                        playerCoordinates[1]++;
                    }

                    break;
                default:
                    {
                        break;
                    }
            }
        }

        private static bool CheckIfKilledByABunny(char[,] lair, int[] playerCoordinates)
        {
            bool KilledByABunny = lair[playerCoordinates[0], playerCoordinates[1]] == 'B';

            return KilledByABunny;
        }

        private static bool CheckIfExcapedLair(char[,] lair, int[] playerCoordinates)
        {
            int rows = lair.GetLength(0);
            int columns = lair.GetLength(1);
            bool hasEscaped = playerCoordinates[0] == -1
                || playerCoordinates[0] == rows
                || playerCoordinates[1] == -1
                || playerCoordinates[1] == columns;

            return hasEscaped;
        }

        private static void BreedBunnies(char[,] lair)
        {
            int rows = lair.GetLength(0);
            int columns = lair.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (lair[i, j] == 'B')
                    {
                        if (i < rows - 1 && lair[i + 1, j] != 'B')
                        {
                            lair[i + 1, j] = 'b';
                        }

                        if (i > 0 && lair[i - 1, j] != 'B')
                        {
                            lair[i - 1, j] = 'b';
                        }

                        if (j < columns - 1 && lair[i, j + 1] != 'B')
                        {
                            lair[i, j + 1] = 'b';
                        }

                        if (j > 0 && lair[i, j - 1] != 'B')
                        {
                            lair[i, j - 1] = 'b';
                        }
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (lair[i, j] == 'b')
                    {
                        lair[i, j] = 'B';
                    }
                }
            }
        }

        private static void PrintLair(char[,] lair)
        {
            int rows = lair.GetLength(0);
            int columns = lair.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(lair[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
