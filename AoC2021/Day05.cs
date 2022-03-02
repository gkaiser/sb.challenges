using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2021
{
  internal static class Day05
  {
    internal static void SolvePart1()
    {
      //var lines = new[]
      //{
      //  "0,9 -> 5,9",
      //  "8,0 -> 0,8",
      //  "9,4 -> 3,4",
      //  "2,2 -> 2,1",
      //  "7,0 -> 7,4",
      //  "6,4 -> 2,0",
      //  "0,9 -> 2,9",
      //  "3,4 -> 1,4",
      //  "0,0 -> 8,8",
      //  "5,5 -> 8,2",
      //}.ToList();
      var lines = System.IO.File.ReadAllLines("Day05.txt").ToList();

      // clean list, since we're only worrying about straight lines
      lines = lines.Where(l => IsStraightLinePair(l)).ToList();

      var allPoints = new List<Day05Point>();

      foreach (var l in lines)
      {
        allPoints.AddRange(GetAllPointsFromStrRange(l));
      }

      var dictCounts = new Dictionary<Day05Point, int>();

      foreach (var pt in allPoints)
      {
        if (!dictCounts.ContainsKey(pt))
          dictCounts.Add(pt, 0);

        dictCounts[pt]++;
      }

      var olap = new List<Day05Point>();

      foreach (var pt in dictCounts.Keys)
      {
        if (dictCounts[pt] < 2)
          continue;

        //Console.WriteLine($"{pt} => Seen {dictCounts[pt]} times...");
        olap.Add(pt);
      }

      Console.WriteLine($"There are {olap.Count} points that overlap...");
    }

    internal static void SolvePart2()
    {
      //var lines = new[]
      //{
      //  "0,9 -> 5,9",
      //  "8,0 -> 0,8",
      //  "9,4 -> 3,4",
      //  "2,2 -> 2,1",
      //  "7,0 -> 7,4",
      //  "6,4 -> 2,0",
      //  "0,9 -> 2,9",
      //  "3,4 -> 1,4",
      //  "0,0 -> 8,8",
      //  "5,5 -> 8,2",
      //}.ToList();
      var lines = System.IO.File.ReadAllLines("Day05.txt").ToList();

      var allPoints = new List<Day05Point>();

      foreach (var l in lines)
      {
        allPoints.AddRange(GetAllPointsFromStrRange(l));
      }

      var dictCounts = new Dictionary<Day05Point, int>();

      foreach (var pt in allPoints)
      {
        if (!dictCounts.ContainsKey(pt))
          dictCounts.Add(pt, 0);

        dictCounts[pt]++;
      }

      var oc = dictCounts.Values.Where(v => v > 1).Count();

      Console.WriteLine($"There are {oc} points that overlap...");
    }

    internal static bool IsStraightLinePair(string l)
    {
      var sp = l.Replace(" ", "").Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);

      return (sp[0].Split(',')[0] == sp[1].Split(',')[0] || sp[0].Split(',')[1] == sp[1].Split(',')[1]);
    }

    internal static List<Day05Point> GetAllPointsFromStrRange(string l)
    {
      var pstrs = l.Replace(" ", "").Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
      var p1 = new Day05Point(int.Parse(pstrs[0].Split(',')[0]), int.Parse(pstrs[0].Split(',')[1]));
      var p2 = new Day05Point(int.Parse(pstrs[1].Split(',')[0]), int.Parse(pstrs[1].Split(',')[1]));

      var minx = Math.Min(p1.X, p2.X);
      var maxx = Math.Max(p1.X, p2.X);
      var miny = Math.Min(p1.Y, p2.Y);
      var maxy = Math.Max(p1.Y, p2.Y);

      var lst = new List<Day05Point>();

      if (p1.X == p2.X || p1.Y == p2.Y)
      {
        for (int i = 0; i <= maxx - minx; i++)
        {
          for (int j = 0; j <= maxy - miny; j++)
          {
            lst.Add(new Day05Point(minx + i, miny + j));
          }
        }
      }
      else
      {
        var incX = p2.X > p1.X;
        var incY = p2.Y > p1.Y;

        lst.Add(p1.Copy());

        do
        {
          lst.Add(new Day05Point(lst.Last().X + (incX ? 1 : -1), lst.Last().Y + (incY ? 1 : -1)));
        } while (lst.Last().X != p2.X && lst.Last().Y != p2.Y);
      }

      return lst;
    }

  }
}
