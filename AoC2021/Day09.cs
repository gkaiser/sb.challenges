using System;
using System.Linq;

namespace AoC2021
{
  internal class Day09
  {
    internal static void SolvePart1()
    {
      var inp = new[]
      {
        "2199943210",
        "3987894921",
        "9856789892",
        "8767896789",
        "9899965678",
      };
      var grid = new int[inp.Length][];
      for (int i = 0; i < inp.Length; i++)
      {
        grid[i] = new int[inp[i].Length];

        for (int j = 0; j < inp[i].Length; j++)
          grid[i][j] = int.Parse($"{inp[i][j]}");
      }

      return;
    }

  }
}
