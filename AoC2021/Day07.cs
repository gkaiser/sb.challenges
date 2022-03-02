using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2021
{
  internal static class Day07
  {
    internal static void SolvePart1()
    {
      //var inp = new int[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };
      var inp = System.IO.File.ReadAllText("Day07.txt").Split(',').Select(v => int.Parse(v)).ToArray();
      var minPos = inp.Min();
      var maxPos = inp.Max();

      var dict = new Dictionary<int, int>();

      for (int testPosn = minPos; testPosn <= maxPos; testPosn++)
      {
        var fuelCost = 0;
        foreach (var initPosn in inp)
        {
          fuelCost += Math.Abs(initPosn - testPosn);
        }

        dict.Add(testPosn, fuelCost);
      }

      var minFuel = dict.Values.Min();

      foreach (var posn in dict.Keys)
      {
        if (dict[posn] != minFuel)
          continue;

        Console.WriteLine($"Position {posn} results in least fuel used: {minFuel} unit(s)...");
        break;
      }
    }

    internal static void SolvePart2()
    {
      //var inp = new int[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };
      var inp = System.IO.File.ReadAllText("Day07.txt").Split(',').Select(v => int.Parse(v)).ToArray();
      var minPos = inp.Min();
      var maxPos = inp.Max();

      var dict = new Dictionary<int, int>();

      for (int testPosn = minPos; testPosn <= maxPos; testPosn++)
      {
        var f = 0;
        foreach (var initPosn in inp)
        {
          var moveDist = Math.Abs(initPosn - testPosn);
          f += (moveDist * (moveDist + 1)) / 2; 
        }

        dict.Add(testPosn, f);
      }

      var minFuel = dict.Values.Min();

      foreach (var k in dict.Keys)
      {
        if (dict[k] != minFuel)
          continue;

        Console.WriteLine($"Position {k} results in least fuel used: {minFuel} unit(s)...");
        break;
      }
    }


  }
}
