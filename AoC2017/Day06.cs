using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2017
{
  internal static class Day06
  {
    internal static void Solve_Part1()
    {
      var input = new int[] { 0, 2, 7, 0 };
      //var textLine = System.IO.File.ReadAllText("Day06_Part1.txt"); // 11137
      //var textArr = textLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      //var input = new int[textArr.Length];
      //for (int i = 0; i < input.Length; i++)
      //  input[i] = int.Parse(textArr[i]);

      var cycleCt = 0;
      var prevStates = new List<string>();

      while (true)
      {
        var max = input.Max();
        var maxPosn = Array.FindIndex(input, val => val == max);
        input[maxPosn] = 0;

        for (int i = (maxPosn + 1 < input.Length ? maxPosn + 1 : 0);;)
        {
          input[i] += 1;

          i = (i + 1 < input.Length ? i + 1 : 0);
          max--;

          if (max == 0)
            break;
        }

        cycleCt++;

        var newArr = new int[input.Length];
        input.CopyTo(newArr, 0);

        var arrStr = string.Join("|", newArr);

        if (prevStates.Contains(arrStr))
            break;

        prevStates.Add(arrStr);
      }

      Console.WriteLine($"Looks like it took {cycleCt} cycles to find a duplicate...");
    }

    internal static void Solve_Part2()
    {
      var input = new int[] { 0, 2, 7, 0 };
      //var textLine = System.IO.File.ReadAllText("Day06_Part1.txt"); // 1037
      //var textArr = textLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      //var input = new int[textArr.Length];
      //for (int i = 0; i < input.Length; i++)
      //  input[i] = int.Parse(textArr[i]);

      var cycleCt = 0;
      var prevStates = new List<string>();

      while (true)
      {
        var max = input.Max();
        var maxPosn = Array.FindIndex(input, val => val == max);
        input[maxPosn] = 0;

        for (int i = (maxPosn + 1 < input.Length ? maxPosn + 1 : 0); ;)
        {
          input[i] += 1;

          i = (i + 1 < input.Length ? i + 1 : 0);
          max--;

          if (max == 0)
            break;
        }

        cycleCt++;

        var newArr = new int[input.Length];
        input.CopyTo(newArr, 0);

        var arrStr = string.Join("|", newArr);

        if (prevStates.Contains(arrStr))
        {
          Console.WriteLine($"Looks like it took {cycleCt - prevStates.IndexOf(arrStr) - 1} cycles to find a duplicate...");
          break;
        }

        prevStates.Add(arrStr);
      }
    }

  }
}
