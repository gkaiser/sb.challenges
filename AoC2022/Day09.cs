using System;
using System.Collections.Generic;

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

      public override int GetHashCode() => base.GetHashCode();

    }

    internal static void SolvePart1()
    {
      var inp = Day09.TestInput;
      //var inp = System.IO.File.ReadAllLines("Day09.txt");

      var ps = new Point(0, 0);
      var ph = new Point(0, 0);
      var pt = new Point(0, 0);
      var visited = new HashSet<Point>();
      visited.Add(pt);
      
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

          // move tail
        }
      }

      Console.WriteLine($"The tail visited {visited.Count} unique points...");
    }

    

  }
}