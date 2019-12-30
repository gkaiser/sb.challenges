using System;
using System.Linq;

namespace AoC2019
{
  internal class Day05
  {
    internal static void SolvePart1()
    {
      var prog = System.IO.File.ReadAllText(@"Day05_P1.txt").Split(',').Select(v => int.Parse(v)).ToArray();
      //var prog = new[] { 1002, 4, 3, 4, 33 };
      //var prog = new[] { 3, 0, 4, 0, 99 };

      Console.Write("Input value: ");
      var inp = int.Parse(Console.ReadLine());

      new IntcodeComputer(inp).ProcessProgram(prog);

      // 13087969 - CORRECT
    }

    internal static void SolvePart2()
    {
      var prog = System.IO.File.ReadAllText(@"Day05_P1.txt").Split(',').Select(v => int.Parse(v)).ToArray();
      //var prog = new[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 };
      //var prog = new[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };

      Console.Write("Input value: ");
      var inpt = int.Parse(Console.ReadLine());

      new IntcodeComputer(inpt).ProcessProgram(prog);

      // 999 - LOW (used a test input program, D'OH!)
      // 14110739 - CORRECT
    }

  }
}