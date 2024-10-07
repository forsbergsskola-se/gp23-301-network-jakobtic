namespace TicTacToe.GameLogic;

public class TicTacToeGame
{
    public char [,] Board { get; set; }
    public char CurrentPlayer { get; set; }
    public bool isGameOver { get; set; }
    public string winner { get; set; }

    public TicTacToeGame()
    {
        Board = new char[3, 3]; //creates the game
        InitializeBoard();
        CurrentPlayer = 'X'; // X-player always starts first
        isGameOver = false;
    }

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
}