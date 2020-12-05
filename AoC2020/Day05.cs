using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2020
{
  public static class Day05
  {
    public static void SolvePart1()
    {
      // var lines = new[] {
      //   "FBFBBFFRLR",
      //   "BFFFBBFRRR",
      //   "FFFBBBFRRR",
      //   "BBFFBBFRLL",
      // };
      var lines = new string[0];
      if (System.IO.File.Exists("Day05.txt"))
        lines = System.IO.File.ReadAllLines(@"Day05.txt");
      else
        lines = System.IO.File.ReadAllLines(@"bin\Debug\netcoreapp3.1\Day05.txt");

      var ids = new List<int>();

      foreach (var l in lines)
      {
        var rows = Enumerable.Range(0, 128).ToArray();

        var fb = l.Substring(0, 7);
        var lr = l.Substring(7);
        var row = -1;
        var set = -1;

        foreach (var i in fb)
        {
          if (i == 'F')
            rows = rows.Take(rows.Length / 2).ToArray();
          if (i == 'B')
            rows = rows[(rows.Length / 2)..];
        }

        var seats = Enumerable.Range(0, 8).ToArray();

        foreach (var i in lr)
        {
          if (i == 'L')
            seats = seats.Take(seats.Length / 2).ToArray();
          if (i == 'R')
            seats = seats[(seats.Length / 2)..];
        }

        ids.Add((rows[0] * 8) + seats[0]);
        //System.Console.WriteLine($"Row {rows[0]}, column {seats[0]}, seat ID {(rows[0] * 8) + seats[0]}");
      }

      System.Console.WriteLine($"Highest seat ID: {ids.Max()}");
    }

    public static void SolvePart2()
    {
      // var lines = new[] {
      //   "FBFBBFFRLR",
      //   "BFFFBBFRRR",
      //   "FFFBBBFRRR",
      //   "BBFFBBFRLL",
      // };
      var lines = new string[0];
      if (System.IO.File.Exists("Day05.txt"))
        lines = System.IO.File.ReadAllLines(@"Day05.txt");
      else
        lines = System.IO.File.ReadAllLines(@"bin\Debug\netcoreapp3.1\Day05.txt");

      var ids = new List<int>();

      foreach (var l in lines)
      {
        var rows = Enumerable.Range(0, 128).ToArray();

        var fb = l.Substring(0, 7);
        var lr = l.Substring(7);
        var row = -1;
        var set = -1;

        foreach (var i in fb)
        {
          if (i == 'F')
            rows = rows.Take(rows.Length / 2).ToArray();
          if (i == 'B')
            rows = rows[(rows.Length / 2)..];
        }

        var seats = Enumerable.Range(0, 8).ToArray();

        foreach (var i in lr)
        {
          if (i == 'L')
            seats = seats.Take(seats.Length / 2).ToArray();
          if (i == 'R')
            seats = seats[(seats.Length / 2)..];
        }

        ids.Add((rows[0] * 8) + seats[0]);
        //System.Console.WriteLine($"Row {rows[0]}, column {seats[0]}, seat ID {(rows[0] * 8) + seats[0]}");
      }

      ids.Sort();

      for (int i = 0; i < ids.Count; i++)
      {
        if (i + 1 >= ids.Count)
        {
          System.Console.WriteLine("Bad news; we reached the end and didn't find it.");
          break;
        }
        if (ids[i + 1] != ids[i] + 1)
        {
          System.Console.WriteLine($"How about {ids[i] + 1}...");
          break;
        }
      }
    }
  }
}
