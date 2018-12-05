using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AoC2018
{
  internal static class Day03
  {
    internal static void SolvePart1()
    {
      var lines = File.ReadAllLines(@"Day03_P1.txt");
      var dict = new Dictionary<Point, int>();

      foreach (var l in lines)
      {
        if (string.IsNullOrWhiteSpace(l))
          continue;

        // #123 @ 3,2: 5x4
        var vals = l.Split(' ');
        var id = vals[0].Replace("#", "");
        var loc = vals[2].Replace(":", "");
        var sz = vals[3];

        var locX = int.Parse(loc.Split(',')[0]);
        var locY = int.Parse(loc.Split(',')[1]);
        var width = int.Parse(sz.Split('x')[0]);
        var height = int.Parse(sz.Split('x')[1]);

        for (int i = 1; i <= width; i++)
        {
          for (int j = 1; j <= height; j++)
          {
            var pt = new Point(locX + i, locY + j);

            if (!dict.ContainsKey(pt))
              dict.Add(pt, 0);

            dict[pt]++;
          }
        }
      }
      
      var ct = dict.Values.Count(v => v > 1);

      // 1235 too low
      // 100595 BINGO

      Console.WriteLine($"{ct} inches of fabric are within 2 or more claims...");
    }

    internal static void SolvePart2()
    {
      var lines = File.ReadAllLines(@"Day03_P1.txt");
      var dict = new Dictionary<Point, int>();

      foreach (var l in lines)
      {
        if (string.IsNullOrWhiteSpace(l))
          continue;

        // #123 @ 3,2: 5x4
        var vals = l.Split(' ');
        var id = vals[0].Replace("#", "");
        var loc = vals[2].Replace(":", "");
        var sz = vals[3];

        var locX = int.Parse(loc.Split(',')[0]);
        var locY = int.Parse(loc.Split(',')[1]);
        var width = int.Parse(sz.Split('x')[0]);
        var height = int.Parse(sz.Split('x')[1]);

        for (int i = 1; i <= width; i++)
        {
          for (int j = 1; j <= height; j++)
          {
            var pt = new Point(locX + i, locY + j);

            if (!dict.ContainsKey(pt))
              dict.Add(pt, 0);

            dict[pt]++;
          }
        }
      }
      foreach (var l in lines)
      {
        if (string.IsNullOrWhiteSpace(l))
          continue;

        // #123 @ 3,2: 5x4
        var vals = l.Split(' ');
        var id = vals[0].Replace("#", "");
        var loc = vals[2].Replace(":", "");
        var sz = vals[3];

        var locX = int.Parse(loc.Split(',')[0]);
        var locY = int.Parse(loc.Split(',')[1]);
        var width = int.Parse(sz.Split('x')[0]);
        var height = int.Parse(sz.Split('x')[1]);
        var allOk = true;

        for (int i = 1; i <= width; i++)
        {
          for (int j = 1; j <= height; j++)
          {
            var pt = new Point(locX + i, locY + j);

            if (dict[pt] > 1)
            {
              allOk = false;
              break;
            }
          }
        }

        if (allOk)
        {
          Console.WriteLine($"It looks like ID {id} shares no space...");
          break;
        }
      }

      // 415 BINGO
    }

  }
}