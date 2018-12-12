using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2018
{
  internal class Day08
  {
    internal static int MetadataSum = 0;

    internal static void SolvePart1()
    {
      var input = System.IO.File.ReadAllText("Day08_P1.txt");
      //var input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";
      var values = input.Split(' ').Select(v => int.Parse(v)).ToList();
      var i = 0;
      var n = Node.BuildNodeFromValues(values, ref i);

      // 33378 - too low

      Console.WriteLine($"The metadata entries total {n.Sum()}...");
    }

    internal static void SolvePart2()
    {
      var input = System.IO.File.ReadAllText("Day08_P1.txt");
      //var input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";
      var values = input.Split(' ').Select(v => int.Parse(v)).ToList();
      var i = 0;
      var n = Node.BuildNodeFromValues(values, ref i);

      Console.WriteLine($"The value of the root node is {n.Value()}...");
    }


    internal class Node
    {
      internal List<Node> Children;
      internal List<int> MetadataValues;

      public Node()
      {
        this.Children = new List<Node>();
        this.MetadataValues = new List<int>();
      }

      public int Sum()
      {
        return this.MetadataValues.Sum() + this.Children.Sum(n => n.Sum());
      }

      public int Value()
      {
        if (this.Children.Count == 0)
          return this.MetadataValues.Sum();

        var res = 0;
        foreach (var m in this.MetadataValues)
          if (m <= this.Children.Count)
            res += this.Children[m - 1].Value();

        return res;
      }

      public static Node BuildNodeFromValues(List<int> nums, ref int i)
      {
        var n = new Node();
        var ch = nums[i++];
        var md = nums[i++];

        for (int j = 0; j < ch; j++)
          n.Children.Add(Node.BuildNodeFromValues(nums, ref i));

        for (int j = 0; j < md; j++)
          n.MetadataValues.Add(nums[i++]);

        return n;
      }

    }

  }
}