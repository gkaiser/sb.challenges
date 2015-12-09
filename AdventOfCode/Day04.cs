using System;

namespace AdventOfCode
{
  internal static class Day04
  {
    internal static string Secret = System.IO.File.ReadAllText("04.txt");

    internal static void Process(bool runPart1)
    {
      Console.WriteLine("Day 4");

      for (int i = 1; ; i++)
      {
        var md5 = Util.GetMD5Hash(Day04.Secret + i);

        // Part 1 (5 0's)
        if (runPart1 && md5.StartsWith("00000"))
        {
          Console.WriteLine("  Santa used " + i + " to generate AdventCoin " + md5 + "...");
          break;
        }

        // Part 2 (6 0's)
        if (!runPart1 && md5.StartsWith("000000"))
        {
          Console.WriteLine("  Santa used " + i + " to generate AdventCoin " + md5 + "...");
          break;
        }
      }
    }

  }
}
