using System.Collections.Generic;

namespace peach;

internal class Input
{
    internal static void PrintInput()
    {
        Console.Write("[");

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write(Directory.GetCurrentDirectory().Split('\\', '/')[^1]);
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("]");

        Console.Write($"{Data.Process}/{Data.Input} ");
    }

    internal static string GetInput()
    {
        List<char> text = new();
        string command = string.Empty;

        while (true)
        {
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
            {
                foreach (char c in text)
                {
                    command += c;
                }

                if (!string.IsNullOrWhiteSpace(command))
                {
                    Console.Write("\n");
                    return command;
                }
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                if (Console.CursorLeft > Shell.LIMIT_INPUT)
                {
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(" ");
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    text.RemoveAt(Console.CursorLeft - Shell.LIMIT_INPUT);
                }
            }
            else if (key.Key == ConsoleKey.P && key.Modifiers == ConsoleModifiers.Alt)
            {
                Console.Write("\n");
                return ":p";
            }
            else if (key.Key == ConsoleKey.C && key.Modifiers == ConsoleModifiers.Alt)
            {
                return ":c";
            }
            else if (key.Key == ConsoleKey.Tab)
            {
                List<string> FilesAndDirs = new();
                int TAB_COUNT = 0;
                int LENGTH = 0;

                foreach (string file in Directory.GetFiles(Directory.GetCurrentDirectory()))
                {
                    FilesAndDirs.Add(file.Split('/', '\\')[^1]);
                }
                foreach (string dir in Directory.GetDirectories(Directory.GetCurrentDirectory()))
                {
                    FilesAndDirs.Add(dir.Split('/', '\\')[^1]);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;

                while (true)
                {
                    Console.SetCursorPosition(Console.CursorLeft - LENGTH, Console.CursorTop);
                    for (int i = 0; i < LENGTH; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(Console.CursorLeft - LENGTH, Console.CursorTop);

                    Console.Write(FilesAndDirs[TAB_COUNT]);
                    LENGTH = FilesAndDirs[TAB_COUNT].Length;


                    var keyTab = Console.ReadKey(true);

                    if (keyTab.Key == ConsoleKey.Tab || keyTab.Key == ConsoleKey.RightArrow || keyTab.Key == ConsoleKey.UpArrow)
                    {
                        if (!(TAB_COUNT == FilesAndDirs.Count - 1))
                        {
                            TAB_COUNT++;
                        }
                    }
                    else if (keyTab.Key == ConsoleKey.LeftArrow || keyTab.Key == ConsoleKey.DownArrow)
                    {
                        if (!(TAB_COUNT == 0))
                        {
                            TAB_COUNT--;
                        }
                    }
                    else if (keyTab.Key == ConsoleKey.Backspace)
                    {
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.SetCursorPosition(Console.CursorLeft - LENGTH, Console.CursorTop);
                        for (int i = 0; i < LENGTH; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.SetCursorPosition(Console.CursorLeft - LENGTH, Console.CursorTop);
                        break;
                    }
                    else if (keyTab.Key == ConsoleKey.Enter)
                    {
                        foreach (char c in FilesAndDirs[TAB_COUNT])
                        {
                            text.Add(c);
                        }
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.SetCursorPosition(Console.CursorLeft - LENGTH, Console.CursorTop);
                        for (int i = 0; i < LENGTH; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.SetCursorPosition(Console.CursorLeft - LENGTH, Console.CursorTop);
                        Console.Write(FilesAndDirs[TAB_COUNT]);
                        break;
                    }
                }
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                int ARROW_COUNT = 0;
                int LENGTH = 0;

                Console.ForegroundColor = ConsoleColor.Yellow;

                while (true)
                {
                    try
                    {
                        Console.SetCursorPosition(Console.CursorLeft - LENGTH, Console.CursorTop);
                        for (int i = 0; i < LENGTH; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.SetCursorPosition(Console.CursorLeft - LENGTH, Console.CursorTop);
                        
                        Console.Write(Data.Commands[ARROW_COUNT]);
                        LENGTH = Data.Commands[ARROW_COUNT].Length;
                    }
                    catch
                    {
                        break;
                    }
                    var keyArrow = Console.ReadKey(true);

                    if (keyArrow.Key == ConsoleKey.RightArrow || keyArrow.Key == ConsoleKey.UpArrow)
                    {
                        if (!(ARROW_COUNT == Data.Commands.Count - 1))
                        {
                            ARROW_COUNT++;
                        }
                    }
                    else if (keyArrow.Key == ConsoleKey.LeftArrow || keyArrow.Key == ConsoleKey.DownArrow)
                    {
                        if (!(ARROW_COUNT == 0))
                        {
                            ARROW_COUNT--;
                        }
                    }
                    else if (keyArrow.Key == ConsoleKey.Backspace)
                    {
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.SetCursorPosition(Console.CursorLeft - LENGTH, Console.CursorTop);
                        for (int i = 0; i < LENGTH; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.SetCursorPosition(Console.CursorLeft - LENGTH, Console.CursorTop);
                        break;
                    }
                    else if (keyArrow.Key == ConsoleKey.Enter)
                    {
                        foreach (char c in Data.Commands[ARROW_COUNT])
                        {
                            text.Add(c);
                        }
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.SetCursorPosition(Console.CursorLeft - LENGTH, Console.CursorTop);
                        for (int i = 0; i < LENGTH; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.SetCursorPosition(Console.CursorLeft - LENGTH, Console.CursorTop);
                        Console.Write(Data.Commands[ARROW_COUNT]);
                        break;
                    }
                }
            }
            else
            {
                text.Add(key.KeyChar);
                Console.Write(key.KeyChar);
            }
        }
    }
}
