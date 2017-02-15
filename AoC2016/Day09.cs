using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2016
{
  internal static class Day09
  {
    internal static void Solve_Part1()
    {
      Console.WriteLine("Solving Day 09, Part 1...");

      // var compStr = "ADVENT";
      // var compStr = "A(1x5)BC";
      // var compStr = "(3x3)XYZ";
      // var compStr = "A(2x2)BCD(2x2)EFG";
      // var compStr = "(6x1)(1x3)A";
      // var compStr = "X(8x2)(3x3)ABCY";
      var compStr = System.IO.File.ReadAllText("09.txt");
      
      var sb = new StringBuilder();
      for (int i = 0; i < compStr.Length; i++)
      {
        if (compStr[i] == '(')
        {
          var compVals = compStr.Substring(i + 1, compStr.IndexOf(')', i) - (i + 1));
          var charCt = int.Parse(compVals.Split('x')[0]);
          var repCt = int.Parse(compVals.Split('x')[1]);
          var repStr = compStr.Substring(compStr.IndexOf(')', i) + 1, charCt);

          for (int j = 0; j < repCt; j++)
            sb.Append(repStr);

          i += compVals.Length + 2 + (charCt - 1);
        }
        else
        {
          sb.Append(compStr[i]);
        }
      }

      Console.WriteLine($"The decompressed value has a length of {sb.ToString().Select(c => !char.IsWhiteSpace(c)).Count()}.");

      // correct:
      //   123908
    }

    internal static void Solve_Part2()
    {
      Console.WriteLine("Solving Day 09, Part 2...");

      //var compStr = "ADVENT";
      //var compStr = "A(1x5)BC";
      //var compStr = "(3x3)XYZ";
      //var compStr = "A(2x2)BCD(2x2)EFG";
      //var compStr = "(6x1)(1x3)A";
      //var compStr = "X(8x2)(3x3)ABCY";
      //var compStr = "(27x12)(20x12)(13x14)(7x10)(1x12)A";
      //var compStr = "(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN";
      var compStr = System.IO.File.ReadAllText("09.txt");
      ulong decompLen = 0;

      for (int i = 0; i < compStr.Length; i++)
      {
        if (compStr[i] == '(')
        {
          var compVals = compStr.Substring(i + 1, compStr.IndexOf(')', i) - (i + 1));
          var charCt = int.Parse(compVals.Split('x')[0]);
          var str = compStr.Substring(i, compVals.Length + 2 + charCt);

          decompLen += Day09.GetExpandedLength(str);

          i += compVals.Length + 2 + (charCt - 1);
        }
        else
        {
          decompLen++;
        }
      }

      Console.WriteLine($"The decompressed value has a length of {decompLen}.");

      // correct:
      //   10,755,693,147
    }

    private static ulong GetExpandedLength(string compStr)
    {
      ulong len = 0;
      for (int i = 0; i < compStr.Length; i++)
      {
        if (char.IsWhiteSpace(compStr[i]))
          continue;
        if (compStr[i] != '(')
        {
          len++;
          continue;
        }

        var compVals = compStr.Substring(i + 1, compStr.IndexOf(')', i) - (i + 1));
        var charCt = int.Parse(compVals.Split('x')[0]);
        var repCt = int.Parse(compVals.Split('x')[1]);
        var repStr = compStr.Substring(compStr.IndexOf(')', i) + 1, charCt);
        var repStrLen = (ulong)repStr.Length;

        if (repStr.Contains("(") && repStr.Contains(")") && repStr.Contains("x"))
        {
          var expLen = Day09.GetExpandedLength(repStr);
          repStrLen = expLen;
        }

        for (int j = 0; j < repCt; j++)
          len += (ulong)repStrLen;

        i += compVals.Length + 2 + (charCt - 1);
      }

      return len;
    }

  }
}
