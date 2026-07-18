using System;
using System.IO;

namespace Sercho_s_Terminal.Commands
{
    internal class Cd : ICommand
    {
        private static string _previous = Environment.CurrentDirectory;

        public string Name => "cd";
        public string Description => "Change directory. Usage: cd [path]  (cd - returns to previous)";

        public void Execute(string[] args)
        {
            var arg = (args.Length > 0) ? args[0].Trim().Trim('"', '\'') : string.Empty;

            if (string.IsNullOrEmpty(arg))
            {
                ChangeTo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                return;
            }

            if (arg == "-")
            {
                ChangeTo(_previous);
                return;
            }

            if (arg.Length == 2 && arg[1] == ':')
                arg = arg + Path.DirectorySeparatorChar;

            string target = Path.IsPathRooted(arg)
                ? Path.GetFullPath(arg)
                : Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, arg));

            ChangeTo(target);
        }

        private void ChangeTo(string target)
        {
            try
            {
                if (Directory.Exists(target))
                {
                    _previous = Environment.CurrentDirectory;
                    Directory.SetCurrentDirectory(target);
                }
                else
                {
                    Console.WriteLine($"The system cannot find the path specified: {target}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error changing directory: {ex.Message}");
            }
        }
    }
}