using System;
using System.Collections.Generic;
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

    }

  }

  
}