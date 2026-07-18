using System;

namespace Sercho_s_Terminal.Commands
{
    internal interface ICommand
    {
        string Name { get; }
        string Description { get; }
        void Execute(string[] args);
    }
}