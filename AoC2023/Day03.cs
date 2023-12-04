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

          var right = posns.Max(p => p.X);
          var left = posns.Min(p => p.X);

          // check right
          if (right + 1 < inp[y].Length && symbols.Contains(inp[y][right + 1]))
          {
            nums.Add(int.Parse(ts));
            continue;
          }

          // check left
          if (left - 1 >= 0 && symbols.Contains(inp[y][left - 1]))
          {
            nums.Add(int.Parse(ts));
            continue;
          }

          foreach (var p in posns)
          {
            // check above
            if (p.Y - 1 > 0 && p.X - 1 > 0 && symbols.Contains(inp[p.Y - 1][p.X - 1]))
            {
              nums.Add(int.Parse(ts));
              break;
            }
            if (p.Y - 1 > 0 && symbols.Contains(inp[p.Y - 1][p.X]))
            {
              nums.Add(int.Parse(ts));
              break;
            }
            if (p.Y - 1 > 0 && p.X + 1 < inp[p.Y].Length && symbols.Contains(inp[p.Y - 1][p.X + 1]))
            {
              nums.Add(int.Parse(ts));
              break;
            }

            // check below
            if (p.Y + 1 < inp.Length && p.X - 1 > 0 && symbols.Contains(inp[p.Y + 1][p.X - 1]))
            {
              nums.Add(int.Parse(ts));
              break;
            }
            if (p.Y + 1 < inp.Length && symbols.Contains(inp[p.Y + 1][p.X]))
            {
              nums.Add(int.Parse(ts));
              break;
            }
            if (p.Y + 1 < inp.Length && p.X + 1 < inp[p.Y].Length && symbols.Contains(inp[p.Y + 1][p.X + 1]))
            {
              nums.Add(int.Parse(ts));
              break;
            }
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

          var right = posns.Max(p => p.X);
          var left = posns.Min(p => p.X);

          // check right
          if (right + 1 < inp[y].Length && inp[y][right + 1] == '*')
          {
            if (gears.Any(g => g.Posn == new Pt(right + 1, y)))
              gears.First(g => g.Posn == new Pt(right + 1, y)).AdjNums.Add(int.Parse(ts));
            else
              gears.Add(new Gear { Posn = new Pt(right + 1, y), AdjNums = [int.Parse(ts)] });

            continue;
          }

          // check left
          if (left - 1 >= 0 && inp[y][left - 1] == '*')
          {
            if (gears.Any(g => g.Posn == new Pt(left - 1, y)))
              gears.First(g => g.Posn == new Pt(left - 1, y)).AdjNums.Add(int.Parse(ts));
            else
              gears.Add(new Gear { Posn = new Pt(left - 1, y), AdjNums = [int.Parse(ts)] });

            continue;
          }

          foreach (var p in posns)
          {
            // check above
            if (p.Y - 1 > 0 && p.X - 1 > 0 && inp[p.Y - 1][p.X - 1] == '*')
            {
              if (gears.Any(g => g.Posn == new Pt(p.X - 1, p.Y - 1)))
                gears.First(g => g.Posn == new Pt(p.X - 1, p.Y - 1)).AdjNums.Add(int.Parse(ts));
              else
                gears.Add(new Gear { Posn = new Pt(p.X - 1, p.Y - 1), AdjNums = [int.Parse(ts)] });
              break;
            }
            if (p.Y - 1 > 0 && inp[p.Y - 1][p.X] == '*')
            {
              if (gears.Any(g => g.Posn == new Pt(p.X, p.Y - 1)))
                gears.First(g => g.Posn == new Pt(p.X, p.Y - 1)).AdjNums.Add(int.Parse(ts));
              else
                gears.Add(new Gear { Posn = new Pt(p.X, p.Y - 1), AdjNums = [int.Parse(ts)] });
              break;
            }
            if (p.Y - 1 > 0 && p.X + 1 < inp[p.Y].Length && inp[p.Y - 1][p.X + 1] == '*')
            {
              if (gears.Any(g => g.Posn == new Pt(p.X + 1, p.Y - 1)))
                gears.First(g => g.Posn == new Pt(p.X + 1, p.Y - 1)).AdjNums.Add(int.Parse(ts));
              else
                gears.Add(new Gear { Posn = new Pt(p.X + 1, p.Y - 1), AdjNums = [int.Parse(ts)] });
              break;
            }

            // check below
            if (p.Y + 1 < inp.Length && p.X - 1 > 0 && inp[p.Y + 1][p.X - 1] == '*')
            {
              if (gears.Any(g => g.Posn == new Pt(p.X - 1, p.Y + 1)))
                gears.First(g => g.Posn == new Pt(p.X - 1, p.Y + 1)).AdjNums.Add(int.Parse(ts));
              else
                gears.Add(new Gear { Posn = new Pt(p.X - 1, p.Y + 1), AdjNums = [int.Parse(ts)] });
              break;
            }
            if (p.Y + 1 < inp.Length && inp[p.Y + 1][p.X] == '*')
            {
              if (gears.Any(g => g.Posn == new Pt(p.X, p.Y + 1)))
                gears.First(g => g.Posn == new Pt(p.X, p.Y + 1)).AdjNums.Add(int.Parse(ts));
              else
                gears.Add(new Gear { Posn = new Pt(p.X, p.Y + 1), AdjNums = [int.Parse(ts)] });
              break;
            }
            if (p.Y + 1 < inp.Length && p.X + 1 < inp[p.Y].Length && inp[p.Y + 1][p.X + 1] == '*')
            {
              if (gears.Any(g => g.Posn == new Pt(p.X + 1, p.Y + 1)))
                gears.First(g => g.Posn == new Pt(p.X + 1, p.Y + 1)).AdjNums.Add(int.Parse(ts));
              else
                gears.Add(new Gear { Posn = new Pt(p.X + 1, p.Y + 1), AdjNums = [int.Parse(ts)] });
              break;
            }
          }
        }
      }

      var ratios = new List<int>();
      foreach (var g in gears)
      {
        //Console.WriteLine($"Gear at {{{g.Posn}}}:");
        //foreach (var n in g.AdjNums)
        //{
        //  Console.WriteLine($"  {n}");
        //}

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