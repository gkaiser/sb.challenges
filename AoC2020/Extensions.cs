using System;

namespace AoC2020
{
  internal static class Extensions
  {
    internal static string GetFriendlyDuration(this System.Diagnostics.Stopwatch sw)
    {
      if (sw.Elapsed.Duration().TotalSeconds < 1)
        return $"{sw.Elapsed.Milliseconds}ms";

      return $"{sw.Elapsed.Minutes}m {sw.Elapsed.Seconds}s";
    }

  }
}