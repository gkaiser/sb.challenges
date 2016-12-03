using System;
using System.Collections.Generic;

namespace AoC2016
{
  internal static class Day01
  {
    internal class Point
    {
      public int X;
      public int Y;
      public string Facing = "N"; // N-E-S-W
      public List<string> Hist = new List<string>();

      public Point() { }

      public Point(int x, int y)
      {
        this.X = x;
        this.Y = y;
      }

      public bool Walk(string turnDir, int len, bool printWhenBeenThere)
      {
        if (this.Facing == "N" && turnDir == "L")
          this.Facing = "W";
        else if (this.Facing == "N" && turnDir == "R")
          this.Facing = "E";

        else if (this.Facing == "E" && turnDir == "L")
          this.Facing = "N";
        else if (this.Facing == "E" && turnDir == "R")
          this.Facing = "S";

        else if (this.Facing == "S" && turnDir == "L")
          this.Facing = "E";
        else if (this.Facing == "S" && turnDir == "R")
          this.Facing = "W";

        else if (this.Facing == "W" && turnDir == "L")
          this.Facing = "S";
        else if (this.Facing == "W" && turnDir == "R")
          this.Facing = "N";

        if (this.Facing == "N")
          for (int i = 1; i <= len; i++)
          {
            this.Y++;
            if (printWhenBeenThere)
            {
              if (!this.Hist.Contains(this.ToString()))
                this.Hist.Add(this.ToString());
              else
              {
                Console.WriteLine($"We've been at {this.ToString()} before; it is {Math.Abs(this.X) + Math.Abs(this.Y)} blocks away.");
                return true;
              }
            }
          }
        else if (this.Facing == "S")
          for (int i = 1; i <= len; i++)
          {
            this.Y--;
            if (printWhenBeenThere)
            {
              if (!this.Hist.Contains(this.ToString()))
                this.Hist.Add(this.ToString());
              else
              {
                Console.WriteLine($"We've been at {this.ToString()} before; it is {Math.Abs(this.X) + Math.Abs(this.Y)} blocks away.");
                return true;
              }
            }
          }
        else if (this.Facing == "E")
          for (int i = 1; i <= len; i++)
          {
            this.X++;
            if (printWhenBeenThere)
            {
              if (!this.Hist.Contains(this.ToString()))
                this.Hist.Add(this.ToString());
              else
              {
                Console.WriteLine($"We've been at {this.ToString()} before; it is {Math.Abs(this.X) + Math.Abs(this.Y)} blocks away.");
                return true;
              }
            }
          }
        else if (this.Facing == "W")
          for (int i = 1; i <= len; i++)
          {
            this.X--;
            if (printWhenBeenThere)
            {
              if (!this.Hist.Contains(this.ToString()))
                this.Hist.Add(this.ToString());
              else
              {
                Console.WriteLine($"We've been at {this.ToString()} before; it is {Math.Abs(this.X) + Math.Abs(this.Y)} blocks away.");
                return true;
              }
            }
          }

        return false;
      }

      public override string ToString()
      {
        return $"{this.X}, {this.Y}";
      }
    }

    internal static void Solve_Part1()
    {
      Console.WriteLine("Solving Day 01, Part 1...");

      var directions = System.IO.File.ReadAllText("01.txt").Split(',');
      var pt = new Point();

      foreach (var direction in directions)
      {
        if (string.IsNullOrWhiteSpace(direction))
          continue;

        pt.Walk(
          direction.Trim().Substring(0, 1), 
          int.Parse(direction.Trim().Substring(1)), 
          false);
      }

      Console.WriteLine($"You are at {pt}; which is {Math.Abs(pt.X) + Math.Abs(pt.Y)} blocks away...");

      // correct:
      //   279

      return;
    }

    internal static void Solve_Part2()
    {
      Console.WriteLine("Solving Day 01, Part 2...");

      var directions = System.IO.File.ReadAllText("01.txt").Split(',');
      var pt = new Point();
      var hist = new List<string>();

      foreach (var direction in directions)
      {
        if (string.IsNullOrWhiteSpace(direction))
          continue;

        var beenThere = pt.Walk(
          direction.Trim().Substring(0, 1),
          int.Parse(direction.Trim().Substring(1)),
          true);
        if (beenThere)
          break;
      }

      // wrong:
      //   297 (high)
      // correct:
      //   163

      return;
    }

  }
}
