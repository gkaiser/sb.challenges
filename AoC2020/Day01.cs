using System;
using System.Linq;

namespace AoC2020
{
  public static class Day01
  {
    public static void SolvePart1()
    {
      //var lines = new[] { "1721", "979", "366", "299", "675", "1456", };
      var lines = new string[0];
      if (System.IO.File.Exists("Day01.txt"))
        lines = System.IO.File.ReadAllLines(@"Day01.txt");
      else
        lines = System.IO.File.ReadAllLines(@"bin\Debug\netcoreapp3.1\Day01.txt");

      var hs = new System.Collections.Generic.HashSet<long>();

      foreach (var l in lines)
      {
        var i = long.Parse(l);

        if (i > 2020)
          continue;
        if (!hs.Contains(i))
          hs.Add(i);
      }

      foreach (var l in lines)
      {
        var i = long.Parse(l);
        var d = 2020 - i;

        if (hs.Contains(d))
        {
          Console.WriteLine(i * d);
          break;
        }
      }
    }

    public static void SolvePart2()
    {
      //var lines = new[] { "1721", "979", "366", "299", "675", "1456", };
      var lines = new string[0];
      if (System.IO.File.Exists("Day01.txt"))
        lines = System.IO.File.ReadAllLines(@"Day01.txt");
      else
        lines = System.IO.File.ReadAllLines(@"bin\Debug\netcoreapp3.1\Day01.txt");

      var hs = new System.Collections.Generic.HashSet<long>();

      foreach (var l in lines)
      {
        var i = long.Parse(l);

        if (i > 2020)
          continue;
        if (!hs.Contains(i))
          hs.Add(i);
      }

      foreach (var l in lines)
      {
        var i = long.Parse(l);
        var d = 2020 - i;

        var nums = FindNumbers(d, lines, hs);
        if (nums.Length > 0)
        {
          Console.WriteLine(i * nums[0] * nums[1]);
          break;
        }
      }
    }

    public static long[] FindNumbers(long goal, string[] lines, System.Collections.Generic.HashSet<long> hs)
    {
      foreach (var l in lines)
      {
        var i = long.Parse(l);
        var d = goal - i;

        if (hs.Contains(d))
        {
          return new[] { i, d };
        }
      }

      return new long[0];
    }

  }
}