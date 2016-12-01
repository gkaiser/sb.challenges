using System;

namespace AdventOfCode
{
  internal static class Day01
  {
    private static string Input = System.IO.File.ReadAllText("01.txt");

    internal static void Process()
    {
      Console.WriteLine("Day 1");

      var openCt = Day01.Input.Replace(")", "").Length;
      var closeCt = Day01.Input.Replace("(", "").Length;

      Console.WriteLine("  Floor " + (openCt - closeCt));

      var currFloor = 0;
      for (int i = 0; i < Day01.Input.Length; i++)
      {
        currFloor += (Day01.Input[i] == '(' ? 1 : -1);

        if (currFloor == -1)
        {
          Console.WriteLine("  Character " + (i + 1) + " put Santa in the basement.");
          break;
        }
      }
    }

  }
}
