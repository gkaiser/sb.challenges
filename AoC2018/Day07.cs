using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2018
{
  internal static class Day07
  {
    internal static void SolvePart1()
    {
      //var input = System.IO.File.ReadAllLines("Day07_P1.txt");
      var input = new[]
      {
        "Step C must be finished before step A can begin.",
        "Step C must be finished before step F can begin.",
        "Step A must be finished before step B can begin.",
        "Step A must be finished before step D can begin.",
        "Step B must be finished before step E can begin.",
        "Step D must be finished before step E can begin.",
        "Step F must be finished before step E can begin.",
      };

      var stepReqs = new Dictionary<string, List<string>>();
      var order = "";

      foreach (var l in input)
      {
        if (string.IsNullOrWhiteSpace(l))
          continue;

        var vals = l.Split(' ');
        var req = vals[1];
        var step = vals[7];

        if (!stepReqs.ContainsKey(step))
          stepReqs.Add(step, new List<string>());
        if (!stepReqs.ContainsKey(req))
          stepReqs.Add(req, new List<string>());

        stepReqs[step].Add(req);
        stepReqs[step].Sort();
      }

      var steps = new List<string>(stepReqs.Keys.Distinct());
      steps.Sort();

      for (int i = 0; ; i++)
      {
        var step = steps[i % steps.Count];

        if (order.Contains(step))
          continue;
        if (stepReqs[step].Count > 0)
          continue;

        foreach (var lst in stepReqs.Values)
          lst.Remove(step);

        order += step;
        i = -1;

        if (order.Length == steps.Count)
          break;
      }

      Console.WriteLine($"Order should be {order}...");
    }

    public static void SolvePart2()
    {
      var input = System.IO.File.ReadAllLines("Day07_P1.txt");
      //var input = new[]
      //{
      //  "Step C must be finished before step A can begin.",
      //  "Step C must be finished before step F can begin.",
      //  "Step A must be finished before step B can begin.",
      //  "Step A must be finished before step D can begin.",
      //  "Step B must be finished before step E can begin.",
      //  "Step D must be finished before step E can begin.",
      //  "Step F must be finished before step E can begin.",
      //};

      List<Step> steps = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Select((c, i) => new Step { Name = c, Time = 61 + i }).ToList();
      List<Step> next;
      char before = '\0', after = '\0';
      int workers = 5;
      int sec = 0;
      foreach (string line in input)
      {
        var matches = System.Text.RegularExpressions.Regex.Matches(line, @"\b[A-Z]\b");
        before = char.Parse(matches[0].Value);
        after = char.Parse(matches[1].Value);

        steps.First(s => s.Name == after).Before.Add(before);
      }

      while (steps.Count > 0)
      {
        next = steps.Where(s => s.Before.Count == 0).OrderBy(s => s.Time).Take(workers).ToList();
        next.ForEach(s => s.Time--);
        steps.ForEach(s => s.Before.RemoveAll(n => steps.Where(p => p.Time == 0).Select(p => p.Name).Contains(n)));
        steps.RemoveAll(s => s.Time == 0);
        sec++;
      }

      Console.WriteLine($"It will take {sec}s to complete all the steps.");
    }

    public class Step
    {
      public char Name { get; set; }
      public int Time { get; set; }
      public List<char> Before { get; set; } = new List<char>();
    }

  }
}