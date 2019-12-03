using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2019
{
  internal class Day03
  {
    internal static void SolvePart1()
    {
      var lines = System.IO.File.ReadAllLines(@"Day03_P1.txt");
      var w1Ops = lines[0].Split(',');
      var w2Ops = lines[1].Split(',');

      var w1Posns = Day03.GenerateWirePoints(w1Ops);
      var w2Posns = Day03.GenerateWirePoints(w2Ops);
      var commPosns = w1Posns.Intersect(w2Posns).ToArray();

      var min = int.MaxValue;
      foreach (var pt in commPosns)
        if (pt.DistanceFromCentralPort < min)
          min = pt.DistanceFromCentralPort;

      // 2147483647 ==> HIGH
      // 1337       ==> CORRECT BUT SLOW (11:48 down to 113ms using simple Point struct vs class)

      Console.WriteLine($"Shortest distance is {min} from the central port...");
    }

    internal static void SolvePart2()
    {
      var lines = System.IO.File.ReadAllLines(@"Day03_P1.txt");
      var w1Ops = lines[0].Split(',');
      var w2Ops = lines[1].Split(',');

      var w1Posns = Day03.GenerateWirePoints(w1Ops);
      var w2Posns = Day03.GenerateWirePoints(w2Ops);
      var commPosns = w1Posns.Intersect(w2Posns).ToArray();

      var min = long.MaxValue;
      foreach (var pt in commPosns)
      {
        var w1 = w1Posns.Where(w1p => w1p.X == pt.X && w1p.Y == pt.Y);
        var w2 = w2Posns.Where(w2p => w2p.X == pt.X && w2p.Y == pt.Y);
        var w1Steps = w1.First().StepsFromOrigin;
        var w2Steps = w2.First().StepsFromOrigin;

        if (w1Steps + w2Steps < min)
          min = w1Steps + w2Steps;
      }

      // 65356 => CORRECT

      Console.WriteLine($"The fewest combined steps to an intersection is {min}...");
    }

    private static Point[] GenerateWirePoints(string[] wireOps)
    {
      var currX = 0;
      var currY = 0;
      var pts = new List<Point>();
      var sfo = 0;

      foreach (var op in wireOps)
      {
        var dir = op[0].ToString();
        var len = int.Parse(op.Substring(1));

        for (int i = 0; i < len; i++)
        {
          if (dir == "R")
            currX++;
          if (dir == "L")
            currX--;
          if (dir == "U")
            currY++;
          if (dir == "D")
            currY--;

          sfo++;

          pts.Add(new Point { X = currX, Y = currY, StepsFromOrigin = sfo });
        }
      }

      return pts.ToArray();
    }

    public struct Point
    {
      public int X { get; set; }
      
      public int Y { get; set; }

      public int StepsFromOrigin { get; set; }

      public int DistanceFromCentralPort => Math.Abs(this.X) + Math.Abs(this.Y);

      public override bool Equals(object obj) =>
        obj is Point pt2 &&
        pt2.X == this.X &&
        pt2.Y == this.Y;

      public override int GetHashCode()
      {
        unchecked // Overflow is fine, just wrap
        {
          var hash = 17;
          // Suitable nullity checks etc, of course :)
          hash = hash * 751 + this.X.GetHashCode();
          hash = hash * 751 + this.Y.GetHashCode();
          return hash;
        }
      }

    }

  }
}