using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2023
{
  internal static class Day02
  {
    internal static void SolvePart1()
    {
      //var inp = new[]
      //{
      //  "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
      //  "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
      //  "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
      //  "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
      //  "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
      //};
      var inp = System.IO.File.ReadAllLines("Day02.txt");

      var rMax = 12;
      var gMax = 13;
      var bMax = 14;
      var gVals = new List<int>();

      foreach (var l in inp)
      {
        var gid = int.Parse(l.Substring(5, l.IndexOf(':') - 5));
        var turns = l.Substring(l.IndexOf(':') + 2).Split(';');
        var isValid = true;

        foreach (var t in turns)
        {
          var shown = t.Split(',');

          foreach (var s in shown)
          {
            var cv = s.Trim().Split(' ');

            if (cv[1].StartsWith("r") && int.Parse(cv[0]) > rMax)
              isValid = false;
            else if (cv[1].StartsWith("g") && int.Parse(cv[0]) > gMax)
              isValid = false;
            else if (cv[1].StartsWith("b") && int.Parse(cv[0]) > bMax)
              isValid = false;
          }
        }

        if (isValid)
          gVals.Add(gid);
      }

      Console.WriteLine($"{string.Join(" + ", gVals)} = {gVals.Sum()}");
    }

    internal static void SolvePart2()
    {
      //var inp = new[]
      //{
      //  "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
      //  "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
      //  "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
      //  "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
      //  "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
      //};
      var inp = System.IO.File.ReadAllLines("Day02.txt");

      var sw = System.Diagnostics.Stopwatch.StartNew();

      var gs = 0;

      foreach (var l in inp)
      {
        var gid = int.Parse(l.Substring(5, l.IndexOf(':') - 5));
        var turns = l.Substring(l.IndexOf(':') + 2).Split(';');

        var rgb = new[] { 1, 1, 1 };

        foreach (var t in turns)
        {
          var shown = t.Split(',');

          foreach (var s in shown)
          {
            var ckvp = s.Trim().Split(' ');
            var cv = int.Parse(ckvp[0]);
            var cn = ckvp[1];

            if (cn[0] == 'r' && cv > rgb[0])
              rgb[0] = cv;
            else if (cn[0] == 'g' && cv > rgb[1])
              rgb[1] = cv;
            else if (cn[0] == 'b' && cv > rgb[2])
              rgb[2] = cv;
          }
        }

        gs += rgb[0] * rgb[1] * rgb[2];
      }

      sw.Stop();
      
      Console.WriteLine($"{gs}");
    }

  }
}
