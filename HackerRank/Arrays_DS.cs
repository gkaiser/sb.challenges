using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  class Arrays_DS
  {
    public static void Solve()
    {
      var inp =
        "-1 -1 0 -9 -2 -2" + Environment.NewLine +
        "-2 -1 -6 -8 -2 -5" + Environment.NewLine +
        "-1 -1 -1 -2 -3 -4" + Environment.NewLine +
        "-1 -9 -2 -4 -4 -5" + Environment.NewLine +
        "-7 -3 -3 -2 -9 -9" + Environment.NewLine +
        "-1 -3 -1 -2 -4 -5";
      var lines = inp.Split(new char[] { (char)0x0D, (char)0x0A }, StringSplitOptions.RemoveEmptyEntries);

      int[][] arr = new int[6][];
      for (int i = 0; i < 6; i++)
      {
        arr[i] = Array.ConvertAll(lines[i].Split(' '), arrTemp => Convert.ToInt32(arrTemp));
      }

      int result = hourglassSum(arr);

      Console.WriteLine(result);
    }

    static int hourglassSum(int[][] arr)
    {
      var h = arr.Length;
      var w = arr[0].Length;
      
      Func<int, int, bool> validHourglassPosn = delegate(int x, int y)
      {
        return x + 2 < w && y + 2 < h;
      };

      int? ms = null;

      for (int i = 0; i < 6; i++)
      {
        for (int j = 0; j < 6; j++)
        {
          if (!validHourglassPosn(j, i))
            continue;

          var hs = arr[i][j + 0] + arr[i][j + 1] + arr[i][j + 2] +
                   arr[i + 1][j + 1] + 
                   arr[i + 2][j + 0] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
          if (!ms.HasValue || hs > ms)
            ms = hs;
        }
      }

      return (int)ms;
    }

  }
}
