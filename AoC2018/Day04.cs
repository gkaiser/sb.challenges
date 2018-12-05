using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2018
{
  internal static class Day04
  {
    internal static void Solve(bool useStrat1)
    {
      var input = new List<string>(System.IO.File.ReadAllLines(@"Day04_P1.txt"));
      input.Sort();

      var guards = new List<Guard>();
      Guard latestGuard = null;

      foreach (var l in input)
      {
        if (string.IsNullOrWhiteSpace(l))
          continue;

        var vals = l.Split(' ');

        if (l.Contains("Guard #"))
        {
          var id = int.Parse(vals[3].Replace("#", ""));

          if (guards.FirstOrDefault(g => g.Id == id) == null)
            guards.Add(new Guard(id));

          latestGuard = guards.FirstOrDefault(g => g.Id == id);

          continue;
        }

        var dt = DateTime.Parse(l.Substring(1, 16));

        var sleeps = l.Contains("falls");
        if (sleeps)
          latestGuard.Sleep(dt.Minute);
        else
          latestGuard.Wake(dt.Minute);
      }

      if (useStrat1)
      {
        var max = 0;
        Guard sleepy = null;
        foreach (var g in guards)
        {
          if (g.TotalMinutesAsleep > max)
          {
            max = g.TotalMinutesAsleep;
            sleepy = g;
          }
        }

        // 73646 BINGO

        Console.WriteLine($"Guard #{sleepy.Id} is the sleepiest, having slept {sleepy.TotalMinutesAsleep} total mintues, and (s)he's sleepiest at minute {sleepy.GetSleepiestMinute()} (answer: {sleepy.Id * sleepy.GetSleepiestMinute()})...");
      }
      else
      {
        // find sleepiest minute per guard
        Guard sleepiestGuard = null;
        var sleepiestMin = 0;
        var sleepiestMinDays = 0;

        foreach (var g in guards)
        {
          var most = g.GetSleepiestMinuteAndDaysCount();

          if (most[1] > sleepiestMinDays)
          {
            sleepiestGuard = g;
            sleepiestMin = most[0];
            sleepiestMinDays = most[1];
          }
        }

        // 4727 BINGO

        Console.WriteLine($"Guard #{sleepiestGuard.Id} spent {sleepiestMinDays} days asleep at minute {sleepiestMin}, so the answer would be {sleepiestGuard.Id * sleepiestMin}...");
      }
    }

    internal class Guard
    {
      public int Id;
      public int TotalMinutesAsleep;
      private Dictionary<int, int> MinutesAsleep = new Dictionary<int, int>();
      private int LastSleepMinute;

      public Guard(int id) { this.Id = id; }

      public void Sleep(int min)
      {
        this.LastSleepMinute = min;
      }

      public void Wake(int min)
      {
        var ct = min - this.LastSleepMinute;

        this.TotalMinutesAsleep += ct;

        for (int i = this.LastSleepMinute; i < min; i++)
        {
          if (!this.MinutesAsleep.ContainsKey(i))
            this.MinutesAsleep.Add(i, 0);

          this.MinutesAsleep[i]++;
        }
      }

      public int GetSleepiestMinute()
      {
        var daysCt = 0;
        var sleepMin = 0;

        foreach (var k in this.MinutesAsleep.Keys)
        {
          if (this.MinutesAsleep[k] > daysCt)
          {
            daysCt = this.MinutesAsleep[k];
            sleepMin = k;
          }
        }

        return sleepMin;
      }

      public int[] GetSleepiestMinuteAndDaysCount()
      {
        var daysCt = 0;
        var sleepMin = 0;

        foreach (var k in this.MinutesAsleep.Keys)
        {
          if (this.MinutesAsleep[k] > daysCt)
          {
            daysCt = this.MinutesAsleep[k];
            sleepMin = k;
          }
        }

        return new[] { sleepMin, daysCt };
      }

    }

  }
}