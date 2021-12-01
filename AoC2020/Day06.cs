using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2020
{
  public static class Day06
  {
    public static void SolvePart1()
    {
      // var lines = new[] { 
      //   "abc", 
      //   "", 
      //   "a", 
      //   "b", 
      //   "c", 
      //   "", 
      //   "ab", 
      //   "ac", 
      //   "", 
      //   "a", 
      //   "a", 
      //   "a", 
      //   "a", 
      //   "", 
      //   "b", 
      // };
      var lines = new string[0];
      if (System.IO.File.Exists("Day06.txt"))
        lines = System.IO.File.ReadAllLines(@"Day06.txt");
      else
        lines = System.IO.File.ReadAllLines(@"bin\Debug\netcoreapp3.1\Day06.txt");

      var ct = 0;

      for (int i = 0; i < lines.Length; i++)
      {
        var l = lines[i];

        while (i + 1 < lines.Length && !string.IsNullOrWhiteSpace(lines[i + 1]))
        {
          i++;
          l += lines[i];
        }

        var a = "";
        foreach (var c in l)
          if (a.IndexOf(c) == -1)
            a += c;

        ct += a.Length;
      }

      System.Console.WriteLine($"{ct}");
    }

    public static void SolvePart2()
    {
      // var lines = new[] { 
      //   "abc", 
      //   "", 
      //   "a", 
      //   "b", 
      //   "c", 
      //   "", 
      //   "ab", 
      //   "ac", 
      //   "", 
      //   "a", 
      //   "a", 
      //   "a", 
      //   "a", 
      //   "", 
      //   "b", 
      // };
      var lines = new string[0];
      if (System.IO.File.Exists("Day06.txt"))
        lines = System.IO.File.ReadAllLines(@"Day06.txt");
      else
        lines = System.IO.File.ReadAllLines(@"bin\Debug\netcoreapp3.1\Day06.txt");

      var ct = 0;

      for (int i = 0; i < lines.Length; i++)
      {
        if (string.IsNullOrWhiteSpace(lines[i]))
          continue;

        var l = lines[i];
        var gc = 1;

        while (i + 1 < lines.Length && !string.IsNullOrWhiteSpace(lines[i + 1]))
        {
          i++;
          gc++;
          l += lines[i];
        }

        var dict = new Dictionary<char, int>();
        foreach (var c in l)
        {
          if (!dict.ContainsKey(c))
            dict.Add(c, 0);

          dict[c]++;
        }

        var ga = 0;
        foreach (var k in dict.Keys)
          ga += (dict[k] == gc ? 1 : 0);

        ct += ga;
      }

      System.Console.WriteLine($"{ct}");
    }

  }
}