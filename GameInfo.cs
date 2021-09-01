using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public static class GameInfo
    {
        public static string TitleArt = "  _______ _        _______           _______         \r\n |__   __(_)      |__   __|         |__   __|        \r\n    | |   _  ___     | | __ _  ___     | | ___   ___ \r\n    | |  | |/ __|    | |/ _` |/ __|    | |/ _ \\ / _ \\\r\n    | |  | | (__     | | (_| | (__     | | (_) |  __/\r\n    |_|  |_|\\___|    |_|\\__,_|\\___|    |_|\\___/ \\___|\r\n";
        public static string Author = "John Crowley";

        public static void Header()
        {
            Console.Clear();
            Utils.WriteLineInColor(ConsoleColor.Blue, TitleArt);
            Utils.WriteLineInColor(ConsoleColor.Green, $"     by {Author}\n");
        }
    }
}
