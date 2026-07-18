using Sercho_s_Terminal.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sercho_s_Terminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*  Console.WriteLine("'date' - Show current (day,month,year)");
                    Console.WriteLine("'time' - Show current (hours,minutes,seconds)");
                    //Console.WriteLine("'dir' - Lists files and folders");
                    Console.WriteLine("'mkdir' - Creates a folder");
                    Console.WriteLine("'cd' - Changes directory");
                    Console.WriteLine("'clear' -  Clears the screen");
                    Console.WriteLine("'exit' - Exits terminal");
            */


            Console.WriteLine("=============================");
            Console.WriteLine("   Sercho's Terminal v1.0");
            Console.WriteLine("=============================\n");

            Console.WriteLine("--- for all commands type 'help' ---");
            string currentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            Directory.SetCurrentDirectory(currentDirectory);
            while (true)
            {
                Console.Write($"\n{Environment.CurrentDirectory}> ");
                string command = Console.ReadLine();
                if (command == "help")
                {
                    Help help = new Help();
                    help.Execute();

                }
                else if (command == "dir")
                {
                    Dir dir = new Dir();
                    dir.Execute();
                }
                else if (command.StartsWith("cd "))
                {
                    if (command == "")
                    {

                    }
                    Cd cd = new Cd();
                    cd.Execute(command);
                }
                else if (command == "exit")
                {
                    Exit exit = new Exit();
                    exit.Execute();
                    break;
                }
                else if (command == "clear")
                {
                    Console.Clear();
                }
                else if (command.StartsWith("mkdir "))
                {
                    string folderName = command.Substring(6).Trim();
                    Directory.CreateDirectory(folderName);
                }
                else if (command == "date")
                {
                    Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
                }
                else if (command == "time")
                {
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                }
                else if (command.StartsWith("git "))
                {
                    Git git = new Git();
                    git.Execute(command);
                }
                else
                {
                    Console.WriteLine($"'{command}' is not recognized as a command.");
                }
            }
        }
    }
}