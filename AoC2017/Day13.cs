using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2017
{
  internal static class Day13
  {
    internal static void Solve_Part1()
    {
      //var input = new[]
      //{
      //  "0: 3",
      //  "1: 2",
      //  "4: 4",
      //  "6: 4",
      //}; // 24
      var input = System.IO.File.ReadAllLines("Day13_Part1.txt"); // 2604
      var maxDepth = input.Select(l => int.Parse(l.Split(':')[0])).Max() + 1;
      var layers = new Layer[maxDepth];

      foreach (var l in input)
      {
        var items = l.Split(':');
        var depth = int.Parse(items[0].Trim());
        var range = int.Parse(items[1].Trim());

        var layer = new Layer(depth, range);

        layers[depth] = layer;
      }

      var posn = -1;
      var tripSeverity = 0;

      for (int i = 0; i < layers.Length; i++)
      {
        posn++;

        if (layers[i] != null && layers[i].ScannerPosition == 0)
          tripSeverity += layers[i].Severity;

        for (int j = 0; j < layers.Length; j++)
          if (layers[j] != null)
            layers[j].Move();
      }

      Console.WriteLine($"Our trip's total severity was {tripSeverity}...");
    }

    internal static void Solve_Part2()
    {
      //var input = new[]
      //{
      //  "0: 3",
      //  "1: 2",
      //  "4: 4",
      //  "6: 4",
      //}; // 24
      var input = System.IO.File.ReadAllLines("Day13_Part1.txt"); // 2604
      var maxDepth = input.Select(l => int.Parse(l.Split(':')[0])).Max() + 1;
      var layers = new Layer[maxDepth];

      foreach (var l in input)
      {
        var items = l.Split(':');
        var depth = int.Parse(items[0].Trim());
        var range = int.Parse(items[1].Trim());

        var layer = new Layer(depth, range);

        layers[depth] = layer;
      }

      var posn = -1;
      var tripSeverity = 0;

      for (int i = 0; i < layers.Length; i++)
      {
        posn++;

        if (layers[i] != null && layers[i].ScannerPosition == 0)
          tripSeverity += layers[i].Severity;

        for (int j = 0; j < layers.Length; j++)
          if (layers[j] != null)
            layers[j].Move();
      }

      Console.WriteLine($"Our trip's total severity was {tripSeverity}...");
    }


    private class Layer
    {
      public int Depth;
      public int Range;
      public int ScannerPosition;
      public int ScannerIncrement = 1;
      public readonly int Severity;

      public Layer(int depth, int range)
      {
        this.Depth = depth;
        this.Range = range;
        this.Severity = this.Depth * this.Range;
      }

      public void Move()
      {
        if (this.ScannerPosition + this.ScannerIncrement >= this.Range)
          this.ScannerIncrement = -1;
        if (this.ScannerPosition + this.ScannerIncrement < 0)
          this.ScannerIncrement = 1;

        this.ScannerPosition += this.ScannerIncrement;
      }
    }

  }
}
