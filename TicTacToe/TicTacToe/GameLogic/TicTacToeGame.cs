namespace TicTacToe.GameLogic;

public class TicTacToeGame
{
    public char [,] Board { get; set; }
    public char CurrentPlayer { get; set; }
    public bool IsGameOver { get; set; }
    public string Winner { get; set; }

    public TicTacToeGame()
    {
        Board = new char[3, 3]; //creates the game
        InitializeBoard(); // calls on the initialize method
        CurrentPlayer = 'X'; // X-player always starts first
        IsGameOver = false; //check if the game is won
    }

    //a Method to initialize the board with '-' to represent empty positions in the game
    private void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Board[i, j] = '-'; //set each positions to '-'
            }
        }
    }

    public bool MakeMove(int row, int col)
    {
        // If the move is invalid, return false. also makes that the player cannot move outside the grid etc.
        if (row < 0 || row > 2 || col < 0 || col > 2 || Board[row, col] != '-' || IsGameOver)
        {
            return false;
        }
        
        //set the current players mark on the board
        Board[row, col] = CurrentPlayer;
        
        //checks if the current move results in a win or not.
        if (CheckForWin())
        {
            IsGameOver = true;
            Winner = CurrentPlayer.ToString(); //sets the winner
        }
        
        //if the board is filled and there is no winner, its a draw
        else if (IsBoardFull())
        {
            IsGameOver = true;
            Winner = "DRAW";
        }

        else
        {
            //if no one wins, switch the current player
            CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';
        }

        return true;
    }

    //Creating a method to check for a win
    private bool CheckForWin()
    {
        // Check rows, columns, and diagonals for a win
        for (int i = 0; i < 3; i++)
        {
            // Check each row for a win
            if (Board[i, 0] == CurrentPlayer && Board[i, 1] == CurrentPlayer && Board[i, 2] == CurrentPlayer)
                return true;
            // Check each column for a win
            if (Board[0, i] == CurrentPlayer && Board[1, i] == CurrentPlayer && Board[2, i] == CurrentPlayer)
                return true;
        }

        // Check diagonal (top left to bottom right)
        if (Board[0, 0] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 2] == CurrentPlayer)
            return true;

        // Check diagonal (top right to bottom left)
        if (Board[0, 2] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 0] == CurrentPlayer)
            return true;

        return false; // No win
    }

    //checking method to see if the game board is full and draws the game
    private bool IsBoardFull()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (Board[row,col] == '-')
                {
                    return false; //found a empty spot
                }
            }
        }

        return true; //no more spots left.
    }

    public void ResetGame()
    {
        InitializeBoard(); // Reinitialize the board
        CurrentPlayer = 'X'; //resets to starting player
        IsGameOver = false; 
        Winner = null; // no winner
    }
    
}