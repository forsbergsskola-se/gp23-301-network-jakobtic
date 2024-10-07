namespace TicTacToe.GameLogic;

public class TicTacToeGame
{
    public char [,] Board { get; set; }
    public char [,] CurrentPlayer { get; set; }
    public bool isGameOver { get; set; }
    public string winner { get; set; }

    public TicTacToeGame()
    {
        
    }
}