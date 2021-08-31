using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Splash Screen
            Console.Clear();
            Utils.WriteLineInColor(ConsoleColor.Blue, GameInfo.Header);
            Utils.WriteLineInColor(ConsoleColor.Green, $"     by {GameInfo.Author}\n");

            Console.WriteLine("Press any key to start game.");
            Console.ReadKey();
            Console.Clear();

            // Game Setup
            Game game = new Game();
            game.CurrentPlayerX = true;
            game.Active = true;
            Utils.WriteLineInColor(ConsoleColor.Green, GameInfo.SampleBoard);
            while (game.Active == true)
            {
                Utils.WriteLineInColor(ConsoleColor.Yellow, $"\n{game.CurrentPlayer}'s turn. Choose a square:");
                int playerChoice;
                try
                {
                    playerChoice = Convert.ToInt32(Console.ReadLine());
                } catch
                {
                    playerChoice = 9;
                }
                Utils.WriteLineInColor(ConsoleColor.Green, game.PlaySquare(playerChoice));
            }

            Utils.WriteLineInColor(ConsoleColor.Yellow, "Press any key to exit.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
