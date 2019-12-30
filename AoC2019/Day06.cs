using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2019
{
  internal class Day06
  {
    internal static void SolvePart1()
    {
      var lines = System.IO.File.ReadAllLines("Day06.txt");


    }


    internal class Node
    {
      internal readonly string Id;
      internal List<Node> Children;

      internal Node(string id) { this.Id = id; }
    }

  }
}