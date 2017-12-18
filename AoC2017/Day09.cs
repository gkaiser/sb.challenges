using System;

namespace AoC2017
{
  internal static class Day09
  {
    internal static void Solve_Part1()
    {
      //var input = "{{<!>},{<!>},{<!>},{<a>}}";
      //var input = "{{<a>},{<a>},{<a>},{<a>}}";
      //var input = "{{<a!>},{<a!>},{<a!>},{<ab>}}";
      //var input = "{{<ab>},{<ab>},{<ab>},{<ab>}}";
      //var input = "{{<!!>},{<!!>},{<!!>},{<!!>}}";
      //var input = "{{{},{},{{}}}}";
      var input = System.IO.File.ReadAllText("Day09_Part1.txt"); // 12396
      var cleanInput = "";

      // remove "!" and the char after it
      for (int i = 0; i < input.Length; i++)
      {
        if (input[i] == '!')
        {
          i++;
          continue;
        }

        cleanInput += input[i];
      }

      var pristineInput = "";
      var inGarbage = false;

      // remove garbage
      for (int i = 0; i < cleanInput.Length; i++)
      {
        if (cleanInput[i] == '<' && !inGarbage)
        {
          inGarbage = true;
          continue;
        }
        if (cleanInput[i] == '>' && inGarbage)
        {
          inGarbage = false;
          continue;
        }
        if (inGarbage)
          continue;

        pristineInput += cleanInput[i];
      }

      var totScore = 0;
      var currScore = 0;

      // count up score
      for (int i = 0; i < pristineInput.Length; i++)
      {
        if (pristineInput[i] == '{')
        {
          currScore++;
          totScore += currScore;
        }
        else if (pristineInput[i] == '}')
        {
          currScore--;
        }
      }

      Console.WriteLine($"Looks like the score is {totScore}...");
    }

    internal static void Solve_Part2()
    {
      //var input = "{{<!>},{<!>},{<!>},{<a>}}";
      //var input = "{{<a>},{<a>},{<a>},{<a>}}";
      //var input = "{{<a!>},{<a!>},{<a!>},{<ab>}}";
      //var input = "{{<ab>},{<ab>},{<ab>},{<ab>}}";
      //var input = "{{<!!>},{<!!>},{<!!>},{<!!>}}";
      //var input = "{{{},{},{{}}}}";
      var input = System.IO.File.ReadAllText("Day09_Part1.txt"); // 6346
      var cleanInput = "";

      // remove "!" and the char after it
      for (int i = 0; i < input.Length; i++)
      {
        if (input[i] == '!')
        {
          i++;
          continue;
        }

        cleanInput += input[i];
      }

      var pristineInput = "";
      var inGarbage = false;
      var garbageCount = 0;

      // remove garbage
      for (int i = 0; i < cleanInput.Length; i++)
      {
        if (cleanInput[i] == '<' && !inGarbage)
        {
          inGarbage = true;
          continue;
        }
        if (cleanInput[i] == '>' && inGarbage)
        {
          inGarbage = false;
          continue;
        }
        if (inGarbage)
        {
          garbageCount++;
          continue;
        }

        pristineInput += cleanInput[i];
      }

      Console.WriteLine($"Looks like the garbage length is {garbageCount}...");
    }

  }
}
