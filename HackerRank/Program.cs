using System;
using System.Linq;

namespace HackerRank
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      //Arrays_Crush.Solve();
      //Arrays_DS.Solve();
      //Arrays_DynArray.Solve();
      //Arrays_LeftRotation.Solve();
      //Arrays_SparseArrays.Solve();
      //Arrays_ArrayManipulation.Solve(); /* STOLEN SOLUTION, MAKES 0 SENSE TO ME */

      //Trees_PreorderTraversal.Solve();

      //var arr = new int[4][];
      //arr[0] = new[] { 01, 02, 03, 04 };
      //arr[1] = new[] { 05, 06, 07, 09 };
      //arr[2] = new[] { 09, 10, 11, 12 };
      //arr[3] = new[] { 13, 14, 15, 16 };
      //var arr = new[] { 1, 1, 0, -1, -1 };

      //Program.plusMinus(arr);
      //Program.staircase(6);
      //Program.miniMaxSum(new[] { 1, 3, 5, 7, 9 });
      //Program.miniMaxSum(new[] { 256741038, 623958417, 467905213, 714532089, 938071625 });
      //Program.birthdayCakeCandles(new[] { 4, 4, 1, 3 });

      Console.WriteLine();
      Console.Write("Done, press [ENTER] to quit... ");
      Console.ReadLine();
    }

    public static int dD(int[][] arr)
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

    public static void plusMinus(int[] arr)
    {
      var l = (decimal)arr.Length;
      var pos = (decimal)arr.Where(i => i > 0).Count();
      var neg = (decimal)arr.Where(i => i < 0).Count();
      var zer = (decimal)arr.Where(i => i == 0).Count();

      Console.WriteLine((pos / l).ToString("0.000000"));
      Console.WriteLine((neg / l).ToString("0.000000"));
      Console.WriteLine((zer / l).ToString("0.000000"));
    }

    static void staircase(int n)
    {
      for (int i = 1; i <= n; i++)
      {
        var str = new string('#', i).PadLeft(n);
        Console.WriteLine(str);
      }
    }

    static void miniMaxSum(int[] arr)
    {
      Array.Sort(arr);

      long min = (long)arr[0] + (long)arr[1] + (long)arr[2] + (long)arr[3];
      long max = (long)arr[arr.Length - 1] + (long)arr[arr.Length - 2] + (long)arr[arr.Length - 3] + (long)arr[arr.Length - 4];

      Console.Write(min);
      Console.Write(" ");
      Console.Write(max);
      Console.WriteLine();
    }

    static int birthdayCakeCandles(int[] ar)
    {
      var max = ar.Max();
      var ct = ar.Where(a => a == max).Count();

      //Console.WriteLine(ct);

      return ct;
    }

  }
}
