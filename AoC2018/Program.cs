using System;

namespace AoC2018
{
  class Program
  {
    static void Main(string[] args)
    {
      var sw = System.Diagnostics.Stopwatch.StartNew();

      //Day01.SolvePart1();
      //Day01.SolvePart2();
      //Day02.SolvePart1();
      //Day02.SolvePart2();
      //Day03.SolvePart1();
      //Day03.SolvePart2();
      //Day04.Solve(true);
      //Day04.Solve(false);
      //Day05.SolvePart1();
      //Day05.SolvePart2();
      //Day06.SolvePart1();
      //Day06.Cheater(true);
      //Day06.Cheater(false);
      Day07.SolvePart1();

      sw.Stop();

      Console.WriteLine();
      Console.Write($"Finished in {sw.Elapsed.Minutes}m {sw.Elapsed.Seconds}s, press any key to quit...");
      Console.ReadKey();
    }
  }
}
