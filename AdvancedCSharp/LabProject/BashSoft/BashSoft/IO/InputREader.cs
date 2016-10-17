namespace BashSoft
{
    using System;

    using SimpleJudge;

    public static class InputReader
    {
        private const string EndCommand = "quit";
        public static void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                string input = Console.ReadLine();
                if (input.Equals(EndCommand))
                {
                    break;
                }

                input = input.Trim();
                CommandInterpreter.InterpretCommand(input);
            }
        }
    }
}
