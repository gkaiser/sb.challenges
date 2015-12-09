using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode
{
  internal static class Day02
  {
    internal static List<string> Input = new List<string>(System.IO.File.ReadLines("02.txt"));

    internal static void Process()
    {
      Console.WriteLine("Day 2");
      int totPaper = 0;
      int totRibbon = 0;

      for (int i = 0; i < Day02.Input.Count; i++)
      {
        var inpLine = Day02.Input[i];
        int len = int.Parse(inpLine.Split('x')[0]);
        int width = int.Parse(inpLine.Split('x')[1]);
        int height = int.Parse(inpLine.Split('x')[2]);

        var lst = new List<int> { len, width, height };
        var smallest = lst.FindAll(d => d < lst.Max());

        if (smallest.Count == 1)
          smallest.Add(lst.Max());
        else if (smallest.Count == 0)
        {
          smallest.Add(lst.Max());
          smallest.Add(lst.Max());
        }

        totPaper += (2 * len * width) + (2 * width * height) + (2 * height * len) + ((int)smallest[0] * (int)smallest[1]);
        totRibbon += (2 * smallest[0]) + (2 * smallest[1]) + (len * width * height);
      }

      Console.WriteLine("  The elves should order " + totPaper + " sqft of wrapping-paper, and " + totRibbon + " feet of ribbon...");
    }

  }
}
