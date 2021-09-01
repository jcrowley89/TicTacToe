using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Game
    {
        public bool Active { get; set; }
        public bool CurrentPlayerX { get; set; }
        public char CurrentPlayer => CurrentPlayerX ? 'X' : 'O';

        private char[] state = new char[9] { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
        private int[,] winningCombos = new int[8, 3] {
            { 0, 3, 6 }, // Column 1
            { 1, 4, 7 }, // Column 2
            { 2, 5, 8 }, // Column 3
            { 0, 1, 2 }, // Row 1
            { 3, 4, 5 }, // Row 2
            { 6, 7, 8 }, // Row 3
            { 0, 4, 8 }, // Diag 1
            { 2, 4, 6 } // Diag 2
        };

        public void PromptToStart()
        {
            GameInfo.Header();
            Console.WriteLine("Press any key to start game.");
            Console.ReadKey();
            Console.Clear();
        }

        public void Start()
        {
            CurrentPlayerX = true;
            Active = true;
        }

        public int PromptForPlay()
        {
            Console.Clear();
            GameInfo.Header();
            RenderBoard();
            Utils.WriteLineInColor(ConsoleColor.Yellow, $"\n{CurrentPlayer}'s turn. Choose a square:");
            int playerChoice;
            try
            {
                playerChoice = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                playerChoice = 9;
            }
            return playerChoice;
        }

        public void End()
        {
            Utils.WriteLineInColor(ConsoleColor.Yellow, "Press any key to exit.");
            Console.ReadKey();
            Console.Clear();
        }

        /**
        * Places square on game board and returns the appropriate output
        */
        public void PlaySquare(int square)
        {
            Console.Clear();
            if (square <= 8 && state[square] != 'X' && state[square] != 'O')
            {
                state[square] = CurrentPlayer;
                RenderBoard();
                if (PlayerWon())
                {
                    Active = false;
                    return;
                }
                else if (BoardIsFull())
                {
                    Active = false;
                    GameInfo.Header();
                    RenderBoard();
                    Utils.WriteLineInColor(ConsoleColor.Yellow, "\nIt's a draw.");
                    return;
                }
                CurrentPlayerX = !CurrentPlayerX;
                return;
            }
            else
            {
                Utils.WriteLineInColor(ConsoleColor.Red, "Illegal Move");
                return;
            }
        }

        private void RenderSquare(char s)
        {
            if (s == 'X')
            {
                Utils.WriteInColor(ConsoleColor.Blue, $"{s}");
            } else if (s == 'O')
            {
                Utils.WriteInColor(ConsoleColor.Green, $"{s}");
            } else
            {
                Console.Write($"{s}");
            }
        }

        /**
         * Renders the gameboard with the given state array
         */
        private void RenderBoard()
        {
            Console.Write("\n ");
            RenderSquare(state[0]);
            Console.Write(" | ");
            RenderSquare(state[1]);
            Console.Write(" | ");
            RenderSquare(state[2]);
            Console.Write(" \n------------\n ");
            RenderSquare(state[3]);
            Console.Write(" | ");
            RenderSquare(state[4]);
            Console.Write(" | ");
            RenderSquare(state[5]);
            Console.Write(" \n------------\n ");
            RenderSquare(state[6]);
            Console.Write(" | ");
            RenderSquare(state[7]);
            Console.Write(" | ");
            RenderSquare(state[8]);
            Console.Write(" \n");
        }

        /**
         * Checks if the current player won the game
         */
        private bool PlayerWon()
        {
            bool roundWon = false;
            for (int i = 0; i <= 7; i++)
            {
                int[] winCombo = new int[3] { winningCombos[i, 0], winningCombos[i, 1], winningCombos[i, 2] };
                var currentPlayer = CurrentPlayer;
                var a = state[winCombo[0]];
                var b = state[winCombo[1]];
                var c = state[winCombo[2]];
                if (
                  a == currentPlayer &&
                  b == currentPlayer &&
                  c == currentPlayer
                )
                {
                    Utils.WriteLineInColor(ConsoleColor.Green, $"\n{currentPlayer} Won!");
                    roundWon = true;
                }
            }
            return roundWon;
        }

        /**
         * Checks if there are any valid squares left to play
         */
        private bool BoardIsFull()
        {
            foreach (char i in state)
            {
                if (i != 'X' && i != 'O')
                {
                    return false;
                }
            }
            return true;
        }
    }
}