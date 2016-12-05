using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2016
{
  internal static class Day03
  {
    internal static void Solve_Part1()
    {
      Console.WriteLine("Solving Day 03, Part 1...");

      var lstMins = new List<int>();
      var possCt = 0;

      var input = System.IO.File.ReadAllLines("03.txt");
      foreach (var l in input)
      {
        if (string.IsNullOrWhiteSpace(l))
          continue;

        var allSidesStr = l.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        var allSides = allSidesStr.Select(s => int.Parse(s)).ToList();
        var smSides = new int[2];

        smSides[0] = allSides.Min();
        allSides.Remove(smSides[0]);

        smSides[1] = allSides.Min();
        allSides.Remove(smSides[1]);

        if (smSides[0] + smSides[1] > allSides[0])
          possCt++;
      }

      // correct:
      //   982

      Console.WriteLine($"There are {possCt} valid triangles in there.");
    }

    internal static void Solve_Part2()
    {
      Console.WriteLine("Solving Day 03, Part 2...");

      var lstMins = new List<int>();
      var possCt = 0;

      var input = System.IO.File.ReadAllLines("03.txt");
      for (int i = 0; i < input.Length;)
      {
        if (string.IsNullOrWhiteSpace(input[i]))
          break;
        for (int j = 0; j < 3; j++)
        {
          var allSidesStr = new[] {
            input[i + 0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[j],
            input[i + 1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[j],
            input[i + 2].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[j]
          }.ToList();
          var allSides = allSidesStr.Select(s => int.Parse(s)).ToList();
          var smSides = new int[2];

          smSides[0] = allSides.Min();
          allSides.Remove(smSides[0]);

          smSides[1] = allSides.Min();
          allSides.Remove(smSides[1]);

          if (smSides[0] + smSides[1] > allSides[0])
            possCt++;
        }

        i += 3;
      }

      // correct:
      //   1826

      Console.WriteLine($"There are {possCt} valid triangles in there.");
    }

  }
}
