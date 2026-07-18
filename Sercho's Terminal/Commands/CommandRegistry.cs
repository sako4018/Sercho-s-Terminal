using System;
using System.Collections.Generic;
using System.Linq;

namespace Sercho_s_Terminal.Commands
{
    internal static class CommandRegistry
    {
        private static readonly Dictionary<string, ICommand> _commands =
            new Dictionary<string, ICommand>(StringComparer.OrdinalIgnoreCase);

        public static void Register(ICommand cmd)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
            _commands[cmd.Name] = cmd;
        }

        public static bool TryGet(string name, out ICommand cmd) => _commands.TryGetValue(name, out cmd);

        public static IEnumerable<ICommand> GetAll() => _commands.Values.OrderBy(c => c.Name);
    }
}