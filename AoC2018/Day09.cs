using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2018
{
  internal static class Day09
  {
    internal static void Solve(bool part1)
    {
      var input = "411 players; last marble is worth 72059 points";
      //var input = "9 players; last marble is worth 25 points";
      //var input = "10 players; last marble is worth 1618 points";
      //var input = "13 players; last marble is worth 7999 points";

      var tokens = input.Split(' ');
      var players = new long[long.Parse(tokens[0])];
      var marbles = Enumerable.Range(0, (int.Parse(tokens[tokens.Length - 2]) + 1) * (part1 ? 1 : 100)).ToList();
      var board = new List<long>();
      var currMarbIdx = 0;

      for (int i = 0; ; i++)
      {
        var next = marbles[0];

        if (i != 0 && next % 23 == 0)
        {
          var extraMarbIdx = (currMarbIdx - 7 < 0 ? board.Count - Math.Abs(currMarbIdx - 7) : currMarbIdx - 7);
          currMarbIdx = (extraMarbIdx + 1 == board.Count ? 0 : extraMarbIdx + 1);

          var playerId = (i - 1) % players.Length;

          players[playerId] += next;
          players[playerId] += board[extraMarbIdx];

          marbles.Remove(next);
          board.RemoveAt(extraMarbIdx);

          currMarbIdx = extraMarbIdx;
        }
        else
        {
          if (i == 0)
          {
            board.Add(marbles.Min());
            marbles.Remove(marbles.Min());
          }
          else if (i < 2)
          {
            board.Add(next);
            currMarbIdx = board.Count - 1;
          }
          else if (currMarbIdx + 1 == board.Count)
          {
            board.Insert(1, next);
            currMarbIdx = 1;
          }
          else if (currMarbIdx + 1 > board.Count)
          {
            currMarbIdx = board.Count - currMarbIdx;
            board.Insert(currMarbIdx, next);
          }
          else
          {
            currMarbIdx = currMarbIdx + 2;
            board.Insert(currMarbIdx, next);
          }

          marbles.Remove(next);
        }

        if (marbles.Count() == 0)
          break;
      }

      for (int i = 0; i < players.Length; i++)
        Console.WriteLine($"{i + 1} ==> {players[i]}");

      Console.WriteLine($"The winner's high score is {players.Max()}...");
    }

    private static void PrintBoard(int[] board, int maxMarb, string playerId, int currIdx)
    {
      var fmtMarb = new string('0', maxMarb);

      Console.Write($"[{playerId}] ");

      for (int i = 0; i < board.Length; i++)
      {
        var v = board[i];
        var occ = Console.ForegroundColor;

        if (currIdx == i)
          Console.ForegroundColor = ConsoleColor.Cyan;

        Console.Write($"{v.ToString(fmtMarb)} ");

        Console.ForegroundColor = occ;
      }

      Console.WriteLine();
    }

  }
}