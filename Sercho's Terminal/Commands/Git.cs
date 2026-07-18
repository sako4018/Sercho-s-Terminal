using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sercho_s_Terminal.Commands
{
    internal class Git
    {
        public void Execute(string command)
        {
            string arguments = command.Substring(3).Trim();
            Process process = new Process();
            process.StartInfo.FileName = "git";
            process.StartInfo.Arguments = arguments;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();

            Console.WriteLine(output);
        }
    }
}
