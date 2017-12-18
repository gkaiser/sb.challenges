using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2017
{
  internal static class Day12
  {
    internal static void Solve_Part1()
    {
      //var input = new[]
      //{
      //  "0 <-> 2",
      //  "1 <-> 1",
      //  "2 <-> 0, 3, 4",
      //  "3 <-> 2, 4",
      //  "4 <-> 2, 3, 6",
      //  "5 <-> 6",
      //  "6 <-> 4, 5",
      //};
      var input = System.IO.File.ReadAllLines("Day12_Part1.txt");

      var pipes = new List<Pipe>();

      foreach (var l in input)
      {
        var end0 = int.Parse(l.Substring(0, l.IndexOf(' ')));
        var children = l.Split('>')[1].Split(',').Select(c => int.Parse(c.Trim())).ToList();

        foreach (var c in children)
        {
          if (pipes.Any(p => p.End0 == end0 && p.End1 == c))
            continue;
          if (pipes.Any(p => p.End0 == c && p.End1 == end0))
            continue;

          pipes.Add(new Pipe(end0, c));
        }
      }

      Day12.Nums = new List<int>();

      Day12.FindConnectionsTo(pipes.ToArray(), 0);

      Day12.Nums = Day12.Nums.Distinct().ToList();

      Console.WriteLine($"We've got {Day12.Nums.Count} programs that can talk to program 0...");
    }

    private static List<int> Nums;

    private static void FindConnectionsTo(Pipe[] pipes, int connectingTo)
    {
      if (!Day12.Nums.Contains(connectingTo))
        Day12.Nums.Add(connectingTo);

      var pMatch = pipes.Where(p => p.End0 == connectingTo || p.End1 == connectingTo).ToArray();

      for (int i = 0; i < pMatch.Length; i++)
      {
        var p = pMatch[i];
        if (!Day12.Nums.Contains(p.End0))
        {
          Day12.Nums.Add(p.End0);
          Day12.FindConnectionsTo(pipes, p.End0);
        }
        if (!Day12.Nums.Contains(p.End1))
        {
          Day12.Nums.Add(p.End1);
          Day12.FindConnectionsTo(pipes, p.End1);
        }
      }
    }

    private class Pipe
    {
      public int End0;
      public int End1;

      public Pipe(int end0, int end1)
      {
        this.End0 = end0;
        this.End1 = end1;
      }
    }

  }
}
