﻿namespace BashSoft.IO
{
    using System;

    public static class InputReader
    {
        public static void StartReadingCommands()
        {
            const string EndCommand = "quit";

            //OutputWriter.WriteMessage($"{SessionData.GetCurrentDirectoryPath()}> ");
            //string input = Console.ReadLine();
            //input = input.Trim();

            string input = string.Empty;

            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.GetCurrentDirectoryPath()}> ");
                input = Console.ReadLine();
                input = input.Trim();

                if (input.Equals(EndCommand))
                {
                    break;
                }
                else
                {
                    CommandInterpreter.InterpredCommand(input);
                }
            }
        }
    }
}