using System;
using System.Linq;

namespace AoC2021
{
  internal static class Extensions
  {
    internal static string GetFriendlyDuration(this System.Diagnostics.Stopwatch sw) => sw.Elapsed.GetFriendlyDuration();

    internal static string GetFriendlyDuration(this TimeSpan ts)
    {
      if (ts.TotalSeconds < 1)
        return $"{ts.Milliseconds}ms";

      return $"{ts.Minutes}m {ts.Seconds}s";
    }

    internal static long BinArrToLong(this int[] bin)
    {
      var res = 0L;
      var cpy = new int[bin.Length];

      Array.Copy(bin, cpy, cpy.Length);

      if (BitConverter.IsLittleEndian)
        Array.Reverse(cpy);

      for (int i = 0; i < cpy.Length; i++)
      {
        res += (long)(cpy[i] * Math.Pow(2, i));
      }
      
      return res;
    }

    internal static long BinStrToLong(this string bin)
    {
      var arr = new int[bin.Length];

      for (int i = 0; i < bin.Length; i++)
        arr[i] = (bin[i] == '0' ? 0 : 1);

      return arr.BinArrToLong();
    }

  }
}
