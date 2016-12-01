using System;
using System.Collections.Generic;

namespace AdventOfCode
{
  internal static class Day06
  {
    internal static List<string> Input = new List<string>(System.IO.File.ReadAllLines("06.txt"));

    internal static void Process(bool runPart1)
    {
      Console.WriteLine("Day 6 - Part " + (runPart1 ? 1 : 2));

      if (runPart1)
        Day06.Part1();
      else
        Day06.Part2();
    }

    private static void Part1()
    {
      var board = new bool[1000, 1000];

      foreach (var s in Day06.Input)
      {
        var op = (
          s.StartsWith("toggle") ? "T" :
          s.StartsWith("turn on") ? "ON" : "OFF");
        var posnStartIdx = (
          op == "T" ? 7 :
          op == "ON" ? 8 : 9);

        var posns = s.Substring(posnStartIdx).Trim();
        var posnBeg = posns.Split(new[] { " through " }, StringSplitOptions.RemoveEmptyEntries)[0];
        var begX = int.Parse(posnBeg.Split(',')[0]);
        var begY = int.Parse(posnBeg.Split(',')[1]);
        var posnEnd = posns.Split(new[] { " through " }, StringSplitOptions.RemoveEmptyEntries)[1];
        var endX = int.Parse(posnEnd.Split(',')[0]);
        var endY = int.Parse(posnEnd.Split(',')[1]);

        var minX = Math.Min(begX, endX);
        var minY = Math.Min(begY, endY);
        var maxX = Math.Max(begX, endX);
        var maxY = Math.Max(begY, endY);

        for (int x = minX; x <= maxX; x++)
        {
          for (int y = minY; y <= maxY; y++)
          {
            board[y, x] = (
              op == "T" ? !board[y, x] :
              op == "ON" ? true : false);
          }
        }
      }

      var onCt = 0;
      for (int i = 0; i < 1000; i++)
      {
        for (int j = 0; j < 1000; j++)
        {
          onCt += (board[i, j] ? 1 : 0);
        }
      }

      Console.WriteLine("  There are " + onCt + " lights turned on ...");
    }

    private static void Part2()
    {
      var board = new int[1000, 1000];

      foreach (var s in Day06.Input)
      {
        var op = (
          s.StartsWith("toggle") ? "T" :
          s.StartsWith("turn on") ? "ON" : "OFF");
        var posnStartIdx = (
          op == "T" ? 7 :
          op == "ON" ? 8 : 9);

        var posns = s.Substring(posnStartIdx).Trim();
        var posnBeg = posns.Split(new[] { " through " }, StringSplitOptions.RemoveEmptyEntries)[0];
        var begX = int.Parse(posnBeg.Split(',')[0]);
        var begY = int.Parse(posnBeg.Split(',')[1]);
        var posnEnd = posns.Split(new[] { " through " }, StringSplitOptions.RemoveEmptyEntries)[1];
        var endX = int.Parse(posnEnd.Split(',')[0]);
        var endY = int.Parse(posnEnd.Split(',')[1]);

        var minX = Math.Min(begX, endX);
        var minY = Math.Min(begY, endY);
        var maxX = Math.Max(begX, endX);
        var maxY = Math.Max(begY, endY);

        for (int x = minX; x <= maxX; x++)
        {
          for (int y = minY; y <= maxY; y++)
          {
            board[y, x] += (
              op == "T" ? 2 :
              op == "ON" ? 1 : -1);

            if (board[y, x] < 0)
              board[y, x] = 0;
          }
        }
      }

      var onCt = 0;
      for (int i = 0; i < 1000; i++)
      {
        for (int j = 0; j < 1000; j++)
        {
          onCt += board[i, j];
        }
      }

      Console.WriteLine("  The total brightness is " + onCt + "...");
    }

  }
}
