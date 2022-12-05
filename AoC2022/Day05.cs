using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2022
{
  internal class Day05
  {
    private static string[] TestInput = new[]
    {
      "    [D]    ",
      "[N] [C]    ",
      "[Z] [M] [P]",
      " 1   2   3 ",
      "",
      "move 1 from 2 to 1",
      "move 3 from 1 to 3",
      "move 2 from 2 to 1",
      "move 1 from 1 to 2",
    };

    internal static void SolvePart1()
    {
      //var inp = Day05.TestInput;
      var inp = System.IO.File.ReadAllLines("Day05.txt");

      var stackCt = 0;
      var stackCtIdx = 0;

      for (int i = 0; i < inp.Length; i++)
      {
        if (!inp[i].StartsWith(" 1 "))
          continue;

        stackCt = inp[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        stackCtIdx = i;

        break;
      }

      var stacks = new List<string>();
      for (int i = 0; i < stackCt; i++)
        stacks.Add("");

      for (int i = stackCtIdx - 1; i >= 0; i--)
      {
        for (int j = 0; j < stackCt; j++)
        {
          stacks[j] += inp[i].Substring(j * 4, 3).TrimStart('[').TrimEnd(']').Trim();
        }
      }

      for (int i = stackCtIdx + 2; i < inp.Length; i++)
      {
        var inst = inp[i].Split(' ');
        var ct = int.Parse(inst[1]);
        var src = int.Parse(inst[3]);
        var dest = int.Parse(inst[5]);

        var rem = new string(stacks[src - 1].Substring(stacks[src - 1].Length - ct).ToCharArray().Reverse().ToArray());

        stacks[src - 1] = stacks[src - 1].Substring(0, stacks[src - 1].Length - ct);
        stacks[dest - 1] += rem;
      }

      var top = "";
      foreach (var s in stacks)
        top += s.Last();

      // RLFNRTNFB
      Console.WriteLine($"{top}");
    }

    internal static void SolvePart2()
    {
      //var inp = Day05.TestInput;
      var inp = System.IO.File.ReadAllLines("Day05.txt");

      var stackCt = 0;
      var stackCtIdx = 0;

      for (int i = 0; i < inp.Length; i++)
      {
        if (!inp[i].StartsWith(" 1 "))
          continue;

        stackCt = inp[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        stackCtIdx = i;

        break;
      }

      var stacks = new List<string>();
      for (int i = 0; i < stackCt; i++)
        stacks.Add("");

      for (int i = stackCtIdx - 1; i >= 0; i--)
      {
        for (int j = 0; j < stackCt; j++)
        {
          stacks[j] += inp[i].Substring(j * 4, 3).TrimStart('[').TrimEnd(']').Trim();
        }
      }

      for (int i = stackCtIdx + 2; i < inp.Length; i++)
      {
        var inst = inp[i].Split(' ');
        var ct = int.Parse(inst[1]);
        var src = int.Parse(inst[3]);
        var dest = int.Parse(inst[5]);

        var rem = stacks[src - 1].Substring(stacks[src - 1].Length - ct);

        stacks[src - 1] = stacks[src - 1].Substring(0, stacks[src - 1].Length - ct);
        stacks[dest - 1] += rem;
      }

      var top = "";
      foreach (var s in stacks)
        top += s.Last();

      // MHQTLJRLB
      Console.WriteLine($"{top}");
    }

  }

}