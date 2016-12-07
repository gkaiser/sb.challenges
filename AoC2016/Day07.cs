using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2016
{
  internal static class Day07
  {
    internal static void Solve_Part1()
    {
      Console.WriteLine("Solving Day 07, Part 1...");

      //var input = new[]
      //{
      //  "abba[mnop]qrst",
      //  "abcd[bddb]xyyx",
      //  "aaaa[qwer]tyui",
      //  "ioxxoj[asdfgh]zxcvbn",
      //};
      var input = System.IO.File.ReadAllLines("07.txt");
      var goodCt = 0;

      foreach (var addr in input)
      {
        if (string.IsNullOrWhiteSpace(addr))
          continue;

        var seq = "";
        var hasValidSnet = false;
        var hasInvalidHypernet = false;

        for (int i = 0; i < addr.Length; i++)
        {
          seq += addr[i];

          if (seq.EndsWith("[") || i == (addr.Length - 1))
          {
            // validate normal seq
            seq = seq.TrimEnd('[');

            if (Day07.HasAbba(seq))
              hasValidSnet = true;

            seq = "";
          }
          else if (seq.EndsWith("]"))
          {
            // validate hypernet
            seq = seq.TrimEnd(']');

            if (Day07.HasAbba(seq))
              hasInvalidHypernet = true;

            seq = "";
          }
        }

        if (hasValidSnet && !hasInvalidHypernet)
          goodCt++;
      }

      // wrong:
      //   82 (too low)
      //   84 (too low)
      //   116 (too high)
      //   117 (too high)
      // correct:
      //   115

      Console.WriteLine($"Looks like there were {goodCt} addresses that supported TLS...");
    }

    internal static void Solve_Part2()
    {
      Console.WriteLine("Solving Day 07, Part 2...");
      //var input = new[]
      //{
      //  "aba[bab]xyz",
      //  "xyx[xyx]xyx",
      //  "aaa[kek]eke",
      //  "zazbz[bzb]cdb",
      //};
      var input = System.IO.File.ReadAllLines("07.txt");
      var supportsSsl = 0;

      foreach (var addr in input)
      {
        if (string.IsNullOrWhiteSpace(addr))
          continue;

        var lstSupernets = new List<string>();
        var lstHypernets = new List<string>();
        var seq = "";

        for (int i = 0; i < addr.Length; i++)
        {
          seq += addr[i];

          if (seq.EndsWith("[") || i == addr.Length - 1)
          {
            lstSupernets.Add(seq.TrimEnd('['));
            seq = "";
          }
          else if (seq.EndsWith("]"))
          {
            lstHypernets.Add(seq.TrimEnd(']'));
            seq = "";
          }
        }

        foreach (var super in lstSupernets)
        {
          for (int i = 0; i <= super.Length - 3; i++)
          {
            var aba = super.Substring(i, 3);
            if (aba[0] != aba[2] || aba[0] == aba[1])
              continue;

            var bab = aba[1].ToString() + aba[0].ToString() + aba[1].ToString();
            if (lstHypernets.Any(h => h.IndexOf(bab) > -1))
            {
              supportsSsl++;
              break;
            }
          }
        }
      }

      // wrong:
      //   2 (too low) HAHAHAHA! USED TEST INPUT, _AND_ GOT IT WRONG. GOD, IM DUMB.
      //   233 (too high)
      //   13 (too low)
      // correct:
      //   231

      Console.WriteLine($"Looks like there were {supportsSsl} addresses that supported SSL...");
    }

    private static bool HasAbba(string input)
    {
      if (input.Length < 4)
        return false;

      for (int i = 0; i <= input.Length - 4; i++)
      {
        // 0 | 1 | 2 | 3
        // a | b | b | a
        if (input[i] == input[i + 3] && input[i + 1] == input[i + 2] && input[i] != input[i + 1])
          return true;
      }

      return false;
    }

  }
}
