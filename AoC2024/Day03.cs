using System;
using System.Linq;

namespace AoC2024
{
  internal static class Day03
  {
    internal static void SolvePart1()
    {
      //var inp = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
      var inp = System.IO.File.ReadAllText("Day03.txt");

      var sum = 0;

      for (int i = 0; i < inp.Length; i++)
      {
        // need min 8 chars for valid MUL(X,Y) statement
        if (i + 7 >= inp.Length - 1)
          break;

        var tmp = inp.Substring(i, 4);
        if (tmp != "mul(")
          continue;

        var endIdx = inp.IndexOf(")", i + 7);
        if (endIdx == -1)
          continue;

        var full = inp.Substring(i, endIdx - i + 1);
        if (full.Length > 12)
          continue;

        var mulParamStr = new string(full.Substring(4).TakeWhile(c => c != ')').ToArray());
        var mulParams = mulParamStr.Split(',');
        if (mulParams.Length != 2)
          continue;

        var par1 = mulParams[0];
        if (!par1.All(c => char.IsDigit(c)))
          continue;

        var par2 = mulParams[1];
        if (!par2.All(c => char.IsDigit(c)))
          continue;

        if (!int.TryParse(par1, out var numPar1))
          continue;
        if (!int.TryParse(par2, out var numPar2))
          continue;

        sum += numPar1 * numPar2;
      }

      Console.WriteLine(sum);
    }

    internal static void SolvePart2()
    {
      //var inp = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
      var inp = System.IO.File.ReadAllText("Day03.txt");
      var sum = 0;
      var enabled = true;

      for (int i = 0; i < inp.Length; i++)
      {
        // need min 4 chars for valid do() statement
        if (i + 3 > inp.Length - 1)
          continue;

        var tmpDo = inp.Substring(i, 4);
        if (tmpDo == "do()")
        {
          i += 3;
          enabled = true;
          continue;
        }

        // need min 6 chars for valid don't() statement
        if (i + 6 > inp.Length - 1)
          continue;

        var tmpDont = inp.Substring(i, 7);
        if (tmpDont == "don't()")
        {
          i += 6;
          enabled = false;
          continue;
        }

        if (!enabled)
          continue;

        // need min 8 chars for valid MUL(X,Y) statement
        if (i + 7 > inp.Length - 1)
          break;

        var tmp = inp.Substring(i, 4);
        if (tmp != "mul(")
          continue;

        var endIdx = inp.IndexOf(")", i + 7);
        if (endIdx == -1)
          continue;

        var full = inp.Substring(i, endIdx - i + 1);
        if (full.Length > 12)
          continue;

        var mulParamStr = new string(full.Substring(4).TakeWhile(c => c != ')').ToArray());
        var mulParams = mulParamStr.Split(',');
        if (mulParams.Length != 2)
          continue;

        var par1 = mulParams[0];
        if (!par1.All(c => char.IsDigit(c)))
          continue;

        var par2 = mulParams[1];
        if (!par2.All(c => char.IsDigit(c)))
          continue;

        if (!int.TryParse(par1, out var numPar1))
          continue;
        if (!int.TryParse(par2, out var numPar2))
          continue;

        sum += numPar1 * numPar2;
      }

      Console.WriteLine(sum);
    }


  }
}
