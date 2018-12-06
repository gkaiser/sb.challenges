using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AoC2018
{
  internal static class Day01
  {
    internal static void SolvePart1()
    {
      Console.WriteLine(File.ReadAllLines(@"Day01_P1.txt").Sum(r => int.Parse(r)));
    }

    internal static void SolvePart2()
    {
      // this was wildy inefficient when using List<int>; it takes ~48s to solve this way
      // switched to HashSet<int>, and got to under a second. WTF
      var inp = File.ReadAllLines(@"Day01_P1.txt");
      var frq = 0;
      var seen = new HashSet<int>();

      for (int i = 0; ; i++)
      {
        frq += int.Parse(inp[i % inp.Length]);

        if (seen.Contains(frq))
          break;

        seen.Add(frq);
      }

      Console.WriteLine($"A frequency of {frq} was first seen twice...");
    }

  }
}
