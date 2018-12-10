using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2018
{
  internal static class Day06
  {
    internal static void SolvePart1()
    {
      //var input = System.IO.File.ReadAllLines("Day06_P1.txt");
      var input = new[]
      {
        "1, 1",
        "1, 6",
        "8, 3",
        "3, 4",
        "5, 5",
        "8, 9",
      };
      var points = new List<Point>();

      foreach (var l in input)
      {
        if (string.IsNullOrWhiteSpace(l))
          continue;

        var vals = l.Replace(",", "").Split(' ');
        points.Add(new Point(int.Parse(vals[0]), int.Parse(vals[1])));
      }

      for (int i = 0; i < points.Count; i++)
      {
        var pt = points[i];

        // check if we can find point above, below, left, or right of point
        // if we can find one for each, then we know this is an OK point to start working with

        var ptsAbove = points.Where(p => p.Y < pt.Y);
        var ptsBelow = points.Where(p => p.Y > pt.Y);
        var ptsLeft = points.Where(p => p.X < pt.X);
        var ptsRight = points.Where(p => p.X > pt.X);

        if (ptsAbove.Count() == 0 || ptsBelow.Count() == 0 || ptsLeft.Count() == 0 || ptsRight.Count() == 0)
          continue;

        Point ptAbove = null;
        Point ptBelow = null;
        Point ptLeft = null;
        Point ptRight = null;

        for (int k = 0; k < points.Count; k++)
        {
          if (k == i)
            continue;
          if (points[k].Y > pt.Y)
            continue;

          if (ptAbove == null || pt.GetManhattanDistanceFromPoint(points[k]) < pt.GetManhattanDistanceFromPoint(ptAbove))
            ptAbove = points[k];
        }
        
        Console.WriteLine($"{(char)(i + 65)} ==> {{{pt.X}, {pt.Y}}}");
      }
    }

    public static void Cheater(bool solvePart1)
    {
      var input = System.IO.File.ReadAllLines("Day06_P1.txt");

      int minX = int.MaxValue;
      int minY = int.MaxValue;
      int maxX = 0;
      int maxY = 0;
      int maxArea = 0;
      int distanceLimit = 10000;

      var points = new Dictionary<Point, int>();
      for (int i = 0; i < input.Length; i++)
      {
        var coords = input[i].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int x = int.Parse(coords[0]);
        int y = int.Parse(coords[1]);

        minX = Math.Min(x, minX);
        minY = Math.Min(y, minY);
        maxX = Math.Max(x, maxX);
        maxY = Math.Max(y, maxY);

        points.Add(new Point(x, y), 0);
      }

      var grid = new Dictionary<Point, (int dist, Point point)>();

      for (int x = minX - 1; x <= maxX + 1; x++)
      {
        for (int y = minY - 1; y <= maxY + 1; y++)
        {
          if (solvePart1)
          {
            grid.Add(new Point(x, y), (int.MaxValue, new Point(-1, -1)));
            foreach (Point p in points.Keys)
            {
              int distance = Math.Abs(x - p.X) + Math.Abs(y - p.Y);
              if (grid[new Point(x, y)].dist == distance)
                grid[new Point(x, y)] = (distance, new Point(-1, -1));
              else if (distance < grid[new Point(x, y)].dist)
                grid[new Point(x, y)] = (distance, p);
              if (distance == 0) break;
            }
          }
          else
          {
            int distSoFar = 0;

            foreach (Point p in points.Keys)
              if ((distSoFar += Math.Abs(x - p.X) + Math.Abs(y - p.Y)) >= distanceLimit)
                break;

            if (distSoFar < distanceLimit)
              maxArea++;
          }
        }
      }

      if (solvePart1)
      {
        foreach (var kvp in grid)
        {
          if ((kvp.Value.point.X == -1 && kvp.Value.point.Y == -1) || points[kvp.Value.point] == -1)
            continue;

          if (kvp.Key.X < minX || kvp.Key.X > maxX || kvp.Key.Y < minY || kvp.Key.Y > maxY)
          {
            points[kvp.Value.point] = -1;
            continue;
          }

          maxArea = Math.Max(maxArea, ++points[kvp.Value.point]);
        }
      }

      Console.WriteLine(maxArea);
    }

  }
}