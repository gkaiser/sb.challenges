using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
  internal static class Day09
  {
    internal static List<string> Input = new List<string>(System.IO.File.ReadAllLines("09.txt"));

    internal static void Process(bool runPart1)
    {
      Console.WriteLine("Day 9");

      if (runPart1)
        Day09.Part1();
      else
        Day09.Part2();
    }

    private static void Part1()
    {
      var locs = new List<string>();
      var legs = new Dictionary<string[], int>();
      foreach (var l in Day09.Input)
      {
        var t = l.Split(' ');
        var beg = t[0];
        var end = t[2];
        var len = int.Parse(t[4]);
        
        if (!locs.Contains(beg))
          locs.Add(beg);
        if (!locs.Contains(end))
          locs.Add(end);

        legs.Add(new[] { beg, end }, len);
        legs.Add(new[] { end, beg }, len);
      }

      Func<int, int> fFactorial = null;
      fFactorial = new Func<int, int>(i => { return (i <= 1 ? 1 : i * fFactorial(i - 1)); });

      var possRoutes = fFactorial(locs.Count);
      Console.WriteLine("Searching " + possRoutes + " routes...");

      var routes = new Dictionary<List<string>, int>();

      Func<string, List<string>> fGetLegs = null;
      fGetLegs = new Func<string, List<string>>(origin =>
      {
        var dest = new List<string>();
        foreach (string[] k in legs.Keys.Where(l => l[0] == origin))
        {
          if (!dest.Contains(k[1]))
            dest.Add(k[1]);
        }

        return dest;
      });

      for (int i = 0; i < locs.Count; i++)
      {

      }

      var rts = new List<string>();
      var shortLen = routes.Values.Min();
      foreach (List<string> dk in routes.Keys)
      {
        if (routes[dk] == shortLen)
          rts = dk;
      }

      Console.WriteLine("  We figured there are " + routes.Count + " possible routes, but Santa should go:");
      Console.WriteLine("    " + string.Join(" ==> ", rts) + shortLen);

      // wrong:
      //   406 high (Straylight ==> Snowdin ==> Norrath ==> Tambi ==> Tristram ==> Arbre ==> Faerun ==> AlphaCentauri 406)
    }

    private static void Part2()
    {

    }

  }
}
