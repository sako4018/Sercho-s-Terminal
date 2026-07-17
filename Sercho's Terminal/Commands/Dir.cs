using System;
using System.IO;

namespace Sercho_s_Terminal.Commands
{
    internal class Dir
    {
        public void Execute()
        {
            string[] folders = Directory.GetDirectories(Environment.CurrentDirectory);
            string[] files = Directory.GetFiles(Environment.CurrentDirectory);

            foreach (string folder in folders)
            {
                Console.WriteLine("[DIR] " + Path.GetFileName(folder));
            }

            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }
    }
}