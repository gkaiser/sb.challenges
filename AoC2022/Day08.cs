using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2022
{
  internal class Day08
  {
    internal static string[] TestInput = new[]
    {
      "30373",
      "25512",
      "65332",
      "33549",
      "35390",
    };

    internal static void SolvePart1()
    {
      //var inp = Day08.TestInput;
      var inp = System.IO.File.ReadAllLines(@"Day08.txt");

      var height = inp.Length;
      var width = inp[0].Length;
      var forest = new int[height, width];

      for (int i = 0; i < height; i++)
      {
        for (int j = 0; j < width; j++)
        {
          forest[i, j] = int.Parse($"{inp[i][j]}");
        }
      }

      var visible = (width * 2) + ((height - 2) * 2);

      for (int i = 1; i < height - 1; i++)
      {
        for (int j = 1; j < width - 1; j++)
        {
          var tree = forest[i, j];

          // determine if tree is visible from the...
          // left
          var left = new List<int>();
          for (int k = j - 1; k >= 0; k--)
            left.Add(forest[i, k]);

          // right
          var right = new List<int>();
          for (int k = j + 1; k < width; k++)
            right.Add(forest[i, k]);

          // up
          var up = new List<int>();
          for (int k = i - 1; k >= 0; k--)
            up.Add(forest[k, j]);

          // down
          var down = new List<int>();
          for (int k = i + 1; k < height; k++)
            down.Add(forest[k, j]);

          if (left.All(l => l < tree) ||
              right.All(l => l < tree) ||
              up.All(l => l < tree) ||
              down.All(l => l < tree))
          {
            visible++;
          }
        }
      }

      // 10758 = high
      // 1546
      Console.WriteLine($"There are {visible:N0} trees visible from the outside the grid...");
    }

    internal static void SolvePart2()
    {
      //var inp = Day08.TestInput;
      var inp = System.IO.File.ReadAllLines(@"Day08.txt");

      var height = inp.Length;
      var width = inp[0].Length;
      var forest = new int[height, width];

      for (int i = 0; i < height; i++)
      {
        for (int j = 0; j < width; j++)
        {
          forest[i, j] = int.Parse($"{inp[i][j]}");
        }
      }

      var maxScenic = 0;

      for (int i = 0; i < height; i++)
      {
        for (int j = 0; j < width; j++)
        {
          var tree = forest[i, j];

          // left
          var left = 0;
          for (int k = j - 1; k >= 0; k--)
          {
            if (forest[i, k] < tree)
              left++;
            if (forest[i, k] >= tree)
            {
              left++;
              break;
            }
          }

          // right
          var right = 0;
          for (int k = j + 1; k < width; k++)
          {
            if (forest[i, k] < tree)
              right++;
            if (forest[i, k] >= tree)
            {
              right++;
              break;
            }
          }

          // up
          var up = 0;
          for (int k = i - 1; k >= 0; k--)
          {
            if (forest[k, j] < tree)
              up++;
            if (forest[k, j] >= tree)
            {
              up++;
              break;
            }
          }

          // down
          var down = 0;
          for (int k = i + 1; k < height; k++)
          {
            if (forest[k, j] < tree)
              down++;
            if (forest[k, j] >= tree)
            {
              down++;
              break;
            }
          }

          var s = left * right * up * down;
          if (s > maxScenic)
            maxScenic = s;

          //Console.WriteLine($"{{{j}, {i}}} T: {tree} S: {s} U: {up.Count()} L: {left.Count()} D: {down.Count()} R: {right.Count()}");
        }
      }

      // 519064
      Console.WriteLine($"There highest possible sceneic score is {maxScenic}...");
    }

  }
}