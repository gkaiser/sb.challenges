using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2017
{
  internal static class Day02
  {
    internal static void Solve_Part1()
    {
      //var input = new[]
      //{
      //  "5 1 9 5",
      //  "7 5 3",
      //  "2 4 6 8",
      //};
      var input = System.IO.File.ReadAllLines("Day02_Part1.txt");

      var diffs = new List<int>();

      foreach (var r in input)
      {
        var vals = r.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        var max = vals.Max();
        var min = vals.Min();

        var diff = max - min;

        diffs.Add(diff);
      }

      Console.WriteLine($"The spreadsheet's checksum is {diffs.Sum()}");
    }

    internal static void Solve_Part2()
    {
      //var input = new[]
      //{
      //  "5 9 2 8",
      //  "9 4 7 3",
      //  "3 8 6 5",
      //};
      var input = System.IO.File.ReadAllLines("Day02_Part1.txt");

      var quotients = new List<int>();

      foreach (var r in input)
      {
        var vals = r.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        for (int i = 0; i < vals.Count; i++)
        {
          var top = vals[i];
          var found = false;

          for (int j = 0; j < vals.Count; j++)
          {
            if (j == i)
              continue;
            if (top % vals[j] != 0)
              continue;

            quotients.Add(top / vals[j]);
            found = true;
            break;
          }

          if (found)
            break;
        }
      }

      Console.WriteLine($"The spreadsheet's even checksum is {quotients.Sum()}");
    }

  }
}
