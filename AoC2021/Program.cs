using System;

namespace AoC2021
{
  class Program
  {
    static void Main(string[] args)
    {
      var sw = System.Diagnostics.Stopwatch.StartNew();

      //Day01.SolvePart1();
      Day01.SolvePart2();

      Console.WriteLine();
      Console.Write($"Finished in {sw.GetFriendlyDuration()}, press any key to quit...");
      Console.ReadKey();
    }
  }
}
