using System;
using System.Diagnostics;

namespace Sercho_s_Terminal.Commands
{
    internal class Git
    {
        public void Execute(string command)
        {
            string arguments = "";

            if (command.Length > 3)
            {
                arguments = command.Substring(4);
            }

            ProcessStartInfo info = new ProcessStartInfo();

            info.FileName = "git";
            info.Arguments = arguments;
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;
            info.CreateNoWindow = true;

            Process process = new Process();
            process.StartInfo = info;

            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            if (!string.IsNullOrEmpty(output))
            {
                Console.WriteLine(output);
            }

            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine(error);
            }
        }
    }
}