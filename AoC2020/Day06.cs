using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2020
{
  public static class Day06
  {
    public static void SolvePart1()
    {
      // var lines = new[] { 
      //  
      // };
      var lines = new string[0];
      if (System.IO.File.Exists("Day06.txt"))
        lines = System.IO.File.ReadAllLines(@"Day06.txt");
      else
        lines = System.IO.File.ReadAllLines(@"bin\Debug\netcoreapp3.1\Day06.txt");
    }

    public static void SolvePart2()
    {
      
    }

  }
}