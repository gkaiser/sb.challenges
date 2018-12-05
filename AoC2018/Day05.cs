using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2018
{
  internal static class Day05
  {
    internal static void SolvePart1()
    {
      var input = System.IO.File.ReadAllText("Day05_P1.txt");
      var reacted = Day05.React(input);

      while (Day05.CanReact(reacted))
        reacted = Day05.React(reacted);

      Console.WriteLine($"{reacted.Length} units remain after fully reacting the input...");
    }

    internal static void SolvePart2()
    {
      var input = System.IO.File.ReadAllText("Day05_P1.txt");
      var units = new List<char>(input.ToUpper().Distinct());
      var minCt = int.MaxValue;
      var minUnit = "";
      
      for (int i = 0; i < units.Count; i++)
      {
        var u = units[i].ToString();
        var reacted = Day05.React(input.Replace(u, "").Replace(u.ToLower(), ""));

        while (Day05.CanReact(reacted))
          reacted = Day05.React(reacted);

        if (reacted.Length < minCt)
        {
          minCt = reacted.Length;
          minUnit = u;
        }
      }
      
      // 6968 BINGO

      Console.WriteLine($"Removing unit {minUnit} seems best, we can get down to a polymer length of {minCt}...");
    }

    private static bool CanReact(string s)
    {
      for (int i = 0; i < s.Length; i++)
      {
        if (i + 1 < s.Length && s[i] != s[i + 1] && char.ToUpper(s[i]) == char.ToUpper(s[i + 1]))
          return true;
      }

      return false;
    }

    private static string React(string s)
    {
      var sb = new System.Text.StringBuilder();

      for (int i = 0; i < s.Length; i++)
      {
        if (i + 1 < s.Length && s[i] != s[i + 1] && char.ToUpper(s[i]) == char.ToUpper(s[i + 1]))
          i++;
        else
          sb.Append(s[i]);
      }

      return sb.ToString();
    }

  }

}