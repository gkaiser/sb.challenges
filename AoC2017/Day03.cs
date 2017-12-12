using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
      var posn = 12; // 1=0, 12=3, 23=2, 1024=31, 277678=475
      var ringMax = 1;
      var ringCt = 0;

      while (ringMax < posn)
      {
        ringMax += 8 * ringCt;
        ringCt++;
      }

      var ptCurr = new Point(ringCt, ringCt);

      return;
    }

    private class Point
    {
      public int X;
      public int Y;

      public Point(int x, int y)
      {
        this.X = x;
        this.Y = y;
      }
    }
  }
}
