using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2017
{
  internal static class Day12
  {
    internal static void Solve_Part1()
    {
      var input = new[]
      {
        "0 <-> 2",
        "1 <-> 1",
        "2 <-> 0, 3, 4",
        "3 <-> 2, 4",
        "4 <-> 2, 3, 6",
        "5 <-> 6",
        "6 <-> 4, 5",
      };
      //input = System.IO.File.ReadAllLines("Day12_Part1.txt");

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

      var nums = new List<int>();
      foreach (var p in pipes.Where(p => p.End0 == 0 || p.End1 == 0))
      {
        if (!nums.Contains(p.End0))
          nums.Add(p.End0);
        if (!nums.Contains(p.End1))
          nums.Add(p.End1);

        foreach (var n in nums)
        {
          
        }
      }

      Console.WriteLine($"We've got {pipes.Count} pipes to check from {input.Length} lines of input...");
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
