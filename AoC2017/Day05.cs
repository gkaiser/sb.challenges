using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2017
{
  internal static class Day05
  {
    internal static void Solve_Part1()
    {
      // 356945

      //var input = new[] { 0, 3, 0, 1, -3 };
      var lines = System.IO.File.ReadAllLines("Day05_Part1.txt");
      var input = new int[lines.Length];
      for (int i = 0; i < lines.Length; i++)
        input[i] = int.Parse(lines[i]);

      var posn = 0;
      var moves = 0;

      while (true)
      {
        moves++;

        var instruct = input[posn];
        input[posn] = instruct + 1;

        posn += instruct;

        if (posn >= input.Length)
          break;
      }

      input.ToList().ForEach(i => Console.Write(i + " "));
      Console.WriteLine();

      Console.WriteLine($"Looks like it took {moves} moves to break out...");
    }

    internal static void Solve_Part2()
    {
      //var input = new[] { 0, 3, 0, 1, -3 };

      var lines = System.IO.File.ReadAllLines("Day05_Part1.txt");
      var input = new int[lines.Length];
      for (int i = 0; i < lines.Length; i++)
        input[i] = int.Parse(lines[i]);

      var posn = 0;
      var moves = 0;

      while (true)
      {
        moves++;

        var instruct = input[posn];
        input[posn] = instruct + (instruct >= 3 ? -1 : 1);

        posn += instruct;

        if (posn >= input.Length)
          break;
      }

      input.ToList().ForEach(i => Console.Write(i + " "));
      Console.WriteLine();

      Console.WriteLine($"Looks like it took {moves} moves to break out...");
    }

  }
}
