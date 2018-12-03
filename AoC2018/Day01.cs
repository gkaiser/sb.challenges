using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2018
{
  internal static class Day01
  {
    internal static void SolvePart1()
    {
      var raw = System.IO.File.ReadAllLines(@"M:\Documents\VS Projects\Challenges\AoC2018\InputData\Day01_P1.txt");
      var frq = 0;

      foreach (var r in raw)
        frq += int.Parse(r.Replace("+", ""));

      Console.WriteLine(frq);
    }

    internal static void SolvePart2()
    {
      // this has gotta be wildy inefficient; it takes ~48s to solve this way
      var watch = System.Diagnostics.Stopwatch.StartNew();

      var raw = System.IO.File.ReadAllLines(@"M:\Documents\VS Projects\Challenges\AoC2018\InputData\Day01_P1.txt");
      var enm = raw.GetEnumerator();
      var frq = 0;
      var seen = new List<int>();

      while (true)
      {
        if (!enm.MoveNext())
        {
          enm.Reset();
          enm.MoveNext();
        }

        var c = enm.Current.ToString();

        frq += int.Parse(c.Replace("+", ""));

        if (seen.Contains(frq))
          break;
        
        seen.Add(frq);
      }

      watch.Stop();
      var ts = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds);

      Console.WriteLine($"A frequency of {frq} was first seen twice (this took {ts.Minutes}m {ts.Seconds}s to solve)...");
    }

  }
}
