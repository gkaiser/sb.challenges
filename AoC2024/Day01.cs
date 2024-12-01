using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace AoC2024
{
  internal static class Day01
  {
    internal static void SolvePart1()
    {
      //var inp = new []
      //{
      //  "3   4",
      //  "4   3",
      //  "2   5",
      //  "1   3",
      //  "3   9",
      //  "3   3",
      //};
      var inp = File.ReadAllLines("Day01.txt");

      var ll = inp.Select(il => int.Parse(il.Split("   ")[0])).ToList();
      var lr = inp.Select(il => int.Parse(il.Split("   ")[1])).ToList();

      ll.Sort();
      lr.Sort();

      var dist = 0;
      for (int i = 0; i < ll.Count; i++)
      {
        dist += Math.Abs(ll[i] - lr[i]);
      }

      Console.WriteLine(dist);
    }

    internal static void SolvePart2()
    {
      //var inp = new []
      //{
      //  "3   4",
      //  "4   3",
      //  "2   5",
      //  "1   3",
      //  "3   9",
      //  "3   3",
      //};
      var inp = File.ReadAllLines("Day01.txt");

      var ll = inp.Select(il => int.Parse(il.Split("   ")[0])).ToList();
      var lr = inp.Select(il => int.Parse(il.Split("   ")[1])).ToList();

      var siml = 0;
      for (int i = 0; i < ll.Count; i++)
      {
        siml += ll[i] * lr.Count(lrv => lrv == ll[i]);
      }

      Console.WriteLine(siml);
    }

  }
}
