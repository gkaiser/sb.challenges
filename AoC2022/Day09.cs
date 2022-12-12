using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2022
{
  internal class Day09
  {
    private static string[] TestInput = new[]
    {
      "R 4",
      "U 4",
      "L 3",
      "D 1",
      "R 4",
      "D 1",
      "L 5",
      "R 2",
    };

    private static string[] TestInput2 = new[]
    {
      "R 5",
      "U 8",
      "L 8",
      "D 3",
      "R 17",
      "D 10",
      "L 25",
      "U 20",
    };

    internal class Point
    {
      public int X;
      public int Y;

      public Point(int x, int y)
      {
        this.X = x;
        this.Y = y;
      }

      public Point Clone() => new Point(this.X, this.Y);

      public bool IsTouching(Point ptOth)
      {
        if (ptOth == null)
          throw new ArgumentException($"ptOth cannot be null.");

        // to the left or right
        if (ptOth.X == this.X && Math.Abs(ptOth.Y - this.Y) <= 1)
          return true;

        // above or below
        if (ptOth.Y == this.Y && Math.Abs(ptOth.X - this.X) <= 1)
          return true;

        // diagonal
        if (Math.Abs(ptOth.X - this.X) <= 1 && Math.Abs(ptOth.Y - this.Y) <= 1)
          return true;

        return false;
      }

      public override string ToString() => $"{{{this.X}, {this.Y}}}";

      public override bool Equals(object? obj)
      {
        if (obj == null) return false;
        if (obj is Point pt) return this.X == pt.X && this.Y == pt.Y;

        return false;
      }

      public static bool operator ==(Point p1, Point p2) => p1.Equals(p2);

      public static bool operator !=(Point p1, Point p2) => !p1.Equals(p2);

      public override int GetHashCode()
      {
        var hc = 1_430_287;
        hc *= 7_302_013 ^ this.X.GetHashCode();
        hc *= 7_302_013 ^ this.Y.GetHashCode();

        return hc;
      }

    }

    internal static void SolvePart1()
    {
      //var inp = Day09.TestInput;
      var inp = System.IO.File.ReadAllLines("Day09.txt");

      var ps = new Point(0, 0);
      var ph = new Point(0, 0);
      var pt = new Point(0, 0);
      var hs = new HashSet<string>();
      hs.Add($"{pt}");
      
      foreach (var inst in inp)
      {
        var dir = inst.Split(' ')[0];
        var len = int.Parse(inst.Split(' ')[1]);

        for (int i = len; i > 0; i--)
        {
          switch (dir)
          {
            case "U":
              ph.Y++;
              break;
            case "D":
              ph.Y--;
              break;
            case "R":
              ph.X++;
              break;
            case "L":
              ph.X--;
              break;
          }

          if (ph.IsTouching(pt))
            continue;

          if (ph.X == pt.X)
          {
            switch (dir)
            {
              case "U":
                pt.Y++;
                break;
              case "D":
                pt.Y--;
                break;
            }
          }
          else if (ph.Y == pt.Y)
          {
            switch (dir)
            {
              case "R":
                pt.X++;
                break;
              case "L":
                pt.X--;
                break;
            }
          }
          else
          {
            switch (dir)
            {
              case "U":
                pt.Y++;
                pt.X += (ph.X > pt.X ? 1 : -1);
                break;
              case "D":
                pt.Y--;
                pt.X += (ph.X > pt.X ? 1 : -1);
                break;
              case "R":
                pt.X++;
                pt.Y += (ph.Y > pt.Y ? 1 : -1);
                break;
              case "L":
                pt.X--;
                pt.Y += (ph.Y > pt.Y ? 1 : -1);
                break;
            }
          }

          if (!hs.Contains($"{pt}"))
            hs.Add($"{pt}");
        }
      }

      // 6284 (sloooooooooooow w/ List<string>, faster with HashSet<string>)
      Console.WriteLine($"The tail visited {hs.Count} unique points...");
    }

    internal static void SolvePart2()
    {
      //var inp = Day09.TestInput2;
      var inp = System.IO.File.ReadAllLines("Day09.txt");

      var ptarr = new[]
      {
        new Point(0, 0),
        new Point(0, 0),
        new Point(0, 0),
        new Point(0, 0),
        new Point(0, 0),
        new Point(0, 0),
        new Point(0, 0),
        new Point(0, 0),
        new Point(0, 0),
        new Point(0, 0),
      };

      var hs = new HashSet<string>();
      hs.Add($"{new Point(0, 0)}");

      foreach (var inst in inp)
      {
        var dir = inst.Split(' ')[0];
        var len = int.Parse(inst.Split(' ')[1]);

        for (int i = len; i > 0; i--)
        {
          for (int q = 0; q < ptarr.Length - 1; q++)
          {
            var ph = ptarr[q];
            var pt = ptarr[q + 1];

            if (q == 0)
            {
              switch (dir)
              {
                case "U":
                  ph.Y++;
                  break;
                case "D":
                  ph.Y--;
                  break;
                case "R":
                  ph.X++;
                  break;
                case "L":
                  ph.X--;
                  break;
              }
            }

            if (ph.IsTouching(pt))
              continue;

            while (!ph.IsTouching(pt))
            {
              if (ph.X == pt.X)
              {
                if (ph.Y > pt.Y)
                  pt.Y++;
                else
                  pt.Y--;
              }
              else if (ph.Y == pt.Y)
              {
                if (ph.X > pt.X)
                  pt.X++;
                else
                  pt.X--;
              }
              else
              {
                if (ph.Y > pt.Y)
                { 
                  pt.Y++;
                  pt.X += (ph.X > pt.X ? 1 : -1);
                } 
                else if (ph.Y < pt.Y)
                {
                  pt.Y--;
                  pt.X += (ph.X > pt.X ? 1 : -1);
                }
                else if (ph.X > pt.X)
                {
                  pt.X++;
                  pt.Y += (ph.Y > pt.Y ? 1 : -1);
                }
                else if (ph.X < pt.X)
                {
                  pt.X++;
                  pt.Y += (ph.Y > pt.Y ? 1 : -1);
                }
              }
            }
          }

          if (!hs.Contains($"{ptarr.Last()}"))
            hs.Add($"{ptarr.Last()}");
        }
      }

      // 820 low
      // 839 low
      // 2661
      Console.WriteLine($"The tail visited {hs.Count} unique points...");
    }

    private static void Print(Point[] ptarr)
    {
      for (int i = 27; i >= -15; i--)
      {
        for (int j = -15; j < 28; j++)
        {
          var ch = "-";

          for (int k = 0; k < ptarr.Length; k++)
          { 
            if (k < ptarr.Length && ptarr[k].X == j && ptarr[k].Y == i)
            {
              if (k == 0)
                ch = "H";
              else
                ch = $"{k}";
              break;
            }
          }

          Console.Write($"{ch} ");
        }

        Console.WriteLine();
      }
    }

  }
}