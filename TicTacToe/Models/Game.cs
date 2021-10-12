using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
  public class Game
  {
    public List<Square> Squares { get; }
    public int RemainingPlays { get; set; }
    public Mark NextTurn { get; set; }
    public Mark? Winner { get; set; }
    int[][] WinningCombinations = new int[][]
    {
     new int[] { 1, 2, 3 },
     new int[] { 4, 5, 6 },
     new int[] { 7, 8, 9 },
     new int[] { 1, 4, 7 },
     new int[] { 2, 5, 8 },
     new int[] { 3, 6, 9 },
     new int[] { 1, 5, 9 },
     new int[] { 7, 5, 3 },
    };
    public Game()
    {
      Squares = new();
      ResetBoard();
    }

    public void ResetBoard()
    {
      NextTurn = Mark.O;
      RemainingPlays = 9;
      for (int i = 0; i < 9; i++)
      {
        Squares.Add(new Square());
      }
    }

    public void Next()
    {
      Winner = null;
      CheckWinner();
      if (Winner.HasValue)
      {
        ResetBoard();
        NextTurn = Winner.Value;
      }
      else
      {
        NextTurn = NextTurn == Mark.O ? Mark.X : Mark.O;
        RemainingPlays--;
      }

    }

    public void CheckWinner()
    {
      for (int i = 0; i < WinningCombinations.Length; i++)
      {
        var element1 = WinningCombinations[i][0] - 1;
        var element2 = WinningCombinations[i][1] - 1;
        var element3 = WinningCombinations[i][2] - 1;
        if (Squares[element1].Mark == Mark.O && Squares[element2].Mark == Mark.O && Squares[element3].Mark == Mark.O)
        {
          Winner = Mark.O;
          return;
        }
        else if(Squares[element1].Mark == Mark.X && Squares[element2].Mark == Mark.X && Squares[element3].Mark == Mark.X)
        {
          Winner = Mark.X;
          return;
        }
      }
    }
  }
}
