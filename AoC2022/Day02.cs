using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2022
{
  internal class Day02
  {
    private enum RpsChoice
    {
      Rock = 1,
      Paper = 2,
      Scissors = 3
    }

    private static Dictionary<string, RpsChoice> ChoiceMap = new()
    {
      { "A", RpsChoice.Rock },
      { "B", RpsChoice.Paper },
      { "C", RpsChoice.Scissors },
      { "X", RpsChoice.Rock },
      { "Y", RpsChoice.Paper },
      { "Z", RpsChoice.Scissors },
    };

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
        var p1 = Day02.ChoiceMap[pm[0]];
        var p2 = Day02.ChoiceMap[pm[1]];

        var p1Win = DoesPlayer1Win(p1, p2);

        score += (int)p2 + (!p1Win.HasValue ? 3 : p1Win.Value ? 0 : 6);
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
        var p1 = Day02.ChoiceMap[pm[0]];
        var ps = pm[1];
        var p2 = RpsChoice.Rock;

        if (ps == "X") // lose
          p2 = (p1 == RpsChoice.Rock ? RpsChoice.Scissors : p1 == RpsChoice.Paper ? RpsChoice.Rock : RpsChoice.Paper);
        else if (ps == "Y") // draw
          p2 = p1;
        else // win
          p2 = (p1 == RpsChoice.Rock ? RpsChoice.Paper : p1 == RpsChoice.Paper ? RpsChoice.Scissors : RpsChoice.Rock);

        score += (int)p2 + (ps == "X" ? 0 : ps == "Y" ? 3 : 6);
      }

      Console.WriteLine($"Player 2's score would be {score}...");
    }

    private static bool? DoesPlayer1Win(RpsChoice p1, RpsChoice p2)
    {
      // draw - return null
      if ((int)p1 == (int)p2) 
        return null;

      // rock vs paper and paper vs rock
      if ((int)p1 == 1 && (int)p2 == 3)
        return true;
      if ((int)p1 == 3 && (int)p2 == 1)
        return false;

      // everything else can be choice-value of p1 > choice-value of p2
      return (int)p1 > (int)p2;
    }

  }
}
