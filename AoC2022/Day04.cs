using System;
using System.Linq;

namespace AoC2022
{
  internal class Day04
  {
    private static string[] TestInput = new[]
    {
      "2-4,6-8",
      "2-3,4-5",
      "5-7,7-9",
      "2-8,3-7",
      "6-6,4-6",
      "2-6,4-8",
    };

    internal static void SolvePart1()
    {
      //var inp = Day04.TestInput;
      var inp = System.IO.File.ReadAllLines(@"Day04.txt");

      var ct = 0;
      foreach (var l in inp)
      {
        var p1s = l.Split(',')[0];
        var p2s = l.Split(',')[1];

        var p1beg = int.Parse(p1s.Split('-')[0]);
        var p1len = int.Parse(p1s.Split('-')[1]) - int.Parse(p1s.Split('-')[0]) + 1;
        var p1 = Enumerable.Range(p1beg, p1len).ToArray();

        var p2beg = int.Parse(p2s.Split('-')[0]);
        var p2len = int.Parse(p2s.Split('-')[1]) - int.Parse(p2s.Split('-')[0]) + 1;
        var p2 = Enumerable.Range(p2beg, p2len).ToArray();

        if (p1.Intersect(p2).Count() == p1.Length || p1.Intersect(p2).Count() == p2.Length)
          ct++;
      }

      Console.WriteLine($"There are {ct} assignment-pairs where one fully contains the other...");
    }

    internal static void SolvePart2()
    {
      //var inp = Day04.TestInput;
      var inp = System.IO.File.ReadAllLines(@"Day04.txt");

      var ct = 0;
      foreach (var l in inp)
      {
        var p1s = l.Split(',')[0];
        var p2s = l.Split(',')[1];

        var p1beg = int.Parse(p1s.Split('-')[0]);
        var p1len = int.Parse(p1s.Split('-')[1]) - int.Parse(p1s.Split('-')[0]) + 1;
        var p1 = Enumerable.Range(p1beg, p1len).ToArray();

        var p2beg = int.Parse(p2s.Split('-')[0]);
        var p2len = int.Parse(p2s.Split('-')[1]) - int.Parse(p2s.Split('-')[0]) + 1;
        var p2 = Enumerable.Range(p2beg, p2len).ToArray();

        if (p1.Intersect(p2).ToArray().Length > 0)
          ct++;
      }

      Console.WriteLine($"There are {ct} assignment-pairs where one fully contains the other...");
    }

  }
}
