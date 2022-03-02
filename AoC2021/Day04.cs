using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2021
{
  internal static class Day04
  {
    internal class BingoBoard
    {
      public string[][] Board;

      public BingoBoard(string[] init, bool print = false)
      {
        this.Board = new string[5][];

        for (int i = 0; i < 5; i++)
        {
          this.Board[i] = new string[5];

          for (int j = 0; j < 5; j++)
          {
            this.Board[i][j] = init[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)[j];
          }
        }

        if (print)
          this.Print();
      }

      public bool ThatsABingo
      {
        get
        {
          for (int i = 0; i < this.Board.Length; i++)
          {
            if (this.Board[i].ToArray().All(rv => rv == "X"))
              return true;
          }
          for (int i = 0; i < this.Board.Length; i++)
          {
            var col = new string[this.Board.Length];
            for (int j = 0; j < 5; j++)
            {
              col[j] = this.Board[j][i];
            }
            if (col.All(cv => cv == "X"))
              return true;
          }
          
          return false;
        }
      }

      public int Score
      {
        get
        {
          var sc = 0;

          for (int i = 0; i < this.Board.Length; i++)
          {
            sc += this.Board[i].Select(rv => rv == "X" ? 0 : int.Parse(rv)).Sum();
          }

          return sc;
        }
      }

      public void Print()
      {
        for (int i = 0; i < 5; i++)
          Console.WriteLine(string.Join(" ", this.Board[i]));
        
        Console.WriteLine();
      }
      
    }

    internal static void SolvePart1()
    {
      //var lines = new[]
      //{
      //  "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
      //  "",
      //  "22 13 17 11  0",
      //  " 8  2 23  4 24",
      //  "21  9 14 16  7",
      //  " 6 10  3 18  5",
      //  " 1 12 20 15 19",
      //  "",
      //  " 3 15  0  2 22",
      //  " 9 18 13 17  5",
      //  "19  8  7 25 23",
      //  "20 11 10 24  4",
      //  "14 21 16 12  6",
      //  "",
      //  "14 21 17 24  4",
      //  "10 16 15  9 19",
      //  "18  8 23 26 20",
      //  "22 11 13  6  5",
      //  " 2  0 12  3  7",
      //};
      var lines = System.IO.File.ReadAllLines(@"Day04.txt");
      var draws = new List<string>();
      var boards = new List<BingoBoard>();

      for (int i = 0; i < lines.Length; i++)
      {
        if (i == 0)
        { 
          draws = new List<string>(lines[i].Split(','));
          continue;
        }

        if (string.IsNullOrWhiteSpace(lines[i]))
        {
          i++;

          var bl = new string[5];
          for (int j = 0; j < 5; j++)
          {
            bl[j] = lines[i + j];
          }

          var b = new BingoBoard(bl);
          boards.Add(b);
        }
      }

      foreach (var d in draws)
      {
        for (int q = 0; q < boards.Count; q++)
        {
          var b = boards[q];
          for (int i = 0; i < b.Board.Length; i++)
          {
            for (int j = 0; j < b.Board[i].Length; j++)
            {
              if (b.Board[i][j] == d)
                b.Board[i][j] = "X";
            }
          }

          if (b.ThatsABingo)
          {
            b.Print();
            Console.WriteLine($"FINISHED! BOARD # {q + 1} WINS! FINAL SCORE: {b.Score * int.Parse(d)} ({b.Score} x {int.Parse(d)})");
            goto LAZYLABEL;
          }
        }
      }

      LAZYLABEL:
      return;
    }

    internal static void SolvePart2()
    {
      //var lines = new[]
      //{
      //  "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
      //  "",
      //  "22 13 17 11  0",
      //  " 8  2 23  4 24",
      //  "21  9 14 16  7",
      //  " 6 10  3 18  5",
      //  " 1 12 20 15 19",
      //  "",
      //  " 3 15  0  2 22",
      //  " 9 18 13 17  5",
      //  "19  8  7 25 23",
      //  "20 11 10 24  4",
      //  "14 21 16 12  6",
      //  "",
      //  "14 21 17 24  4",
      //  "10 16 15  9 19",
      //  "18  8 23 26 20",
      //  "22 11 13  6  5",
      //  " 2  0 12  3  7",
      //};
      var lines = System.IO.File.ReadAllLines(@"Day04.txt");
      var draws = new List<string>();
      var boards = new List<BingoBoard>();

      var sw = System.Diagnostics.Stopwatch.StartNew();
      for (int i = 0; i < lines.Length; i++)
      {
        if (i == 0)
        {
          draws = new List<string>(lines[i].Split(','));
          continue;
        }

        if (string.IsNullOrWhiteSpace(lines[i]))
        {
          i++;

          var bl = new string[5];
          for (int j = 0; j < 5; j++)
          {
            bl[j] = lines[i + j];
          }

          var b = new BingoBoard(bl);
          boards.Add(b);
        }
      }
      Console.WriteLine($"Took {sw.Elapsed.GetFriendlyDuration()} to create boards...");

      sw = System.Diagnostics.Stopwatch.StartNew();
      var winners = new List<int>();
      var scores = new List<int>();
      foreach (var d in draws)
      {
        for (int q = 0; q < boards.Count; q++)
        {
          var b = boards[q];
          for (int i = 0; i < b.Board.Length; i++)
          {
            for (int j = 0; j < b.Board[i].Length; j++)
            {
              if (b.Board[i][j] == d)
                b.Board[i][j] = "X";
            }
          }

          if (b.ThatsABingo)
          {
            scores.Add(b.Score * int.Parse(d));

            if (!winners.Contains(q))
            {
              winners.Add(q);

              if (winners.Count == boards.Count)
                goto LAZYLEAVE;
            }
          }
        }
      }

      LAZYLEAVE:
      Console.WriteLine($"Took {sw.Elapsed.GetFriendlyDuration()} to solve worst board...");
      Console.WriteLine($"Last board to win scores {scores.Last()}...");
    }

  }
}
