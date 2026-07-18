using System;
using System.IO;

namespace Sercho_s_Terminal.Commands
{
    internal class Dir : ICommand
    {
        public string Name => "dir";
        public string Description => "List files and folders in the current directory";

        public void Execute(string[] args)
        {
            try
            {
                var dirs = Directory.GetDirectories(Environment.CurrentDirectory);
                var files = Directory.GetFiles(Environment.CurrentDirectory);

                foreach (var d in dirs)
                    Console.WriteLine("[DIR]  " + Path.GetFileName(d));

                foreach (var f in files)
                    Console.WriteLine("       " + Path.GetFileName(f));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error listing directory: {ex.Message}");
            }
        }
    }
}