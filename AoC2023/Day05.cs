using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AoC2023
{
  internal class Day05
  {
    internal static void SolvePart1()
    {
      var inp = new[]
      {
        "seeds: 98 79 14 55 13",
        "",
        "seed-to-soil map:",
        "50 98 2",
        "52 50 48",
        "",
        "soil-to-fertilizer map:",
        "0 15 37",
        "37 52 2",
        "39 0 15",
        "",
        "fertilizer-to-water map:",
        "49 53 8",
        "0 11 42",
        "42 0 7",
        "57 7 4",
        "",
        "water-to-light map:",
        "88 18 7",
        "18 25 70",
        "",
        "light-to-temperature map:",
        "45 77 23",
        "81 45 19",
        "68 64 13",
        "",
        "temperature-to-humidity map:",
        "0 69 1",
        "1 0 69",
        "",
        "humidity-to-location map:",
        "60 56 37",
        "56 93 4",
      };
      //var inp = System.IO.File.ReadAllLines("Day05.txt");

      var seeds = inp[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(ulong.Parse).ToArray();

      var maps = new List<Tuple<ulong, ulong, ulong>>();

      for (int i = 3; i < inp.Length; i++)
      {
        while (inp[i] != "")
        {
          var vals = inp[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

          maps.Add(new Tuple<ulong, ulong, ulong>(ulong.Parse(vals[0]), ulong.Parse(vals[1]), ulong.Parse(vals[2])));
        }

        // now we're on the blank line, skip to next num-line
        i += 2;

        // process the seeds with the latest maps

        for (int j = 0; j < seeds.Length; j++)
        {
          if (seeds[j] < src)
            continue;
          if (seeds[j] < src + rng)
          {
            //          50    98      98
            seeds[j] = dst + (src - seeds[j]);
            continue;
          }
        }
      }

      Console.WriteLine("p1...");
    }

    internal static void SolvePart2()
    {
      var inp = new[]
      {
        ""
      };

      Console.WriteLine("p2...");
    }

  }
}