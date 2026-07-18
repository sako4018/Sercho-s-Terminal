using Sercho_s_Terminal.Commands;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Sercho_s_Terminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Register commands
            CommandRegistry.Register(new Help());
            CommandRegistry.Register(new Cd());
            CommandRegistry.Register(new Dir());
            CommandRegistry.Register(new Git());
            // Register additional ICommand implementations if present:
            // CommandRegistry.Register(new Mkdir());
            // CommandRegistry.Register(new DateCmd());
            // CommandRegistry.Register(new TimeCmd());
            // CommandRegistry.Register(new Clear());
            // CommandRegistry.Register(new Exit());

            Console.WriteLine("=============================");
            Console.WriteLine("   Sercho's Terminal v1.0");
            Console.WriteLine("=============================\n");
            Console.WriteLine("--- for all commands type 'help' ---");

            Directory.SetCurrentDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

            while (true)
            {
                Console.Write($"\n{Environment.CurrentDirectory}> ");
                var line = Console.ReadLine() ?? string.Empty;
                var parts = ParseArguments(line).ToArray();
                if (parts.Length == 0) continue;

                var cmdName = parts[0];
                var cmdArgs = parts.Skip(1).ToArray();

                if (CommandRegistry.TryGet(cmdName, out var cmd))
                {
                    cmd.Execute(cmdArgs);
                    if (string.Equals(cmdName, "exit", StringComparison.OrdinalIgnoreCase))
                        break;
                    continue;
                }

                // Not a built-in command: try launching external executable
                try
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = cmdName,
                        Arguments = string.Join(" ", cmdArgs),
                        WorkingDirectory = Environment.CurrentDirectory,
                        UseShellExecute = false
                    };
                    Process.Start(psi)?.Dispose();
                }
                catch
                {
                    Console.WriteLine($"'{cmdName}' is not recognized as a command.");
                }
            }
        }

        // Tokenizer: supports quoted args ("..." and '...')
        private static IEnumerable<string> ParseArguments(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) yield break;

            var sb = new StringBuilder();
            bool inQuote = false;
            char quoteChar = '\0';

            for (int i = 0; i < input.Length; i++)
            {
                var c = input[i];
                if (inQuote)
                {
                    if (c == quoteChar)
                    {
                        inQuote = false;
                        yield return sb.ToString();
                        sb.Clear();
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                else
                {
                    if (char.IsWhiteSpace(c))
                    {
                        if (sb.Length > 0)
                        {
                            yield return sb.ToString();
                            sb.Clear();
                        }
                    }
                    else if (c == '"' || c == '\'')
                    {
                        inQuote = true;
                        quoteChar = c;
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
            }

            if (sb.Length > 0) yield return sb.ToString();
        }
    }
}