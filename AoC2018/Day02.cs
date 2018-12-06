using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2018
{
  internal static class Day02
  {
    internal static void SolvePart1()
    {
      var twoCt = 0;
      var threeCt = 0;

      foreach (var l in System.IO.File.ReadAllLines(@"Day02_P1.txt"))
      {
        if (string.IsNullOrWhiteSpace(l))
          continue;

        var cc = new Dictionary<char, int>();

        foreach (var c in l.Trim())
        {
          if (!cc.ContainsKey(c))
            cc.Add(c, 0);

          cc[c]++;
        }

        if (cc.Values.Any(v => v == 2))
          twoCt++;
        if (cc.Values.Any(v => v == 3))
          threeCt++;
      }

      Console.WriteLine($"The checksum for our list is {twoCt * threeCt}...");
    }

    internal static void SolvePart2()
    {
      var lines = System.IO.File.ReadAllLines(@"Day02_P1.txt");
      var defCc = Console.ForegroundColor;

      for (int i = 0; i < lines.Length; i++)
      {
        var id0 = lines[i].Trim();

        for (int j = 0; j < lines.Length; j++)
        {
          if (j == i)
            continue;

          var id1 = lines[j].Trim();
          var diffCt = 0;
          var dc = new char[3];

          for (int k = 0; k < id0.Length; k++)
          {
            if (id0[k] != id1[k])
            {
              diffCt++;

              dc[0] = id0[k];
              dc[1] = id1[k];
              dc[2] = (char)k;

              if (diffCt > 1)
                break;
            }
          }

          if (diffCt == 1)
          {
            Console.Write($"The ID's have ");
            for (int k = 0; k < id0.Length; k++)
            {
              Console.Write((k == (int)dc[2] ? ' ' : id0[k]));
            }
            Console.WriteLine(" in common...");

            Console.Write("              ");
            for (int k = 0; k < id0.Length; k++)
            {
              if (k == (int)dc[2])
                Console.ForegroundColor = ConsoleColor.Red;

              Console.Write(id0[k]);
              Console.ForegroundColor = defCc;
            }
            Console.WriteLine();

            Console.Write("              ");
            for (int k = 0; k < id0.Length; k++)
            {
              if (k == (int)dc[2])
                Console.ForegroundColor = ConsoleColor.Red;

              Console.Write(id1[k]);
              Console.ForegroundColor = defCc;
            }
            Console.WriteLine();

            return;
          }
        }
      }
    }

  }
}