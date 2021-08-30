using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Splash Screen
            Utils.WriteLineInColor(ConsoleColor.Blue, GameInfo.Header);
            Utils.WriteLineInColor(ConsoleColor.Green, $"     by {GameInfo.Author}\n");

            Console.WriteLine("Press any key to start game.");
            Console.ReadKey();
            Console.Clear();

            // Game Setup
            var game = new Game();
            game.CurrentPlayerX = true;
            game.Active = true;
            Utils.WriteLineInColor(ConsoleColor.Green, GameInfo.SampleBoard);
            while (game.Active == true)
            {
                Utils.WriteLineInColor(ConsoleColor.Yellow, $"\n{game.GetCurrentPlayer()}'s turn. Choose a square:");
                int.TryParse(Console.ReadLine(), out int playerChoice);
                Utils.WriteLineInColor(ConsoleColor.Green, game.PlaySquare(playerChoice));
            }
        }
    }
}
