using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2017
{
  internal static class Day11
  {
    internal static void Solve_Part1()
    {
      //var input = "ne,ne,ne".Split(',');
      //var input = "ne,ne,sw,sw".Split(',');
      //var input = "ne,ne,s,s".Split(','); //xx
      //var input = "se,sw,se,sw,sw".Split(','); //xx
      var input = System.IO.File.ReadAllText("Day11_Part1.txt").Split(','); // 715
      var currPosn = new Point(0m, 0m);

      foreach (var move in input)
      {
        if (move == "n")
        {
          currPosn.Y++;
        }
        else if (move == "ne")
        {
          currPosn.Y += 0.5m;
          currPosn.X++;
        }
        else if (move == "se")
        {
          currPosn.Y -= 0.5m;
          currPosn.X++;
        }
        else if (move == "s")
        {
          currPosn.Y--;
        }
        else if (move == "sw")
        {
          currPosn.Y -= 0.5m;
          currPosn.X--;
        }
        else if (move == "nw")
        {
          currPosn.Y += 0.5m;
          currPosn.X--;
        }
        else
          throw new Exception("Oh shit!");
      }

      var moves = currPosn.GetStepsToGetHome();

      Console.WriteLine($"Looks like we can make it back in {moves.Count} moves ({string.Join(",", moves)})...");
    }

    internal static void Solve_Part2()
    {
      //var input = "ne,ne,ne".Split(',');
      //var input = "ne,ne,sw,sw".Split(',');
      //var input = "ne,ne,s,s".Split(','); //xx
      //var input = "se,sw,se,sw,sw".Split(','); //xx
      var input = System.IO.File.ReadAllText("Day11_Part1.txt").Split(','); // 1512
      var currPosn = new Point(0m, 0m);
      var maxDist = 0;

      foreach (var move in input)
      {
        if (move == "n")
        {
          currPosn.Y++;
        }
        else if (move == "ne")
        {
          currPosn.Y += 0.5m;
          currPosn.X++;
        }
        else if (move == "se")
        {
          currPosn.Y -= 0.5m;
          currPosn.X++;
        }
        else if (move == "s")
        {
          currPosn.Y--;
        }
        else if (move == "sw")
        {
          currPosn.Y -= 0.5m;
          currPosn.X--;
        }
        else if (move == "nw")
        {
          currPosn.Y += 0.5m;
          currPosn.X--;
        }
        else
          throw new Exception("Oh shit!");

        var steps = currPosn.GetStepsToGetHome().Count;
        if (steps > maxDist)
          maxDist = steps;
      }

      //var moves = currPosn.GetStepsToGetHome();

      Console.WriteLine($"Looks like the max dist was {maxDist} moves away..."); 
    }


    private class Point
    {
      public decimal X;
      public decimal Y;

      public Point(decimal x, decimal y)
      {
        this.X = x;
        this.Y = y;
      }

      public List<string> GetStepsToGetHome()
      {
        var moves = new List<string>();
        var tmpPt = new Point(this.X, this.Y);

        while (tmpPt.X != 0 || tmpPt.Y != 0)
        {
          // if we're on a y == x.5 then go 1 move away from y=0 first

          if (tmpPt.Y == 0 && tmpPt.X != 0)
          {
            if (tmpPt.X > 0)
            {
              tmpPt.Y += 0.5m;
              tmpPt.X--;
              moves.Add("nw");
            }
            else
            {
              tmpPt.Y += 0.5m;
              tmpPt.X++;
              moves.Add("ne");
            }
          }
          else if (tmpPt.X > 0 && tmpPt.Y > 0)
          {
            tmpPt.Y -= 0.5m;
            tmpPt.X--;
            moves.Add("sw");
          }
          else if (tmpPt.X < 0 && tmpPt.Y > 0)
          {
            tmpPt.Y -= 0.5m;
            tmpPt.X++;
            moves.Add("se");
          }
          else if (tmpPt.X < 0 && tmpPt.Y < 0)
          {
            tmpPt.Y += 0.5m;
            tmpPt.X++;
            moves.Add("ne");
          }
          else if (tmpPt.X > 0 && tmpPt.Y < 0)
          {
            tmpPt.Y += 0.5m;
            tmpPt.X--;
            moves.Add("nw");
          }
          else if (tmpPt.X == 0 && tmpPt.Y > 0)
          {
            tmpPt.Y--;
            moves.Add("s");
          }
          else if (tmpPt.X == 0 && tmpPt.Y < 1)
          {
            tmpPt.Y++;
            moves.Add("n");
          }
        }

        return moves;
      }

    }

  }

}
