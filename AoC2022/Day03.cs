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

        foreach (var c in comm)
        {
          if (c >= 97 && c <= 122)
            priSum += c - 96;
          else if (c >= 65 && c <= 90)
            priSum += c - 38;
        }
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

        foreach (var c in comm)
        {
          if (c >= 97 && c <= 122)
            priSum += c - 96;
          else if (c >= 65 && c <= 90)
            priSum += c - 38;
        }
      }

      // 2363
      Console.WriteLine($"Total Priority: {priSum}");
    }

  }
}
