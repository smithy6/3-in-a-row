using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2d_array_game_net
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare and initialize a 2D array for the game board
            char[,] gameBoard = new char[10, 10];
            InitializeGameBoard(gameBoard);

            // Display instructions and help for the game
            DisplayInstructions();

            // Main game loop
            bool gameOver = false;
            while (!gameOver)
            {
                // Display the game board
                DisplayGameBoard(gameBoard);

                // Get player's move
                int row = GetRow();
                int col = GetCol();

                // Update game board with player's move
                UpdateGameBoard(gameBoard, row, col);

                // Check if player has won or if the game is a draw
                gameOver = CheckGameStatus(gameBoard);
            }

            // Display final game board and game over message
            DisplayGameBoard(gameBoard);
            Console.WriteLine("Game over!");
        }

        // Initializes the game board with empty spaces
        static void InitializeGameBoard(char[,] gameBoard)
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    gameBoard[i, j] = ' ';
                }
            }
        }

        // Displays the instructions and help for the game
        static void DisplayInstructions()
        {
            Console.WriteLine("Welcome to the 2D Array Game!");
            Console.WriteLine("You will make your move by entering the row and column number where you want to place your piece.");
            Console.WriteLine("The top left corner is row 0, column 0 and the bottom right corner is row 9, column 9.");
            Console.WriteLine("The objective of the game is to get three of your pieces in a row (horizontally, vertically, or diagonally).");
            Console.WriteLine("Good luck!\n");
        }

        // Displays the game board
        static void DisplayGameBoard(char[,] gameBoard)
        {
            // Display column numbers
            Console.Write("   ");
            for (int i = 0; i < gameBoard.GetLength(1); i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // Display game board
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                Console.Write(i + "  ");
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    Console.Write(gameBoard[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Gets the row number for the player's move
        static int GetRow()
        {
            // Prompt user for row number
            Console.Write("Enter row number: ");

            // Validate input
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int row) && row >= 0 && row < 10)
                {
                    return row;
                }
                else
                {
                    Console.Write("Invalid input. Enter a valid row number (0-9): ");
                }
            }
        }

        // Gets the column number for the player's move
        static int GetCol()
        {
            // Prompt user for column number
            Console.Write("Enter column number: ");

            // Validate input
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int col) && col >= 0 && col < 10)
                {
                    return col;
                }
                else
                {
                    Console.Write("Invalid input. Enter a valid column number (0-9): ");
                }
            }
        }

        // Updates the game board with the player's move
        static void UpdateGameBoard(char[,] gameBoard, int row, int col)
        {
            // Update game board with player's move
            gameBoard[row, col] = 'X';
        }

        // Checks if the game is over and returns true if it is, false otherwise
        static bool CheckGameStatus(char[,] gameBoard)
        {
            // Check if player has won
            if (CheckWin(gameBoard, 'X'))
            {
                Console.WriteLine("Congratulations, you have won the game!");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                return true;
            }

            // Check if game is a draw
            if (CheckDraw(gameBoard))
            {
                Console.WriteLine("The game is a draw.");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                return true;
            }

            // Game is not over
            return false;
        }

        // Returns true if the player with the specified piece has won, false otherwise
        static bool CheckWin(char[,] gameBoard, char piece)
        {
            // Check for horizontal win
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1) - 2; j++)
                {
                    if (gameBoard[i, j] == piece && gameBoard[i, j + 1] == piece && gameBoard[i, j + 2] == piece)
                    {
                        return true;
                    }
                }
            }

            // Check for vertical win
            for (int i = 0; i < gameBoard.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i, j] == piece && gameBoard[i + 1, j] == piece && gameBoard[i + 2, j] == piece)
                    {
                        return true;
                    }
                }
            }

            // Check for diagonal win (top left to bottom right)
            for (int i = 0; i < gameBoard.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1) - 2; j++)
                {
                    if (gameBoard[i, j] == piece && gameBoard[i + 1, j + 1] == piece && gameBoard[i + 2, j + 2] == piece)
                    {
                        return true;
                    }
                }
            }

            // Check for diagonal win (top right to bottom left)
            for (int i = 0; i < gameBoard.GetLength(0) - 2; i++)
            {
                for (int j = 2; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i, j] == piece && gameBoard[i + 1, j - 1] == piece && gameBoard[i + 2, j - 2] == piece)
                    {
                        return true;
                    }
                }
            }

            // No win
            return false;
        }


        // Returns true if the game is a draw, false otherwise
        static bool CheckDraw(char[,] gameBoard)
        {
            // Check if all spaces on the game board are filled
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }

            // Game is a draw
            return true;
        }
    }
}
