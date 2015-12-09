using System;
using System.Collections.Generic;

namespace AdventOfCode
{
  internal static class Day03
  {
    internal static string Input = System.IO.File.ReadAllText("03.txt");

    internal static void Process()
    {
      Console.WriteLine("Day 3");

      var lstHistory = new List<string>() { "0,0" };
      var x = 0;
      var y = 0;

      foreach (char c in Day03.Input)
      {
        switch (c)
        {
          case '^':
            y += 1;
            break;
          case '>':
            x += 1;
            break;
          case 'V':
          case 'v':
            y -= 1;
            break;
          case '<':
            x -= 1;
            break;
        }

        var pt = x + "," + y;
        if (!lstHistory.Contains(pt))
          lstHistory.Add(pt);
      }

      Console.WriteLine("  Santa stopped at " + lstHistory.Count + " houses...");
      // correct: 2592

      lstHistory = new List<string>() { "0,0" };
      x = 0;
      y = 0;
      var rx = 0;
      var ry = 0;

      for (int i = 0; i < Day03.Input.Length; i++)
      {
        var c = Day03.Input[i];
        switch (c)
        {
          case '^':
            if (i % 2 == 0)
              y += 1;
            else
              ry += 1;
            break;
          case '>':
            if (i % 2 == 0)
              x += 1;
            else
              rx += 1;
            break;
          case 'V':
          case 'v':
            if (i % 2 == 0)
              y -= 1;
            else
              ry -= 1;
            break;
          case '<':
            if (i % 2 == 0)
              x -= 1;
            else
              rx -= 1;
            break;
        }

        var pt = (i % 2 == 0 ? x + "," + y : rx + "," + ry);
        if (!lstHistory.Contains(pt))
          lstHistory.Add(pt);
      }

      Console.WriteLine("  Santa, and Robo-Santa, stopped at a total of " + lstHistory.Count + " houses...");

      // wrong: 
      //   2499 high
      //   2498 high
      // correct: 
      //   2360 wasn't resetting Santa's X and Y positions
    }

  }
}
