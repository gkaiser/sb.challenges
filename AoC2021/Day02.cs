using System;
using System.Linq;

namespace AoC2021
{
  internal static class Day02
  {
    internal static void SolvePart1()
    {
      //var lines = new[]
      //{
      //  "forward 5",
      //  "down 5",
      //  "forward 8",
      //  "up 3",
      //  "down 8",
      //  "forward 2",
      //};
      var lines = System.IO.File.ReadAllLines("Day02.txt");
      var posn = new Day02Point(0, 0);

      foreach (var l in lines)
      {
        if (string.IsNullOrWhiteSpace(l))
          continue;

        var vals = l.Split(' ');

        if (vals[0][0] == 'f')
          posn.Horiz += int.Parse(vals[1]);
        else if (vals[0][0] == 'd')
          posn.Depth += int.Parse(vals[1]);
        else if (vals[0][0] == 'u')
          posn.Depth -= int.Parse(vals[1]);
      }

      Console.WriteLine($"Our position is horiz {posn.Horiz}, dept of {posn.Depth} (mult = {posn.Horiz * posn.Depth})...");
    }

    internal static void SolvePart2()
    {
      //var lines = new[]
      //{
      //  "forward 5",
      //  "down 5",
      //  "forward 8",
      //  "up 3",
      //  "down 8",
      //  "forward 2",
      //};
      var lines = System.IO.File.ReadAllLines("Day02.txt");
      var posn = new Day02Point(0, 0);

      foreach (var l in lines)
      {
        if (string.IsNullOrWhiteSpace(l))
          continue;

        var vals = l.Split(' ');

        if (vals[0][0] == 'f')
        {
          posn.Horiz += int.Parse(vals[1]);
          posn.Depth += posn.Aim * int.Parse(vals[1]);
        }
        else if (vals[0][0] == 'd')
          posn.Aim += int.Parse(vals[1]);
        else if (vals[0][0] == 'u')
          posn.Aim -= int.Parse(vals[1]);
      }

      Console.WriteLine($"Our position is horiz {posn.Horiz}, dept of {posn.Depth}, aim of {posn.Aim} (mult = {posn.Horiz * posn.Depth})...");
    }

  }
}
