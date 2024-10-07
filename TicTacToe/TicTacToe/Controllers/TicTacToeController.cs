
using System.Text;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.GameLogic;

namespace TicTacToe.Controllers;
[ApiController]
[Route("api/[controller]")]

public class TicTacToeController: ControllerBase
{
    //Creating a static instance of the game
    private static TicTacToeGame game = new TicTacToeGame();

    //get the current state of the game board 
    [HttpGet("board")]
    public IActionResult GetBoard()
    {
        var boardString = new StringBuilder();
        for (int i = 0; i < game.Board.GetLength(0); i++)
        {
            for (int j = 0; j < game.Board.GetLength(1); j++)
            {
                boardString.Append(game.Board[i, j] + " ");
            }
            boardString.AppendLine();
        }
        
        //returns the board as a string
        return Ok(boardString.ToString());
    }
    
}