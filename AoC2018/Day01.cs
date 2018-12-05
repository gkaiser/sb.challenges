using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2018
{
  internal static class Day01
  {
    internal static void SolvePart1()
    {
      var raw = System.IO.File.ReadAllLines(@"Day01_P1.txt");
      var frq = 0;

      foreach (var r in raw)
        frq += int.Parse(r);

      Console.WriteLine(frq);
    }

    internal static void SolvePart2()
    {
      // this was wildy inefficient when using List<int>; it takes ~48s to solve this way
      // switched to HashSet<int>, and got to under a second. WTF
      var watch = System.Diagnostics.Stopwatch.StartNew();

      var inp = System.IO.File.ReadAllLines(@"Day01_P1.txt");
      var frq = 0;
      var seen = new HashSet<int>();

      while (true)
      {
        foreach (var c in inp)
        {
          frq += int.Parse(c);

          if (seen.Contains(frq))
            goto P2End;

          seen.Add(frq);
        }
      }

      P2End:

      watch.Stop();
      var ts = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds);

      Console.WriteLine($"A frequency of {frq} was first seen twice (this took {ts} to solve)...");
    }

  }
}
