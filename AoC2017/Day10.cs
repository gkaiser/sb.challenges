using System;
using System.Linq;

namespace AoC2017
{
  internal static class Day10
  {
    internal static void Solve_Part1()
    {
      //var input = new[] { 3, 4, 1, 5 };
      //var elements = Enumerable.Range(0, 5).ToArray();

      var input = System.IO.File.ReadAllText("Day10_Part1.txt").Split(',').Select(v => int.Parse(v)).ToArray();
      var elements = Enumerable.Range(0, 256).ToArray();

      var currPos = 0;
      var skipSize = 0;

      foreach (var len in input)
      {
        var tmpPos = currPos;
        var subArr = new int[len];
        for (int i = 0; i < len; i++)
        {
          subArr[i] = elements[tmpPos];

          if (tmpPos + 1 < elements.Length)
            tmpPos++;
          else
            tmpPos = 0;
        }

        Array.Reverse(subArr);
        tmpPos = currPos;
        for (int i = 0; i < len; i++)
        {
          elements[tmpPos] = subArr[i];

          if (tmpPos + 1 < elements.Length)
            tmpPos++;
          else
            tmpPos = 0;
        }

        if (currPos + len + skipSize < elements.Length)
          currPos += len + skipSize;
        else
          currPos = currPos + len + skipSize - elements.Length;

        //Console.WriteLine(string.Join(", ", elements));

        skipSize++;
      }

      Console.WriteLine($"The checksum is {elements[0] * elements[1]}...");
    }

    internal static void Solve_Part2()
    {
      //var input = "1,2,3".Select(c => (int)c).ToList();
      var input = System.IO.File.ReadAllText("Day10_Part1.txt").Select(c => (int)c).ToList();
      input.AddRange(new[] { 17, 31, 73, 47, 23 });
      var elements = Enumerable.Range(0, 256).ToArray();

      var currPos = 0;
      var skipSize = 0;

      for (int r = 0; r < 64; r++)
      {
        foreach (var len in input)
        {
          var tmpPos = currPos;
          var subArr = new int[len];
          for (int i = 0; i < len; i++)
          {
            subArr[i] = elements[tmpPos];

            if (tmpPos + 1 < elements.Length)
              tmpPos++;
            else
              tmpPos = 0;
          }

          Array.Reverse(subArr);
          tmpPos = currPos;
          for (int i = 0; i < len; i++)
          {
            elements[tmpPos] = subArr[i];

            if (tmpPos + 1 < elements.Length)
              tmpPos++;
            else
              tmpPos = 0;
          }

          if (currPos + len + skipSize < elements.Length)
            currPos += len + skipSize;
          else
          {
            currPos += len + skipSize;

            do { currPos = currPos - elements.Length; }
            while (currPos >= elements.Length);
          }

          skipSize++;
        }
      }

      var denseHash = new int[16];
      for (int i = 0; i < 16; i++)
      {
        var block = elements.Skip(i * 16).Take(16).ToArray();
        var xord = 0;

        foreach (var b in block)
          xord ^= b;

        denseHash[i] = xord;
      }

      var hashStr = "";
      foreach (var b in denseHash)
      {
        hashStr += b.ToString("x2");
      }

      Console.WriteLine($"I really hope the hash is {hashStr}...");
    }

  }
}
