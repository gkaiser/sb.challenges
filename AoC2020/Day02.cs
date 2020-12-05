using System;
using System.Linq;

namespace AoC2020
{
  public static class Day02
  {
    public static void SolvePart1()
    {
      // var lines = new[] {
      //   "1-3 a: abcde", 
      //   "1-3 b: cdefg", 
      //   "2-9 c: ccccccccc", 
      // };
      var lines = new string[0];
      if (System.IO.File.Exists("Day02.txt"))
        lines = System.IO.File.ReadAllLines(@"Day02.txt");
      else
        lines = System.IO.File.ReadAllLines(@"bin\Debug\netcoreapp3.1\Day02.txt");

      var val = 0;

      foreach (var l in lines)
      {
        var vals = l.Split(' ');
        var min = int.Parse(vals[0].Split('-')[0]);
        var max = int.Parse(vals[0].Split('-')[1]);
        var pc = vals[1][0];
        var pwd = vals[2];

        if (!pwd.Contains(pc))
          continue;
        
        var dict = new System.Collections.Generic.Dictionary<char, int>();
        foreach (var c in pwd)
        {
          if (!dict.ContainsKey(c))
            dict.Add(c, 0);

          dict[c]++;
        }

        if (dict.ContainsKey(pc) && dict[pc] >= min && dict[pc] <= max)
          val++;
      }

      Console.WriteLine($"There are {val} valid passwords...");
    }

    public static void SolvePart2()
    {
      // var lines = new[] {
      //   "1-3 a: abcde", 
      //   "1-3 b: cdefg", 
      //   "2-9 c: ccccccccc", 
      // };
      var lines = new string[0];
      if (System.IO.File.Exists("Day02.txt"))
        lines = System.IO.File.ReadAllLines(@"Day02.txt");
      else
        lines = System.IO.File.ReadAllLines(@"bin\Debug\netcoreapp3.1\Day02.txt");

      var val = 0;

      foreach (var l in lines)
      {
        var vals = l.Split(' ');
        var idx1 = int.Parse(vals[0].Split('-')[0]) - 1;
        var idx2 = int.Parse(vals[0].Split('-')[1]) - 1;
        var pc = vals[1][0];
        var pwd = vals[2];

        if (!pwd.Contains(pc))
          continue;

        if ((pwd[idx1] == pc && pwd[idx2] != pc) || (pwd[idx1] != pc && pwd[idx2] == pc))
          val++;
      }

      Console.WriteLine($"There are {val} valid passwords...");
    }
    
  }
}
