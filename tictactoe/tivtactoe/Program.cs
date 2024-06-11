using System;

class Program
{
    static char[,] board = new char[3, 3];
    static char playerOneMarker, playerTwoMarker, currentPlayer;
    static bool isPlayerOneTurn;
    static int playerOneScore = 0, playerTwoScore = 0;

    static void Main()
    {
        bool gameisrunning = true;

        while (gameisrunning)
        {

            InitializeBoard();
            bool gameinprogress = true;

            SetPlayerMarkers();

            while (gameinprogress)
            {
                Console.Clear();
                DisplayScore();
                DisplayBoard();
                PlayerMove();

                if (CheckWin())
                {
                    gameinprogress = false;
                    Console.Clear();
                    DisplayScore();
                    DisplayBoard();
                    if (isPlayerOneTurn)
                    {
                        Console.WriteLine($"Player One ({currentPlayer}) wins!");
                    }
                    else
                    {
                        Console.WriteLine($"Player Two ({currentPlayer}) wins!");
                    }
                    if (isPlayerOneTurn)
                    {
                        playerOneScore++;
                    }
                    else
                    {
                        playerTwoScore++;
                    }
                }
                else if (CheckDraw())
                {
                    gameinprogress = false;
                    Console.Clear();
                    DisplayScore();
                    DisplayBoard();
                    Console.WriteLine("It is a draw!");
                }
                else
                {
                    SwitchPlayer();
                }
            }

            gameisrunning = NewGame();
        }
    }
    // sarqume azat e taxtaky 
    static void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' ';
            }
        }
    }

    // xaghacoxynery yntrnum en X te O
    static void SetPlayerMarkers()
    {
        Console.WriteLine("Player One, choose your marker (X or O): ");
        while (true)
        {
            playerOneMarker = char.ToUpper(Console.ReadLine()[0]);
            if (playerOneMarker == 'X' || playerOneMarker == 'O')
            {
                if (playerOneMarker == 'X')
                {
                    playerTwoMarker = 'O';
                }
                else
                {
                    playerTwoMarker = 'X';
                }

                isPlayerOneTurn = playerOneMarker == 'X';
                if (isPlayerOneTurn)
                {
                    currentPlayer = playerOneMarker;
                }
                else
                {
                    currentPlayer = playerTwoMarker;
                }

                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please choose X or O.");
            }
        }
        Console.WriteLine($"Player One is {playerOneMarker} and Player Two is {playerTwoMarker}");
    }

    // Hashivy
    static void DisplayScore()
    {
        Console.WriteLine("Scoreboard:");
        Console.WriteLine($"Player One ({playerOneMarker}): {playerOneScore}");
        Console.WriteLine($"Player Two ({playerTwoMarker}): {playerTwoScore}");
        Console.WriteLine();
    }

    static void DisplayBoard()
    {
        Console.WriteLine("  0 1 2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j]);
                if (j < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("  -----");
        }
    }

    // xaghacoxi qaylery ev tarmacnum e taxtaky 
    static void PlayerMove()
    {
        int row = -1, col = -1;
        bool validMove = false;

        while (!validMove)
        {
            if (isPlayerOneTurn)
            {
                Console.WriteLine($"Player One ({currentPlayer}), enter your move (row and column): ");
            }
            else
            {
                Console.WriteLine($"Player Two ({currentPlayer}), enter your move (row and column): ");
            }


            bool validRow = false, validCol = false;

            while (!validRow)
            {
                Console.Write("Row: ");
                if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < 3)
                {
                    validRow = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 2.");
                }
            }

            while (!validCol)
            {
                Console.Write("Column: ");
                if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < 3)
                {
                    validCol = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 2.");
                }
            }

            if (board[row, col] == ' ')
            {
                board[row, col] = currentPlayer;
                validMove = true;
            }
            else
            {
                Console.WriteLine("Invalid move. The cell is already occupied. Try again.");
            }
        }
    }
    // stugum e ardyoq  qayly arac xaghacoghy haghtel e
    static bool CheckWin()
    {
        for (int i = 0; i < 3; i++)
        {
            if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
            {
                return true;
            }
        }

        if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
            (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
        {
            return true;
        }

        return false;
    }
    //voch voqi
    static bool CheckDraw()
    {
        foreach (char cell in board)
        {
            if (cell == ' ')
            {
                return false;
            }
        }
        return true;
    }

    //hajord qayly anoxy
    static void SwitchPlayer()
    {
        isPlayerOneTurn = !isPlayerOneTurn;
        if (isPlayerOneTurn)
        {
            currentPlayer = playerOneMarker;
        }
        else
        {
            currentPlayer = playerTwoMarker;
        }

    }
    // stughum e ardyqoqy xaghacoxnery uzum en ev mek angam xaghal
    static bool NewGame()
    {
        while (true)
        {
            Console.WriteLine("Do you want to start a new game? (y/n): ");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                currentPlayer = playerOneMarker;
                isPlayerOneTurn = playerOneMarker == 'X'; // Ov e sksum xaghy
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
            }
        }
    }
}
