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

        /**
         * Stores the game state array indexes for each winning combination
         */
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

        /**
         * Returns the correct char for the currently active player
         */
        public char GetCurrentPlayer()
        {
            return CurrentPlayerX ? 'X' : 'O';
        }

        /**
        * Places square on game board and returns the appropriate output
        */
        public string PlaySquare(int square)
        {
            Console.Clear();
            if (square <= 8 && state[square] != 'X' && state[square] != 'O')
            {
                state[square] = GetCurrentPlayer();
                var board = Render(state);
                if (PlayerWon())
                {
                    Active = false;
                    return $"{GetCurrentPlayer()} won!";
                }
                else if (BoardIsFull())
                {
                    Active = false;
                    return "It's a draw";
                }
                CurrentPlayerX = !CurrentPlayerX;
                return board;
            }
            else
            {
                return $"{Render(state)}\n\nIllegal move.";
            }
        }

        /**
         * Tracks the state of the gameboard in an array
         */
        private char[] state = new char[9] { '0', '1', '2', '3', '4', '5', '6', '7', '8' };

        /**
         * Renders the gameboard with the given state array
         */
        private string Render(char[] state)
        {
            return $"\n   {state[0]} | {state[1]} | {state[2]} \n  -----------\n   {state[3]} | {state[4]} | {state[5]}\n  -----------\n   {state[6]} | {state[7]} | {state[8]} ";
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
                var currentPlayer = GetCurrentPlayer();
                var a = state[winCombo[0]];
                var b = state[winCombo[1]];
                var c = state[winCombo[2]];
                if (
                  a == currentPlayer &&
                  b == currentPlayer &&
                  c == currentPlayer
                )
                {
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