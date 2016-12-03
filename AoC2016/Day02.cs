using System;

namespace AoC2016
{
  internal static class Day02
  {
    private struct Point
    {
      public int X;
      public int Y;
    }

    internal static void Solve_Part1()
    {
      int[,] keyPad = new int[3, 3];
      Day02.InitKeypad_Part1(ref keyPad);

      var currPt = new Point() { X = 1, Y = 1 };
      var input = System.IO.File.ReadAllLines("02.txt");
      var code = "";

      // 1 | 2 | 3  0,0 | 0,1 | 0,2
      // ---------  ---------------
      // 4 | 5 | 6  1,0 | 1,1 | 1,2
      // ---------  ---------------
      // 7 | 8 | 9  2,0 | 2,1 | 2,2

      foreach (var l in input)
      {
        if (string.IsNullOrWhiteSpace(l))
          continue;

        foreach (var c in l)
        {
          if (c == 'U')
            currPt.Y = Math.Max(0, currPt.Y - 1);
          if (c == 'D')
            currPt.Y = Math.Min(2, currPt.Y + 1);
          if (c == 'L')
            currPt.X = Math.Max(0, currPt.X - 1);
          if (c == 'R')
            currPt.X = Math.Min(2, currPt.X + 1);
        }

        code += keyPad[currPt.Y, currPt.X];
      }

      // correct:
      //   52981

      Console.WriteLine($"The code seems to be {code}.");
    }

    internal static void Solve_Part2()
    {
      string[,] keyPad = new string[5, 5];
      Day02.InitKeypad_Part2(ref keyPad);

      var currPt = new Point() { X = 0, Y = 2 };
      var input = System.IO.File.ReadAllLines("02.txt"); //System.IO.File.ReadAllLines("02_Test.txt")
      var code = "";

      // * | * | 1 | * | *  0,0 | 0,1 | 0,2 | 0,3 | 0,4
      // -----------------  ---------------------------
      // * | 2 | 3 | 4 | *  1,0 | 1,1 | 1,2 | 1,3 | 1,4
      // -----------------  ---------------------------
      // 5 | 6 | 7 | 8 | 9  2,0 | 2,1 | 2,2 | 2,3 | 2,4
      // -----------------  ---------------------------
      // * | A | B | C | *  3,0 | 3,1 | 3,2 | 3,3 | 3,4
      // -----------------  ---------------------------
      // * | * | D | * | *  4,0 | 4,1 | 4,2 | 4,3 | 4,4

      foreach (var l in input)
      {
        if (string.IsNullOrWhiteSpace(l))
          continue;

        foreach (var c in l)
        {
          if (c == 'U')
          {
            var nextY = Math.Max(0, currPt.Y - 1);
            if (keyPad[nextY, currPt.X] == "")
              continue;
            else
              currPt.Y = nextY;
          }
          if (c == 'D')
          {
            var nextY = Math.Min(4, currPt.Y + 1);
            if (keyPad[nextY, currPt.X] == "")
              continue;
            else
              currPt.Y = nextY;
          }
          if (c == 'L')
          {
            var nextX = Math.Max(0, currPt.X - 1);
            if (keyPad[currPt.Y, nextX] == "")
              continue;
            else
              currPt.X = nextX;
          }
          if (c == 'R')
          {
            var nextX = Math.Min(4, currPt.X + 1);
            if (keyPad[currPt.Y, nextX] == "")
              continue;
            else
              currPt.X = nextX;
          }
        }

        code += keyPad[currPt.Y, currPt.X];
      }

      // correct:
      //   74CD2

      Console.WriteLine($"The code seems to be {code}.");
    }

    private static void InitKeypad_Part1(ref int[,] keyPad)
    {
      keyPad[0, 0] = 1;
      keyPad[0, 1] = 2;
      keyPad[0, 2] = 3;

      keyPad[1, 0] = 4;
      keyPad[1, 1] = 5;
      keyPad[1, 2] = 6;

      keyPad[2, 0] = 7;
      keyPad[2, 1] = 8;
      keyPad[2, 2] = 9;
    }

    private static void InitKeypad_Part2(ref string[,] keyPad)
    {
      keyPad[0, 0] = "";
      keyPad[0, 1] = "";
      keyPad[0, 2] = "1";
      keyPad[0, 3] = "";
      keyPad[0, 4] = "";

      keyPad[1, 0] = "";
      keyPad[1, 1] = "2";
      keyPad[1, 2] = "3";
      keyPad[1, 3] = "4";
      keyPad[1, 4] = "";

      keyPad[2, 0] = "5";
      keyPad[2, 1] = "6";
      keyPad[2, 2] = "7";
      keyPad[2, 3] = "8";
      keyPad[2, 4] = "9";

      keyPad[3, 0] = "";
      keyPad[3, 1] = "A";
      keyPad[3, 2] = "B";
      keyPad[3, 3] = "C";
      keyPad[3, 4] = "";

      keyPad[4, 0] = "";
      keyPad[4, 1] = "";
      keyPad[4, 2] = "D";
      keyPad[4, 3] = "";
      keyPad[4, 4] = "";
    }

  }
}
