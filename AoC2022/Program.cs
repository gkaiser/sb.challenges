using System;

namespace AoC2022
{
  internal class Program
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
      //Day04.SolvePart1();
      //Day04.SolvePart2();
      //Day05.SolvePart1();
      //Day05.SolvePart2();
      //Day06.SolvePart1();
      //Day06.SolvePart2();

      sw.Stop();

      if (System.Diagnostics.Debugger.IsAttached)
      {
        Console.WriteLine();
        Console.Write($"Done! Finished in {sw.Elapsed}. Press any key to quit... ");
        Console.ReadKey();
      }
    }

  }
}
