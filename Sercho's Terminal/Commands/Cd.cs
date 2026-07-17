using System;
using System.IO;

namespace Sercho_s_Terminal.Commands
{
    internal class Cd
    {
        public void Execute(string command)
        {
            string path = command.Substring(3).Trim();
            path = path.Trim('"');

            if (Directory.Exists(path))
            {
                Directory.SetCurrentDirectory(path);
            }
            else
            {
                Console.WriteLine("Directory not found");
            }
        }
    }
}