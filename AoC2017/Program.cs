using System;

namespace AoC2017
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("+=====================+");
      Console.WriteLine("| Advent of Code 2017 |");
      Console.WriteLine("+=====================+");

      //Day01.Solve_Part1();
      //Day01.Solve_Part2();
      //Day02.Solve_Part1();
      //Day02.Solve_Part2();
      //Day03.Solve_Part1_Att1(); // Takes FOR-EV-ER. Inefficient.
      //Day03.Solve_Part1_Att2(); // Takes no time at all; mucho better.
      Day03.Solve_Part2();

      Console.WriteLine();
      Console.Write("Finished, press any key to quit...");
      Console.ReadKey();
    }
  }
}
