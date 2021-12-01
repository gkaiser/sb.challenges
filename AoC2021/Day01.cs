using System;

namespace AoC2021
{
  internal static class Day01
  {
    internal static void SolvePart1()
    {
      //var lines = new[] { "199", "200", "208", "210", "200", "207", "240", "269", "260", "263" };
      var lines = System.IO.File.ReadAllLines("Day01.txt");
      var gtCt = 0;

      for (int i = 1; i < lines.Length; i++)
      {
        if (string.IsNullOrWhiteSpace(lines[i]))
          continue;
        if (int.Parse(lines[i]) > int.Parse(lines[i - 1]))
          gtCt++;
      }

      Console.WriteLine($"The depth indicator increased {gtCt} times...");
    }

    internal static void SolvePart2()
    {
      //var lines = new[] { "199", "200", "208", "210", "200", "207", "240", "269", "260", "263" };
      var lines = System.IO.File.ReadAllLines("Day01.txt");
      var lastWin = 0;
      var gtCt = 0;

      for (int i = 0; i < lines.Length - 2; i++)
      {
        if (string.IsNullOrWhiteSpace(lines[i]))
          continue;
        
        if (i == 0)
        {
          lastWin = int.Parse(lines[i + 0]) + int.Parse(lines[i + 1]) + int.Parse(lines[i + 2]);
          continue;
        }
        
        if (int.Parse(lines[i + 0]) + int.Parse(lines[i + 1]) + int.Parse(lines[i + 2]) > lastWin)
          gtCt++;

        lastWin = int.Parse(lines[i + 0]) + int.Parse(lines[i + 1]) + int.Parse(lines[i + 2]);
      }

      Console.WriteLine($"The depth indicator increased {gtCt} times...");
    }
  }
}
