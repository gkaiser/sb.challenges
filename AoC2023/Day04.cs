using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2023
{
  internal class Day04
  {
    internal static void SolvePart1()
    {
      //var inp = new[]
      //{
      //  "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
      //  "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
      //  "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
      //  "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
      //  "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
      //  "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
      //};
      var inp = System.IO.File.ReadAllLines("Day04.txt");

      var pt = 0;

      foreach (var l in inp)
      {
        var vals = l.Substring(l.IndexOf(":") + 1);
        var wnums = vals.Split('|')[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(wn => int.Parse(wn));
        var pnums = vals.Split('|')[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(pn => int.Parse(pn));

        var winCt = wnums.Intersect(pnums).Count();

        pt += (int)Math.Pow(2, winCt - 1);
      }

      Console.WriteLine($"p1 {pt}...");
    }

    internal static void SolvePart2()
    {
      //var inp = new[]
      //{
      //  "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
      //  "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
      //  "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
      //  "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
      //  "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
      //  "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
      //};
      var inp = System.IO.File.ReadAllLines("Day04.txt");

      var sw = System.Diagnostics.Stopwatch.StartNew();

      var inpNums = new int[inp.Length][];
      for (int i = 0; i < inp.Length; i++)
      {
        var l = inp[i];
        var vals = l.Substring(l.IndexOf(":") + 1);
        var wnums = vals.Split('|')[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(wn => int.Parse(wn)).ToArray();
        var pnums = vals.Split('|')[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(pn => int.Parse(pn)).ToArray();

        var dest = new int[1 + wnums.Length + pnums.Length];

        dest[0] = wnums.Length;
        Array.ConstrainedCopy(wnums, 0, dest, 0 + 1, wnums.Length);
        Array.ConstrainedCopy(pnums, 0, dest, wnums.Length + 1, pnums.Length);

        inpNums[i] = dest;
      }

      var ct = 0;

      for (int i = 0; i < inp.Length; i++)
      {
        var cards = new List<int> { i };

        ct++;

        for (int j = 0; j < cards.Count; j++)
        {
          var anums = inpNums[cards[j]];
          var wnums = new int[anums[0]];
          var pnums = new int[anums.Length - 1 - anums[0]];

          Array.ConstrainedCopy(anums, 1, wnums, 0, wnums.Length);
          Array.ConstrainedCopy(anums, 1 + wnums.Length, pnums, 0, pnums.Length);

          var winct = wnums.Intersect(pnums).Count();

          while (winct > 0)
          {
            cards.Add(cards[j] + winct);

            ct++;

            winct--;
          }
        }
      }

      sw.Stop();

      // Sum is 6874754 (00:00:16.3818233)...
      // Sum is 6874754 (00:00:03.1640473)...
      Console.WriteLine($"Sum is {ct} ({sw.Elapsed})...");
    }

  }
}