
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
        //converts the 2d array into a string format.
        return Ok(GetFormattedBoard());
    }
    
    //make a move at the given board position
    [HttpPost("Move/{row}/{col}")]
    public ActionResult MakeMove(int row, int col)
    {
        // Attempt to make the move
        if (game.MakeMove(row, col))
        {
            //return updated board, winner status and if the game is over.
            return Ok(new
            {
                Board = GetFormattedBoard(),
                Winner = game.Winner,
                IsGameOver = game.IsGameOver
            });
        }

        // 
        return BadRequest("Invalid move cheater!");
    }
    
    //reset the game
    [HttpPost("Reset")]
    public ActionResult ResetGame()
    {
        game.ResetGame(); //creates a new game
        return Ok(new { Message = "Game restarted!", Board = GetFormattedBoard() }); //creates a new board with a message saying the game restarted.
    }
    
    // Helper method to format the board as a string
    private string GetFormattedBoard()
    {
        var boardString = new StringBuilder();

        for (int i = 0; i < game.Board.GetLength(0); i++)
        {
            for (int j = 0; j < game.Board.GetLength(1); j++)
            {
                boardString.Append(game.Board[i, j] + " ");
            }
            boardString.AppendLine(); // Move to the next line after each row
        }

        return boardString.ToString();
    }
}