namespace Problem_17.Lego_Blocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            CheckLegoBlocksFormRectangle();
        }

        public static void CheckLegoBlocksFormRectangle()
        {
            int numberOfRows = int.Parse(Console.ReadLine().Trim());
            var firstArray = InputJaggedArray(numberOfRows);
            var secondArray = InputJaggedArray(numberOfRows);

            secondArray = ReverseJaggedArray(secondArray);
            var areRectangle = CheckIfRectangle(firstArray, secondArray, numberOfRows);

            if (areRectangle)
            {
                var rectangle = JoinTwoJaggedArraysIntoRectangle(firstArray, secondArray, numberOfRows);
                PrintDoubleArray(rectangle);
            }
            else
            {
                var numberOfCells = GetNumberOfCells(firstArray, numberOfRows)
                                 + GetNumberOfCells(secondArray, numberOfRows);
                Console.WriteLine("The total number of cells is: " + numberOfCells);
            }
        }

        private static bool CheckIfRectangle(IReadOnlyList<int[]> firstArray, IReadOnlyList<int[]> secondArray, int numberOfRows)
        {
            var rectangleWidth = firstArray[0].Length + secondArray[0].Length;
            var index = 1;
            while (index < numberOfRows)
            {
                var rowWidth = firstArray[index].Length + secondArray[index].Length;
                var areRectangle = rowWidth == rectangleWidth;
                if (!areRectangle)
                {
                    return false;
                }

                index++;
            }

            return true;
        }

        private static int GetNumberOfCells(int[][] jaggedarray, int numberOfRows)
        {
            int numberOfCells = 0;
            for (var i = 0; i < numberOfRows; i++)
            {
                numberOfCells += jaggedarray[i].Length;
            }

            return numberOfCells;
        }

        private static int[][] JoinTwoJaggedArraysIntoRectangle(IReadOnlyList<int[]> firstArray, IReadOnlyList<int[]> secondArray, int numberOfRows)
        {
            int[][] rectangle = new int[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++)
            {
                var line = new List<int>();
                line.AddRange(firstArray[i]);
                line.AddRange(secondArray[i]);
                rectangle[i] = line.ToArray();
            }

            return rectangle;
        }

        public static int[][] InputJaggedArray(int numberOfRows)
        {
            int[][] jaggedArray = new int[numberOfRows][];

            for (int i = 0; i < numberOfRows; i++)
            {
                string inputLine = Console.ReadLine().Trim();
                var someArray = string.IsNullOrEmpty(inputLine) ? new int[0] : inputLine.Trim().Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                
                jaggedArray[i] = someArray;
            }

            return jaggedArray;
        }

        public static int[][] ReverseJaggedArray(int[][] jaggedArray)
        {
            for (var rowIndex = 0; rowIndex <= jaggedArray.GetUpperBound(0); rowIndex++)
            {
                jaggedArray[rowIndex] = jaggedArray[rowIndex].Reverse().ToArray();
            }

            return jaggedArray;
        }

        public static void PrintDoubleArray(int[][] rectangle)
        {
            for (int i = 0; i <= rectangle.GetUpperBound(0); i++)
            {
                Console.WriteLine($"[{string.Join(", ", rectangle[i])}]");
            }
        }
    }
}
