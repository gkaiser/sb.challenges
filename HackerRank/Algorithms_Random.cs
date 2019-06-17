using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  class Algorithms_Random
  {
    public static int DD(int[][] arr)
    {
      // 01 + 06 + 11 + 16 = 34
      // 04 + 07 + 10 + 13 = 34

      var dp = 0;
      for (int i = 0; i < arr.Length; i++)
      {
        dp += arr[i][i];
      }

      var ds = 0;
      for (int i = arr.Length - 1; i >= 0; i--)
      {
        ds += arr[arr.Length - 1 - i][i];
      }

      Console.WriteLine(Math.Abs(dp - ds));

      return Math.Abs(dp - ds);
    }

    public static void PlusMinus(int[] arr)
    {
      var l = (decimal)arr.Length;
      var pos = (decimal)arr.Where(i => i > 0).Count();
      var neg = (decimal)arr.Where(i => i < 0).Count();
      var zer = (decimal)arr.Where(i => i == 0).Count();

      Console.WriteLine((pos / l).ToString("0.000000"));
      Console.WriteLine((neg / l).ToString("0.000000"));
      Console.WriteLine((zer / l).ToString("0.000000"));
    }

    public static void Staircase(int n)
    {
      for (int i = 1; i <= n; i++)
      {
        var str = new string('#', i).PadLeft(n);
        Console.WriteLine(str);
      }
    }

    public static void MiniMaxSum(int[] arr)
    {
      Array.Sort(arr);

      long min = (long)arr[0] + (long)arr[1] + (long)arr[2] + (long)arr[3];
      long max = (long)arr[arr.Length - 1] + (long)arr[arr.Length - 2] + (long)arr[arr.Length - 3] + (long)arr[arr.Length - 4];

      Console.Write(min);
      Console.Write(" ");
      Console.Write(max);
      Console.WriteLine();
    }

    public static int BirthdayCakeCandles(int[] ar)
    {
      var max = ar.Max();
      var ct = ar.Where(a => a == max).Count();

      //Console.WriteLine(ct);

      return ct;
    }

  }
}
