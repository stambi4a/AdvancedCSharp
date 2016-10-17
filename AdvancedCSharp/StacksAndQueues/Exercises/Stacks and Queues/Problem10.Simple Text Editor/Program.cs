namespace Problem10.Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var letters = new List<char>();
            var commandStringsStack = new Stack<string>();
            var undoOperationsIndex = new Stack<byte>();
            var returnedElements = new List<char>();

            int commandCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                byte commandIndex = byte.Parse(input[0]); 

                switch (commandIndex)
                {
                    case 1:
                        {
                            string addedString = input[1];
                            letters.AddRange(addedString);
                            commandStringsStack.Push(addedString);
                            undoOperationsIndex.Push(commandIndex);
                        }

                        break;

                    case 2:
                        {
                            int count = int.Parse(input[1]);
                            string removedString = new string(letters.GetRange(letters.Count - count, count).ToArray());
                            letters.RemoveRange(letters.Count - count, count);
                            commandStringsStack.Push(removedString);
                            undoOperationsIndex.Push(commandIndex);
                        }

                        break;

                    case 3:
                        {
                            int index = int.Parse(input[1]);
                            returnedElements.Add(letters[index - 1]);

                        }

                        break;

                    case 4:
                        {
                            byte lastEditCommandIndex = undoOperationsIndex.Pop();
                            if (lastEditCommandIndex == 1)
                            {
                                string lastAddedString = commandStringsStack.Pop();
                                int length = lastAddedString.Length;
                                letters.RemoveRange(letters.Count - length, length);
                            }

                            if (lastEditCommandIndex == 2)
                            {
                                string lastRemovedLetters = commandStringsStack.Pop();
                                letters.AddRange(lastRemovedLetters);
                            }
                        }

                        break;
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, returnedElements));
        }
    }
}
