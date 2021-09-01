using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public static class Utils
    {
        public static void WriteInColor(ConsoleColor c, string s)
        {
            Console.ForegroundColor = c;
            Console.Write(s);
            Console.ResetColor();
        }

        public static void WriteLineInColor(ConsoleColor c, string s)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }
}
