namespace Problem_20.The_Heigan_Dance
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;

    internal class Program
    {
        private const double HeiganHealth = 3000000;

        private const int PlayerHealth = 18500;

        private const int MatrixSize = 15;

        private const int PlagueCloudDamagePerTurn = 3500;

        private const int EruptionDamage = 6000;

        private const string HeiganDefeatedMessage = "Heigan: Defeated!";

        private const string PlayerDefeatedMessage = "Player: Killed by {0}";

        private const string HeiganNotDefeatedMessage = "Heigan: {0:f2}";

        private const string PlayerNotDefeatedMessage = "Player: {0}";

        private const string PositionMessage = "Final position: {0}, {1}";

        private static bool plagueCloudUsed = false;

        private static string lastSpellUsed = "Plague Cloud";

        private static int playerHealth = PlayerHealth;

        private static double heiganHealth = HeiganHealth;

        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            FightHeigan();
        }

        private static void FightHeigan()
        {
            var playerDamage = double.Parse(Console.ReadLine());
            var playerCoordinates = new int[2];
            playerCoordinates[0] = 7;
            playerCoordinates[1] = 7;
            while (true)
            {
                string input = Console.ReadLine();
                string[] inputParams = input.Split();
                PlayRound(inputParams, playerCoordinates, playerDamage);
                if (playerHealth <= 0 || heiganHealth <= 0)
                {
                    break;
                }
            }

            PrintResult(playerCoordinates);
        }

        private static void PrintResult(IReadOnlyList<int> playerCoordinates)
        {
            if (heiganHealth <= 0)
            {
                Console.Write(HeiganDefeatedMessage);
            }
            else
            {
                Console.Write(HeiganNotDefeatedMessage, heiganHealth);
            }

            Console.WriteLine();

            if (playerHealth <= 0)
            {
                Console.Write(PlayerDefeatedMessage, lastSpellUsed);
            }
            else
            {
                Console.Write(PlayerNotDefeatedMessage, playerHealth);
            }

            Console.WriteLine();

            Console.WriteLine(PositionMessage, playerCoordinates[0], playerCoordinates[1]);
        }

        private static void PlayRound(IReadOnlyList<string> inputParams, IList<int> playerCoordinates, double playerDamage)
        {
            heiganHealth -= playerDamage;
            if (plagueCloudUsed)
            {
                plagueCloudUsed = false;
                playerHealth -= PlagueCloudDamagePerTurn;
            }
            if (heiganHealth <= 0 || playerHealth <= 0)
            {
                return;
            }

            var row = int.Parse(inputParams[1]);
            var column = int.Parse(inputParams[2]);

            if (Math.Abs(playerCoordinates[0] - row) > 1 || Math.Abs(playerCoordinates[1] - column) > 1)
            {
                return;
            }

            var isHit = row == playerCoordinates[0] && column == playerCoordinates[1];

            if (!isHit)
            {
                int upCoordinate = playerCoordinates[0] - 1;
                if (upCoordinate >= 0 && Math.Abs(upCoordinate - row) > 1)
                {
                    playerCoordinates[0] = upCoordinate;
                    return;
                }
                isHit = true;

                var rightCoordinate = playerCoordinates[1] + 1;
                if (rightCoordinate <= MatrixSize - 1 && Math.Abs(rightCoordinate - column) > 1)
                {
                    playerCoordinates[1] = rightCoordinate;
                    return;
                }

                var downCoordinate = playerCoordinates[0] + 1;
                if (downCoordinate <= MatrixSize - 1 && Math.Abs(downCoordinate - row) > 1)
                {
                    playerCoordinates[0] = downCoordinate;
                    return;
                }

                var leftCoordinate = playerCoordinates[1] - 1;
                if (leftCoordinate >= 0 && Math.Abs(leftCoordinate - column) > 1)
                {
                    playerCoordinates[1] = leftCoordinate;
                    return;
                }
            }

            var spell = inputParams[0];
            if (spell.Equals("Cloud"))
            {
                lastSpellUsed = "Plague Cloud";
                playerHealth -= PlagueCloudDamagePerTurn;
                plagueCloudUsed = true;
            }

            if (!spell.Equals("Eruption"))
            {
                return;
            }

            lastSpellUsed = "Eruption";
            playerHealth -= EruptionDamage;
        }
    }
}
