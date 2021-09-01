using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.PromptToStart();
            game.Start();

            // Main Loop
            while (game.Active == true)
            {
                int playerChoice = game.PromptForPlay();
                game.PlaySquare(playerChoice);
            }

            game.End();
        }
    }
}
