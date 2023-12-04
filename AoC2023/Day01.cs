using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2023
{
  internal static class Day01
  {
    internal static void SolvePart1()
    {
      //var inp = new[]
      //{
      //  "1abc2",
      //  "pqr3stu8vwx",
      //  "a1b2c3d4e5f",
      //  "treb7uchet",
      //};
      var inp = System.IO.File.ReadAllLines("Day01.txt");

      var s = 0;

      foreach (var l in inp)
      {
        var ca = l.Where(c => char.IsDigit(c)).ToArray();
        if (ca.Length == 1)
          ca = new[] { ca[0], ca[0] };
        else if (ca.Length > 2)
          ca = new[] { ca[0], ca[ca.Length - 1] };

        var cs = new string(ca);

        s += int.Parse(cs);
      }

      Console.WriteLine($"{s}");
    }

    internal static void SolvePart2()
    {
      //var inp = new[]
      //{
      //  "two1nine",
      //  "eightwothree",
      //  "abcone2threexyz",
      //  "xtwone3four",
      //  "4nineeightseven2",
      //  "zoneight234",
      //  "7pqrstsixteen",
      //};
      var inp = System.IO.File.ReadAllLines("Day01.txt");

      var dictNums = new Dictionary<string, int>
      {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
      };

      var s = 0;

      foreach (var l in inp)
      {
        var ns = "";

        for (int j = 0; j < l.Length; j++)
        {
          if (char.IsDigit(l[j]))
          {
            ns += $"{l[j]}";
            continue;
          }

          var foundWord = false;
          foreach (var k in dictNums.Keys)
          {
            if (j + k.Length > l.Length)
              continue;

            var lv = l.Substring(j, k.Length);
            if (lv == k)
            {
              ns += $"{dictNums[k]}";
              foundWord = true;
              break;
            }
          }

          if (!foundWord)
            ns += $"{l[j]}";
        }

        var ca = ns.Where(c => char.IsDigit(c)).ToArray();
        if (ca.Length == 1)
          ca = new[] { ca[0], ca[0] };
        else if (ca.Length > 2)
          ca = new[] { ca[0], ca[ca.Length - 1] };

        var cs = new string(ca);

        s += int.Parse(cs);
      }

      // 55427 low
      // 55429 correct (modifying the original string wasn't the way to go)

      Console.WriteLine($"{s}");
    }

  }
}
