﻿using System;

namespace AoC2021
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
      //Day04.SolvePart1();
      //Day04.SolvePart2();
      //Day05.SolvePart1();
      //Day05.SolvePart2();
      //Day06.SolvePart1();
      //Day06.SolvePart2();
      //Day07.SolvePart1();
      //Day07.SolvePart2();
      //Day08.SolvePart1();
      //Day08.SolvePart2();
      Day09.SolvePart1();


      Console.WriteLine();
      Console.Write($"Finished in {sw.GetFriendlyDuration()}, press any key to quit...");
      Console.ReadKey();
    }
  }
}
