using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2018
{
  internal static class Day02
  {
    internal static void SolvePart1()
    {
      var lines = System.IO.File.ReadAllLines(@"M:\Documents\VS Projects\Challenges\AoC2018\InputData\Day02_P1.txt");

      var twoCt = 0;
      var threeCt = 0;

      foreach (var l in lines)
      {
        if (string.IsNullOrWhiteSpace(l))
          continue;

        var bid = new BoxId(l.Trim());

        if (bid.HasTwoRepeatingLetters)
          twoCt++;
        if (bid.HasThreeRepeatingLetters)
          threeCt++;
      }

      Console.WriteLine($"The checksum for our list is {twoCt * threeCt}...");
    }

    internal static void SolvePart2()
    {
      var lines = System.IO.File.ReadAllLines(@"M:\Documents\VS Projects\Challenges\AoC2018\InputData\Day02_P1.txt");
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

    internal class BoxId
    {
      internal string Id;
      private Dictionary<char, int> CharCounts;

      internal BoxId(string id)
      {
        this.Id = id;
        this.CharCounts = new Dictionary<char, int>();

        foreach (var c in this.Id)
        {
          if (!this.CharCounts.ContainsKey(c))
            this.CharCounts.Add(c, 0);

          this.CharCounts[c]++;
        }
      }

      internal bool HasTwoRepeatingLetters => this.CharCounts.Values.Any(v => v == 2);

      internal bool HasThreeRepeatingLetters => this.CharCounts.Values.Any(v => v == 3);

    }

  }
}