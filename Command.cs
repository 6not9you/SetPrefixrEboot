using CommandSystem;
using Exiled.API.Features;
using System;

namespace Prefix
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class Comand : ICommand
    {
        public string Command { get; } = "SetPrefix";

        public string[] Aliases { get; } = new string[] { "Prefix" };

        public string Description { get; } = "Giving player prefix for 1 round";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count < 3)
            {
                response = "SetPrefix Id Color Name";
                return false;
            }
            if (!Player.TryGet(arguments.At(0), out var player))
            {
                response = "Wrong user ID";
                return false;
            }
            player.RankColor = arguments.At(1);
            string type = string.Empty;
            foreach (string name in arguments)
            {
                if (arguments.Array.IndexOf(name) > 2)
                {
                    type = type + " " + name;
                }
            }
            player.RankName = type;
            response = "successfully insulted a person";
            return true;
        }
    }
}
