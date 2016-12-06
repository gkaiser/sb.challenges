using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2016
{
  internal static class Day06
  {
    internal static void Solve_Part1()
    {
      Console.WriteLine("Solving Day 06, Part 1...");
      var input = System.IO.File.ReadAllLines("06.txt");
      //var input = new[]
      //{
      //  "eedadn", "drvtee", "eandsr", "raavrd",
      //  "atevrs", "tsrnev", "sdttsa", "rasrtv",
      //  "nssdts", "ntnada", "svetve", "tesnvt",
      //  "vntsnd", "vrdear", "dvrsen", "enarar",
      //};

      var message = "";
      for (int i = 0; i < input[0].Length; i++)
      {
        var dict = new Dictionary<string, int>();
        for (int j = 0; j < input.Length; j++)
        {
          var lett = input[j][i].ToString();

          if (!dict.ContainsKey(lett))
            dict.Add(lett, 0);

          dict[lett]++;
        }

        var max = dict.Values.Max();
        foreach (var key in dict.Keys)
        {
          if (dict[key] == max)
          {
            message += key;
            break;
          }
        }
      }

      Console.WriteLine($"It appears the message is \"{message}\", sir.");
    }

    internal static void Solve_Part2()
    {
      Console.WriteLine("Solving Day 06, Part 1...");
      var input = System.IO.File.ReadAllLines("06.txt");
      //var input = new[]
      //{
      //  "eedadn", "drvtee", "eandsr", "raavrd",
      //  "atevrs", "tsrnev", "sdttsa", "rasrtv",
      //  "nssdts", "ntnada", "svetve", "tesnvt",
      //  "vntsnd", "vrdear", "dvrsen", "enarar",
      //};

      var message = "";
      for (int i = 0; i < input[0].Length; i++)
      {
        var dict = new Dictionary<string, int>();
        for (int j = 0; j < input.Length; j++)
        {
          var lett = input[j][i].ToString();

          if (!dict.ContainsKey(lett))
            dict.Add(lett, 0);

          dict[lett]++;
        }

        var max = dict.Values.Min();
        foreach (var key in dict.Keys)
        {
          if (dict[key] == max)
          {
            message += key;
            break;
          }
        }
      }

      Console.WriteLine($"It appears the message is \"{message}\", sir.");
    }

  }
}
