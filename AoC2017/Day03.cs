using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2017
{
  internal static class Day03
  {
    internal static void Solve_Part1_Att1()
    {
      var x = 0;
      var y = 0;
      var posn = 277678; // 1=0, 12=3, 23=2, 1024=31
      var direct = "r";

      var grid = new List<Point> { new Point(x, y) };

      for (int i = 1; i <= posn; i++)
      {
        if (i == posn)
          break;
        if (i % 1000 == 0)
        {
          var pct = Math.Round((decimal)((decimal)i / (decimal)posn) * 100m, 1);

          Console.CursorLeft = 0;
          Console.Write(pct + "% done...");
        }

        if (direct == "r")
        {
          x++;

          if (grid.FirstOrDefault(pv => pv.X == x && pv.Y == y + 1) == null)
            direct = "u";
        }
        else if (direct == "u")
        {
          y++;

          if (grid.FirstOrDefault(pv => pv.X == x - 1 && pv.Y == y) == null)
            direct = "l";
        }
        else if (direct == "l")
        {
          x--;

          if (grid.FirstOrDefault(pv => pv.X == x && pv.Y == y - 1) == null)
            direct = "d";
        }
        else if (direct == "d")
        {
          y--;
          
          if (grid.FirstOrDefault(pv => pv.X == x + 1 && pv.Y == y) == null)
            direct = "r";
        }

        grid.Add(new Point(x, y));
      }

      Console.WriteLine($"Looks like it takes {Math.Abs(x) + Math.Abs(y)} steps from position {posn}...");
    }

    internal static void Solve_Part1_Att2()
    {
      var posn = 277678; // 1=0, 12=3, 23=2, 1024=31, 277678=475
      var ringMax = 1;
      var ringCt = 0;

      while (ringMax < posn)
      {
        ringCt++;
        ringMax += 8 * ringCt;
      }

      var ptCurr = new Point(ringCt, ringCt * -1);
      var ptCount = ringCt * 2;
      var rollingCt = ptCount;
      var direct = "l";

      while (true)
      {
        if (ringMax == posn)
          break;
        if (rollingCt == 0)
        {
          if (direct == "l")
            direct = "u";
          else if (direct == "u")
            direct = "r";
          else if (direct == "r")
            direct = "d";

          rollingCt = ringCt * 2;
        }

        if (direct == "l")
          ptCurr.X--;
        else if (direct == "u")
          ptCurr.Y++;
        else if (direct == "r")
          ptCurr.X++;
        else
          ptCurr.Y--;

        rollingCt--;
        ringMax--;
      }

      Console.WriteLine($"Looks like it takes {Math.Abs(ptCurr.X) + Math.Abs(ptCurr.Y)} steps from position {posn} at ({ptCurr.X}, {ptCurr.Y})...");
    }

    internal static void Solve_Part2()
    {
      var x = 0;
      var y = 0;
      var posn = 277678; // 279138
      var direct = "r";

      var grid = new List<Point> { new Point(x, y, 1) };

      for (int i = 1; i <= posn; i++)
      {
        if (direct == "r")
        {
          x++;

          if (grid.FirstOrDefault(pv => pv.X == x && pv.Y == y + 1) == null)
            direct = "u";
        }
        else if (direct == "u")
        {
          y++;

          if (grid.FirstOrDefault(pv => pv.X == x - 1 && pv.Y == y) == null)
            direct = "l";
        }
        else if (direct == "l")
        {
          x--;

          if (grid.FirstOrDefault(pv => pv.X == x && pv.Y == y - 1) == null)
            direct = "d";
        }
        else if (direct == "d")
        {
          y--;

          if (grid.FirstOrDefault(pv => pv.X == x + 1 && pv.Y == y) == null)
            direct = "r";
        }

        var adjSum = 0;
        if (grid.FirstOrDefault(pv => pv.X == x - 1 && pv.Y == y + 1) != null)
          adjSum += grid.FirstOrDefault(pv => pv.X == x - 1 && pv.Y == y + 1).Value;
        if (grid.FirstOrDefault(pv => pv.X == x && pv.Y == y + 1) != null)
          adjSum += grid.FirstOrDefault(pv => pv.X == x && pv.Y == y + 1).Value;
        if (grid.FirstOrDefault(pv => pv.X == x + 1 && pv.Y == y + 1) != null)
          adjSum += grid.FirstOrDefault(pv => pv.X == x + 1 && pv.Y == y + 1).Value;
        if (grid.FirstOrDefault(pv => pv.X == x - 1 && pv.Y == y) != null)
          adjSum += grid.FirstOrDefault(pv => pv.X == x - 1 && pv.Y == y).Value;
        if (grid.FirstOrDefault(pv => pv.X == x + 1 && pv.Y == y) != null)
          adjSum += grid.FirstOrDefault(pv => pv.X == x + 1 && pv.Y == y).Value;
        if (grid.FirstOrDefault(pv => pv.X == x - 1 && pv.Y == y - 1) != null)
          adjSum += grid.FirstOrDefault(pv => pv.X == x - 1 && pv.Y == y - 1).Value;
        if (grid.FirstOrDefault(pv => pv.X == x && pv.Y == y - 1) != null)
          adjSum += grid.FirstOrDefault(pv => pv.X == x && pv.Y == y - 1).Value;
        if (grid.FirstOrDefault(pv => pv.X == x + 1 && pv.Y == y - 1) != null)
          adjSum += grid.FirstOrDefault(pv => pv.X == x + 1 && pv.Y == y - 1).Value;

        grid.Add(new Point(x, y, adjSum));

        if (adjSum > posn)
          break;
      }

      Console.WriteLine($"Looks like {grid.Last().Value} is the first value that is larger than {posn}...");
    }

    private class Point
    {
      public int X;
      public int Y;
      public int Value;

      public Point(int x, int y) : this(x, y, 0) { }

      public Point(int x, int y, int value)
      {
        this.X = x;
        this.Y = y;
        this.Value = value;
      }
    }

  }
}
