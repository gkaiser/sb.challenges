using System;

namespace AoC2019
{
  class Program
  {
    static void Main()
    {
      var sw = System.Diagnostics.Stopwatch.StartNew();

      //Day01.SolvePart1();
      //Day01.SolvePart2();
      //Day02.SolvePart1();
      //Day02.SolvePart2();
      //Day03.SolvePart1();
      //Day03.SolvePart2();
      //Day04.SolvePart1();
      //Day04.SolvePart2();
      //Day05.SolvePart1();
      Day05.SolvePart2();

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
