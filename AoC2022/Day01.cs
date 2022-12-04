using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AoC2022
{
  internal class Day01
  {
    private static string[] TestInput = new[]
    {
      "1000",
      "2000",
      "3000",
      "",
      "4000",
      "",
      "5000",
      "6000",
      "",
      "7000",
      "8000",
      "9000",
      "",
      "10000",
    };

    internal static void SolvePart1()
    {
      //var inpLines = Day01.TestInput;
      var inpLines = File.ReadAllLines("Day01.txt");

      var lst = new List<List<int>> { new List<int>() };

      for (int i = 0; i < inpLines.Length; i++)
      {
        if (string.IsNullOrWhiteSpace(inpLines[i]))
        {
          lst.Add(new List<int>());
          continue;
        }

        lst.Last().Add(int.Parse(inpLines[i]));
      }

      var m = lst.Max(ll => ll.Sum());

      Console.WriteLine($"The elf carrying {m} calories is the max...");
    }

    internal static void SolvePart2()
    {
      //var inpLines = Day01.TestInput;
      var inpLines = File.ReadAllLines("Day01.txt");

      var lst = new List<List<int>> { new List<int>() };

      for (int i = 0; i < inpLines.Length; i++)
      {
        if (string.IsNullOrWhiteSpace(inpLines[i]))
        {
          lst.Add(new List<int>());
          continue;
        }

        lst.Last().Add(int.Parse(inpLines[i]));
      }

      // Compare L2 to L1 (instead of L1 to L2) to
      // sort the list in descending order.
      lst.Sort((l1, l2) => l2.Sum().CompareTo(l1.Sum()));

      var tot = 0;
      for (int i = 0; i < 3; i++)
        if (lst.Count > i)
          tot += lst[i].Sum();

      Console.WriteLine($"The top 3 elves are carrying a total of {tot} calories...");
    }

  }
}
