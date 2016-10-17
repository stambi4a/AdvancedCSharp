namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using SimpleJudge;

    public static class IOManager
    {
        public static void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIndentation = SessionData.currentPath.Split('\\').Length;
            Queue<string> subfolders = new Queue<string>();
            subfolders.Enqueue(SessionData.currentPath);

            while (subfolders.Count != 0)
            {
                string currentPath = subfolders.Dequeue();
                int indentation = currentPath.Split('\\').Length - initialIndentation;

                if (depth < indentation)
                {
                    break;
                }

                OutputWriter.WriteMessageOnNewLine($"{new string('-', indentation)}{currentPath}");
                var indexOfLastSlash = currentPath.Length;
                try
                {
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        string fileName = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine($"{new string('-', indexOfLastSlash)}{fileName}");
                    }
                    foreach (string directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subfolders.Enqueue(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessException);
                }
               
            }
        }

        public static void CreateDirectoryInCurrentFolder(string name)
        {
            string path = Directory.GetCurrentDirectory() + '\\' + name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsContainedInName);
            }
        }

        public static void ChangeCurrentDirectoryRelative(string relativePath)
        {
            try
            {
                string currentPath = SessionData.currentPath;
                if (relativePath == "..")
                {
                    int indexOfLastSlash = currentPath.LastIndexOf('\\');
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                }
                else
                {
                    currentPath += "\\" + relativePath;
                    ChangeCurrentDirectoryAbsolute(currentPath);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                OutputWriter.DisplayException(ExceptionMessages.UnableToGoHigherInTheHierarchy);
            }       
        }

        public static void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);

                return;
            }

            SessionData.currentPath = absolutePath;
        }
    }
}
