using System;
using System.Linq;

namespace AoC2019
{
  internal class Day02
  {
    internal static void SolvePart1()
    {
      var prog = System.IO.File.ReadAllText(@"Day02_P1.txt").Split(',').Select(v => int.Parse(v)).ToArray();
      prog[1] = 12;
      prog[2] = 02;

      for (int i = 0; i < prog.Length; i += 4)
      {
        if (prog[i] == 99)
          break;

        prog[prog[i + 3]] = (prog[i + 0] == 1 ? prog[prog[i + 1]] + prog[prog[i + 2]] : prog[prog[i + 1]] * prog[prog[i + 2]]);
      }

      Console.WriteLine($"Final state: {string.Join(",", prog)}");
    }

    internal static void SolvePart2()
    {
      var orig = System.IO.File.ReadAllText(@"Day02_P1.txt").Split(',').Select(v => int.Parse(v)).ToArray();

      for (int j = 0; j < 100; j++)
      {
        for (int k = 0; k < 100; k++)
        {
          var pt = new int[orig.Length];

          Array.Copy(orig, 0, pt, 0, orig.Length);

          pt[1] = j;
          pt[2] = k;

          for (int i = 0; i < pt.Length; i += 4)
          {
            if (pt[i] == 99)
              break;

            pt[pt[i + 3]] = (pt[i + 0] == 1 ? pt[pt[i + 1]] + pt[pt[i + 2]] : pt[pt[i + 1]] * pt[pt[i + 2]]);
          }

          if (pt[0] == 19690720)
          {
            Console.WriteLine($"Input {j} and {k} produce 19690720, answer should be {100 * j + k}");
            // 1969071901 - HIGH (used last v1 and v1 instead of j and k)
            // 4925       - CORRECT 
            goto endMe;
          }
        }
      }

      endMe:
      return;
    }

  }
}

