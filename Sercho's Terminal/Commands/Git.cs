using System;
using System.Diagnostics;

namespace Sercho_s_Terminal.Commands
{
    internal class Git : ICommand
    {
        public string Name => "git";
        public string Description => "Proxy to system git. Usage: git [args]";

        public void Execute(string[] args)
        {
            var arguments = string.Join(" ", args ?? new string[0]);

            var info = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WorkingDirectory = Environment.CurrentDirectory
            };

            try
            {
                using (var p = new Process { StartInfo = info })
                {
                    p.OutputDataReceived += (s, e) => { if (e.Data != null) Console.WriteLine(e.Data); };
                    p.ErrorDataReceived += (s, e) => { if (e.Data != null) Console.WriteLine(e.Data); };

                    p.Start();
                    p.BeginOutputReadLine();
                    p.BeginErrorReadLine();
                    p.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to run git: {ex.Message}");
            }
        }
    }
}