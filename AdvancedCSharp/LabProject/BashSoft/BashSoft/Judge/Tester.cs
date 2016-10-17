namespace SimpleJudge
{
    using System;
    using System.IO;

    using BashSoft;

    public static class Tester
    {
        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading files...");
            try
            {
                string mismatchPath = GetMismatchPath(expectedOutputPath);
                string[] actualOutputLines = File.ReadAllLines(userOutputPath);
                string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);
                bool hasMismatch = false;
                string[] mismatches = GetLinesWithPossibleMismatches(
                    actualOutputLines,
                    expectedOutputLines,
                    out hasMismatch);
                PrintOutput(mismatches, hasMismatch, mismatchPath);
                OutputWriter.WriteMessageOnNewLine("Files read!");
            }
            catch (FileNotFoundException)
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
        }

        private static string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, indexOf);
            string finalPath = directoryPath + @"\Mismatches.txt";
            return finalPath;
        }

        private static string[] GetLinesWithPossibleMismatches(
            string[] actualOutputString,
            string[] expectedOutputString,
            out bool hasMismatch)
        {
            hasMismatch = false;
            string output = string.Empty;
            string[] mismatches;
            OutputWriter.WriteMessageOnNewLine("Comparing files...");

            int minOutputLines = actualOutputString.Length;
            if (actualOutputString.Length != expectedOutputString.Length)
            {
                hasMismatch = true;
                minOutputLines = Math.Min(actualOutputString.Length, expectedOutputString.Length);
                mismatches = new string[minOutputLines];
                OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }
            else
            {
                mismatches = new string[actualOutputString.Length];
            }

            for (int index = 0; index < minOutputLines; index++)
            {
                string actualLine = actualOutputString[index];
                string expectedLine = expectedOutputString[index];

                if (!actualLine.Equals(expectedLine))
                {
                    output = string.Format(
                        "Mismatch at line {0} -- expected: \"{1}\", actual :\"{2}\"",
                        index,
                        expectedLine,
                        actualLine);
                    output += Environment.NewLine;
                    hasMismatch = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }

                mismatches[index] = output;
            }

            return mismatches;
        }

        private static void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchesPath)
        {
            if (hasMismatch)
            {
                foreach (var line in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(line);
                }

                try
                {
                    File.WriteAllLines(mismatchesPath, mismatches);
                }
                catch (DirectoryNotFoundException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                }

                return;
            }

            OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches");
        }
    }
}
