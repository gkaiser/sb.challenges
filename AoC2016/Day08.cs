using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2016
{
  internal static class Day08
  {
    internal static void Solve_Part1()
    {
      Console.WriteLine("Solving Day 08, Parts 1 & 2...");

      //var input = new[]
      //{
      //  "rect 3x2",
      //  "rotate column x=1 by 1",
      //  "rotate row y=0 by 4",
      //  "rotate column x=1 by 1",
      //};
      var input = System.IO.File.ReadAllLines("08.txt");

      // 6 rows, 50 columns
      var dispHeight = 6;
      var dispWidth = 50;
      var disp = new int[dispHeight, dispWidth];

      foreach (var instruct in input)
      {
        var instParts = instruct.Split(' ');
        var mode = instParts[0];
        if (mode == "rect")
        {
          var width = int.Parse(instParts[1].Split('x')[0]);
          var height = int.Parse(instParts[1].Split('x')[1]);

          for (int i = 0; i < height; i++)
          {
            for (int j = 0; j < width; j++)
            {
              disp[i, j] = 1;
            }
          }
        }
        else if (mode == "rotate")
        {
          var rotMode = instParts[1];
          var rotIdx = int.Parse(instParts[2].Split('=')[1]);
          var rotCt = int.Parse(instParts[4]);
          var newVals = new int[(rotMode == "column" ? dispHeight : dispWidth)];

          if (rotMode == "column")
          {
            for (int r = 0; r < rotCt; r++)
            {
              for (int i = 0; i < dispHeight; i++)
              {
                var aboveValue = disp[(i == 0 ? dispHeight - 1 : i - 1), rotIdx];
                newVals[i] = aboveValue;
              }

              for (int i = 0; i < newVals.Length; i++)
              {
                disp[i, rotIdx] = newVals[i];
              }
            }
          }
          else
          {
            for (int r = 0; r < rotCt; r++)
            {
              for (int i = 0; i < dispWidth; i++)
              {
                var leftVal = disp[rotIdx, (i == 0 ? dispWidth - 1 : i - 1)];
                newVals[i] = leftVal;
              }

              for (int i = 0; i < newVals.Length; i++)
              {
                disp[rotIdx, i] = newVals[i];
              }
            }

          }
        }
      }

      var litCt = 0;
      for (int i = 0; i < dispHeight; i++)
      {
        for (int j = 0; j < dispWidth; j++)
        {
          if (disp[i, j] == 1)
            litCt++;
        }
      }

      Day08.PrintDisplay(disp);
      Console.WriteLine();

      // correct (Part 1):
      //   116
      // correct (Part 2):
      //   UPOJFLBCEZ

      Console.WriteLine($"There are be {litCt} pixels lit.");
    }

    private static void PrintDisplay(int[,] disp)
    {
      var height = disp.GetLength(0);
      var width = disp.GetLength(1);
      
      for (int i = 0; i < height; i++)
      {
        for (int j = 0; j < width; j++)
        {
          Console.Write((disp[i, j] == 0 ? "." : "#"));
        }
        Console.WriteLine();
      }
    }

  }
}
