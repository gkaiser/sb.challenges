using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AoC2022
{
  internal class Day01
  {
    internal static void SolvePart1()
    {
      var inpLines = File.ReadAllLines("Day01.txt");

      var lst = new List<List<int>>();

      for (int i = 0; i < inpLines.Length; i++)
      {
        if (i == 0 || string.IsNullOrWhiteSpace(inpLines[i]))
        {
          lst.Add(new List<int>());

          if (string.IsNullOrWhiteSpace(inpLines[i]))
            continue;
        }

        lst.Last().Add(int.Parse(inpLines[i]));
      }

      var m = lst.Max(ll => ll.Sum());

      Console.WriteLine($"The elf carrying {m} calories is the max...");
    }

    internal static void SolvePart2()
    {
      var inpLines = File.ReadAllLines("Day01.txt");

      var lst = new List<List<int>>();

      for (int i = 0; i < inpLines.Length; i++)
      {
        if (i == 0 || string.IsNullOrWhiteSpace(inpLines[i]))
        {
          lst.Add(new List<int>());

          if (string.IsNullOrWhiteSpace(inpLines[i]))
            continue;
        }

        lst.Last().Add(int.Parse(inpLines[i]));
      }

      lst.Sort((l1, l2) => l2.Sum().CompareTo(l1.Sum()));

      var tot = 0;
      for (int i = 0; i < 3; i++)
        if (lst.Count > i)
          tot += lst[i].Sum();

      Console.WriteLine($"The top 3 elves are carrying a total of {tot} calories...");
    }

  }
}
