using System;

namespace AoC2022
{
  internal class Day02
  {
    private static string[] TestInput = new[]
    {
      "A Y",
      "B X",
      "C Z",
    };

    internal static void SolvePart1()
    {
      //var inp = Day02.TestInput;
      var inp = System.IO.File.ReadAllLines("Day02.txt");

      var score = 0;
      foreach (var r in inp)
      {
        var pm = r.Split(' ');
        var p1 = "ABC".IndexOf(pm[0]);
        var p2 = "XYZ".IndexOf(pm[1]);
        
        score += 
          (p2 + 1) +
          (p1 == p2 ? 3 : 
           p1 == 0 && p2 == 2 ? 0 : 
           p1 == 2 && p2 == 0 ? 6 : 
           p1 > p2 ? 0 : 6);
      }

      Console.WriteLine($"Player 2's score would be {score}...");
    }

    internal static void SolvePart2()
    {
      //var inp = Day02.TestInput;
      var inp = System.IO.File.ReadAllLines("Day02.txt");

      var score = 0;
      foreach (var r in inp)
      {
        var pm = r.Split(' ');
        var p1 = "ABC".IndexOf(pm[0]);
        var ps = pm[1];

        switch (ps)
        {
          case "X": // lose
            score += (p1 == 0 ? 2 : p1 - 1) + 1;
            score += 0;
            break;
          case "Y": // draw
            score += p1 + 1;
            score += 3;
            break;
          case "Z": // win
            score += (p1 == 2 ? 0 : p1 + 1) + 1;
            score += 6;
            break;
          default:
            throw new Exception("wth bro");
        }
      }

      Console.WriteLine($"Player 2's score would be {score}...");
    }

  }
}
