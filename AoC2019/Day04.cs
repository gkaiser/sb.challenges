using System;
using System.Linq;

namespace AoC2019
{
  internal class Day04
  {
    internal static void SolvePart1()
    {
      var inp = "231832-767346";
      var low = int.Parse(inp.Split('-')[0]);
      var hig = int.Parse(inp.Split('-')[1]);
      var pct = 0;

      for (int i = low; i <= hig; i++)
      {
        pct += (Day04.IsValidPassword_P1(i) ? 1 : 0);
      }

      Console.WriteLine($"There are {pct} valid passwords in the range...");
    }

    internal static void SolvePart2()
    {
      var inp = "231832-767346";
      var low = int.Parse(inp.Split('-')[0]);
      var hig = int.Parse(inp.Split('-')[1]);
      var pct = 0;

      for (int i = low; i <= hig; i++)
      {
        pct += (Day04.IsValidPassword_P2(i) ? 1 : 0);
      }

      Console.WriteLine($"There are {pct} valid passwords in the range...");
    }

    internal static bool IsValidPassword_P1(int pwd)
    {
      var str = $"{pwd}";

      // must have 2 adjacent duplicate digits
      // must never have decreasing digits

      var hasAdj = false;
      var allDescend = true;

      for (int i = 0; i < str.Length; i++)
      {
        if (!hasAdj && i + 1 < str.Length && str[i] == str[i + 1])
          hasAdj = true;
        if (allDescend && i + 1 < str.Length && int.Parse($"{str[i]}") < int.Parse($"{str[i + 1]}"))
          allDescend = false;

        if (!allDescend)
          break;
      }

      return hasAdj && allDescend;
    }

    internal static bool IsValidPassword_P2(int pwd)
    {
      var str = $"{pwd}";

      // must have 2 adjacent duplicate digits
      // must never have decreasing digits

      for (int i = 0; i < str.Length; i++)
      {
        if (i + 1 == str.Length)
          break;
        if (int.Parse($"{str[i + 1]}") < int.Parse($"{str[i]}"))
          return false;
      }

      var digits = $"{pwd}".Select(pd => int.Parse($"{pd}")).ToArray();

      int j = 0;
      while (j < digits.Length)
      {
        var next = digits[j++];
        int ct = 1;

        while (j < digits.Length && digits[j] == next)
        {
          ct++;
          j++;
        }

        if (ct == 2)
          return true;
      }

      return false;

      //var hasAdj = false;
      //for (int i = 0; i < str.Length; i++)
      //{
      //  var t = $"{str[i]}";
      //  var j = 1;
      //  while (i + j < str.Length && str[i + j] == str[i])
      //  {
      //    t += str[i + j];
      //    j++;
      //  }

      //  if (t.Length == 2)
      //  {
      //    hasAdj = true;
      //    i += t.Length;
      //  }
      //}

      // 901 - HIGH
      // 594 - LOW
      // 849 - LOW
      // 876 - CORRECT

      //return hasAdj;
    }

  }
}