using System;
using System.Linq;

namespace AoC2020
{
  public static class Day03
  {
    private class Pt
    {
      public int X;
      public int Y;
    }

    public static void SolvePart1()
    {
      // var lines = new[] {
      //   "..##.......",
      //   "#...#...#..",
      //   ".#....#..#.",
      //   "..#.#...#.#",
      //   ".#...##..#.",
      //   "..#.##.....",
      //   ".#.#.#....#",
      //   ".#........#",
      //   "#.##...#...",
      //   "#...##....#",
      //   ".#..#...#.#",       
      // };
      var lines = new string[0];
      if (System.IO.File.Exists("Day03.txt"))
        lines = System.IO.File.ReadAllLines(@"Day03.txt");
      else
        lines = System.IO.File.ReadAllLines(@"bin\Debug\netcoreapp3.1\Day03.txt");

      var map = new string[lines.Length];

      var llen = lines[0].Length;
      var stpX = 3;
      var stpY = 1;
      var maxw = stpX * map.Length;
      var posn = new Pt { X = 0, Y = 0 };

      for (int i = 0; i < lines.Length; i++)
      {
        for (int l = 0; l < (maxw / llen) + 1; l++)
        {
          for (int j = 0; j < llen; j++)
          {
            map[i] += lines[i][j];
          }
        }
      }

      var hits = 0;

      while (posn.Y + stpY < map.Length)
      {
        posn.X += stpX;
        posn.Y += stpY;

        if (posn.Y >= map.Length)
          break;
        if (map[posn.Y][posn.X] == '#')
          hits++;
      }

      Console.WriteLine($"Cap'n, we report {hits} hits!");
    }

    public static void SolvePart2()
    {
      // var lines = new[] {
      //   "..##.......",
      //   "#...#...#..",
      //   ".#....#..#.",
      //   "..#.#...#.#",
      //   ".#...##..#.",
      //   "..#.##.....",
      //   ".#.#.#....#",
      //   ".#........#",
      //   "#.##...#...",
      //   "#...##....#",
      //   ".#..#...#.#",       
      // };
      var lines = new string[0];
      if (System.IO.File.Exists("Day03.txt"))
        lines = System.IO.File.ReadAllLines(@"Day03.txt");
      else
        lines = System.IO.File.ReadAllLines(@"bin\Debug\netcoreapp3.1\Day03.txt");

      var slopes = new System.Collections.Generic.List<int[]>()
      {
        new[] { 1, 1 },
        new[] { 3, 1 },
        new[] { 5, 1 },
        new[] { 7, 1 },
        new[] { 1, 2 },
      };
      var slopeHits = new System.Collections.Generic.List<int>();

      foreach (var s in slopes)
      {
        var stpX = s[0];
        var stpY = s[1];

        var map = new string[lines.Length];
        var llen = lines[0].Length;
        var maxw = stpX * map.Length;
        var posn = new Pt { X = 0, Y = 0 };

        for (int i = 0; i < lines.Length; i++)
        {
          for (int l = 0; l < (maxw / llen) + 1; l++)
          {
            for (int j = 0; j < llen; j++)
            {
              map[i] += lines[i][j];
            }
          }
        }

        var hits = 0;

        while (posn.Y + stpY < map.Length)
        {
          posn.X += stpX;
          posn.Y += stpY;

          if (posn.Y >= map.Length)
            break;
          if (map[posn.Y][posn.X] == '#')
            hits++;
        }

        slopeHits.Add(hits);
        Console.WriteLine($"Cap'n, we report {hits} hits!");
      }

      Console.WriteLine($"The product of {string.Join(" * ", slopeHits)} is {slopeHits.Aggregate(1, (acc, val) => acc * val)}");
    }

  }
}