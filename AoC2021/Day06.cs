using System;
using System.Linq;

namespace AoC2021
{
  internal static class Day06
  {
    internal static void SolvePart1()
    {
      //var lst = new List<int> { 3,4,3,1,2 };
      var lst = System.IO.File.ReadAllText("Day06.txt").Split(',').Select(v => int.Parse(v)).ToList();
      var dmax = 80;

      for (int d = 0; d < dmax; d++)
      {
        var initLen = lst.Count;
        for (int i = 0; i < initLen; i++)
        {
          if (lst[i] == 0)
          {
            lst[i] = 6;
            lst.Add(8);
          }
          else
            lst[i]--;
        }
      }

      //Console.WriteLine($"After {dmax} days: {string.Join(",", lst)} ({lst.Count} fish)");
      Console.WriteLine($"After {dmax} days: {lst.Count} fish...");
    }

    internal static void SolvePart2()
    {
      //var lst = new List<int> { 3,4,3,1,2 };
      var lst = System.IO.File.ReadAllText("Day06.txt").Split(',').Select(v => int.Parse(v)).ToList();

      // we really only care about how many fish there are age 0 to 8
      var ages = new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
      foreach (var v in lst)
        ages[v]++;

      var dmax = 256;

      for (int d = 0; d < dmax; d++)
      {
        var newFishCt = ages[0]; // get count of fish about to birth a new fish

        for (int i = 0; i < ages.Length - 1; i++)
          ages[i] = ages[i + 1]; // shift all ages down (ignoring 8/newborns, as we set it below)

        ages[8] = newFishCt;  // new fishes
        ages[6] += newFishCt; // increase the # of age 6 fish by the # of fish who birthed a new one
      }

      Console.WriteLine($"After {dmax} days we've got {ages.Sum():N0} fish...");
    }

  }
}