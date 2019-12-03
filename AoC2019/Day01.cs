using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2019
{
  class Day01
  {
    public static void SolvePart1()
    {
      var lines = System.IO.File.ReadAllLines(@"Day01_P1.txt");

      var fuel = lines.ToList().Select(l => Math.Floor(decimal.Parse(l) / 3m) - 2).Sum();

      Console.WriteLine($"How's {fuel} fuel units sound?");
    }

    internal static void SolvePart2()
    {
      //var lines = new[] { "1969" };
      var lines = System.IO.File.ReadAllLines(@"Day01_P1.txt");
      var fuel = 0m;

      lines.ToList().ForEach(l =>
      {
        var fv = new List<decimal>();

        while (Math.Floor((fv.Count == 0 ? decimal.Parse(l) : fv.Last()) / 3m) - 2 > 0)
        {
          fv.Add(Math.Floor((fv.Count == 0 ? decimal.Parse(l) : fv.Last()) / 3m) - 2);
        }

        fuel += fv.Sum();
      });

      Console.WriteLine($"How's {fuel} fuel units sound?");
    }

  }
}
