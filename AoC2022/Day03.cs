using System;
using System.Linq;

namespace AoC2022
{
  internal static class Day03
  {
    private static string[] TestInput = new[]
    {
      "vJrwpWtwJgWrhcsFMMfFFhFp",
      "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
      "PmmdzqPrVvPwwTWBwg",
      "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
      "ttgJtRGJQctTZtZT",
      "CrZsJsPPZsGzwwsLwLmpwMDw",
    };

    private static readonly string CharPointMap = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    internal static void SolvePart1()
    {
      //var inp = Day03.TestInput;
      var inp = System.IO.File.ReadAllLines("Day03.txt");
      var priSum = 0;

      foreach (var rsack in inp)
      {
        var c1 = rsack.Substring(0, rsack.Length / 2);
        var c2 = rsack.Substring(rsack.Length / 2);
        var comm = c1.Intersect(c2);

        priSum += comm.Sum(c => Day03.CharPointMap.IndexOf(c));
      }

      // 8105
      Console.WriteLine($"Total Priority: {priSum}");
    }

    internal static void SolvePart2()
    {
      //var inp = Day03.TestInput;
      var inp = System.IO.File.ReadAllLines("Day03.txt");
      var priSum = 0;

      for (int i = 0; i < inp.Length; i += 3)
      {
        var s1 = inp[i + 0];
        var s2 = inp[i + 1];
        var s3 = inp[i + 2];
        var comm = s1.Intersect(s2).Intersect(s3);

        priSum += comm.Sum(c => Day03.CharPointMap.IndexOf(c));
      }

      // 2363
      Console.WriteLine($"Total Priority: {priSum}");
    }

  }
}
