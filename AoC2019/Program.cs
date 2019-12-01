using System;
using System.Linq;

namespace AoC2019
{
  class Program
  {
    static void Main()
    {
      var sw = System.Diagnostics.Stopwatch.StartNew();

      //Day01.SolvePart1();
      //Day01.SolvePart2();

      sw.Stop();

      Console.WriteLine();
      Console.Write($"Finished in {Program.GetFriendlyDuration(sw)}, press any key to quit...");
      Console.ReadKey();
    }

    private static string GetFriendlyDuration(System.Diagnostics.Stopwatch sw)
    {
      if (sw.Elapsed.Duration().TotalSeconds < 1)
        return $"{sw.Elapsed.Milliseconds}ms";

      return $"{sw.Elapsed.Minutes}m {sw.Elapsed.Seconds}s";
    }

  }
}
