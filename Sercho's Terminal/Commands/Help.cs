using System;

namespace Sercho_s_Terminal.Commands
{
    internal class Help : ICommand
    {
        public string Name => "help";
        public string Description => "Show available commands";

        public void Execute(string[] args)
        {
            Console.WriteLine("'date' - Show current date");
            Console.WriteLine("'time' - Show current time");
            Console.WriteLine("'git' - Use git commands");
            Console.WriteLine("'dir' - Lists files and folders");
            Console.WriteLine("'mkdir' - Creates a folder");
            Console.WriteLine("'cd' - Changes directory");
            Console.WriteLine("'clear' - Clears the screen");
            Console.WriteLine("'exit' - Exits terminal");
        }
    }
}