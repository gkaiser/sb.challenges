using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2023
{
  internal class Day03
  {
    internal static void SolvePart1()
    {
      var symbols = new[] { '&', '+', '-', '#', '@', '$', '*', '/', '%', '=' };

      //var inp = new[]
      //{
      //  "467..114..",
      //  "...*......",
      //  "..35..633.",
      //  "......#...",
      //  "617*......",
      //  ".....+.58.",
      //  "..592.....",
      //  "......755.",
      //  "...$.*....",
      //  ".664.598..",
      //};
      var inp = System.IO.File.ReadAllLines("Day03.txt");

      var nums = new List<int>();

      for (int y = 0; y < inp.Length; y++)
      {
        for (int x = 0; x < inp[y].Length; x++)
        {
          if (inp[y][x] == '.' || !char.IsDigit(inp[y][x]))
            continue;

          // build the number
          var ts = $"{inp[y][x]}";
          var posns = new List<Pt> { new Pt(x, y) };

          while (x + 1 < inp[y].Length && char.IsDigit(inp[y][x + 1]))
          {
            x++;

            ts += $"{inp[y][x]}";
            posns.Add(new Pt(x, y));
          }

          foreach (var p in posns)
          {
            var foundSymbol = false;

            for (int k = -1; k <= 1; k++)
            {
              var yInRange = p.Y + k >= 0 && p.Y + k < inp.Length;

              // we can do a second loop here for the x-position as well, but it feels
              // a little forced for just 3 positions. plus, it'd be another loop we'd
              // have to break out of. meh.
              if (yInRange && p.X - 1 > 0 && symbols.Contains(inp[p.Y + k][p.X - 1]))
              {
                nums.Add(int.Parse(ts));
                foundSymbol = true;
                break;
              }
              if (yInRange && symbols.Contains(inp[p.Y + k][p.X]))
              {
                nums.Add(int.Parse(ts));
                foundSymbol = true;
                break;
              }
              if (yInRange && p.X + 1 < inp[p.Y].Length && symbols.Contains(inp[p.Y + k][p.X + 1]))
              {
                nums.Add(int.Parse(ts));
                foundSymbol = true;
                break;
              }
            }

            if (foundSymbol)
              break;
          }
        }
      }

      //Console.WriteLine($"{string.Join(", ", nums)} {nums.Sum()}");
      Console.WriteLine($"{nums.Sum()}");
    }

    internal static void SolvePart2()
    {
      //var inp = new[]
      //{
      //  "467..114..",
      //  "...*......",
      //  "..35..633.",
      //  "......#...",
      //  "617*......",
      //  ".....+.58.",
      //  "..592.....",
      //  "......755.",
      //  "...$.*....",
      //  ".664.598..",
      //};
      var inp = System.IO.File.ReadAllLines("Day03.txt");

      var gears = new List<Gear>();

      for (int y = 0; y < inp.Length; y++)
      {
        for (int x = 0; x < inp[y].Length; x++)
        {
          if (inp[y][x] == '.' || !char.IsDigit(inp[y][x]))
            continue;

          var ts = $"{inp[y][x]}";
          var posns = new List<Pt> { new Pt(x, y) };

          while (x + 1 < inp[y].Length && char.IsDigit(inp[y][x + 1]))
          {
            x++;

            ts += $"{inp[y][x]}";
            posns.Add(new Pt(x, y));
          }

          foreach (var p in posns)
          {
            var foundGear = false;

            for (int k = -1; k <= 1; k++)
            {
              var yc = p.Y + k;
              var yInRange = yc >= 0 && yc < inp.Length;

              if (yInRange && p.X - 1 >= 0 && inp[yc][p.X - 1] == '*')
              {
                if (gears.Any(g => g.Posn == new Pt(p.X - 1, yc)))
                  gears.First(g => g.Posn == new Pt(p.X - 1, yc)).AdjNums.Add(int.Parse(ts));
                else
                  gears.Add(new Gear { Posn = new Pt(p.X - 1, yc), AdjNums = [int.Parse(ts)] });
                foundGear = true;
              }
              if (yInRange && inp[p.Y + k][p.X] == '*')
              {
                if (gears.Any(g => g.Posn == new Pt(p.X, yc)))
                  gears.First(g => g.Posn == new Pt(p.X, yc)).AdjNums.Add(int.Parse(ts));
                else
                  gears.Add(new Gear { Posn = new Pt(p.X, yc), AdjNums = [int.Parse(ts)] });
                foundGear = true;
              }
              if (yInRange && p.X + 1 < inp[yc].Length && inp[yc][p.X + 1] == '*')
              {
                if (gears.Any(g => g.Posn == new Pt(p.X + 1, yc)))
                  gears.First(g => g.Posn == new Pt(p.X + 1, yc)).AdjNums.Add(int.Parse(ts));
                else
                  gears.Add(new Gear { Posn = new Pt(p.X + 1, yc), AdjNums = [int.Parse(ts)] });
                foundGear = true;
              }
            }

            if (foundGear)
              break;
          }
        }
      }

      var ratios = new List<int>();
      foreach (var g in gears)
      {
        if (g.AdjNums.Count == 2)
          ratios.Add(g.AdjNums[0] * g.AdjNums[1]);
      }

      // 78997538 low

      //Console.WriteLine($"{string.Join(", ", ratios)} {ratios.Sum()}");
      Console.WriteLine($"{ratios.Sum()}");
    }


    internal class Gear
    {
      public Pt Posn;
      public List<int> AdjNums = new List<int>();
    }

  }
}