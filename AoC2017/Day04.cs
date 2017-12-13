using System;
using System.Linq;

namespace AoC2017
{
  internal static class Day04
  {
    internal static void Solve_Part1()
    {
      var inputLines = System.IO.File.ReadAllLines("Day04_Part1.txt"); // 386
      var validPhrases = 0;

      foreach (var l in inputLines)
      {
        var words = l.Split(' ');
        var isValid = true;

        for (int i = 0; i < words.Length; i++)
        {
          for (int j = 0; j < words.Length; j++)
          {
            if (j == i)
              continue;

            if (words[i] == words[j])
            {
              isValid = false;
              break;
            }
          }

          if (!isValid)
            break;
        }

        if (isValid)
          validPhrases++;
      }

      Console.WriteLine($"Looks like {validPhrases} of the {inputLines.Length} are valid...");
    }

    public static void Solve_Part2()
    {
      // 44, wrong
      // 208, right
      var inputLines = System.IO.File.ReadAllLines("Day04_Part1.txt"); 
      //var inputLines = new[]
      //{
      //  "abcde fghij", //v 
      //  "abcde xyz ecdab", //i
      //  "a ab abc abd abf abj", //v
      //  "iiii oiii ooii oooi oooo", //v
      //  "oiii ioii iioi iiio", //i
      //};
      var validPhrases = 0;

      foreach (var l in inputLines)
      {
        var words = l.Split(' ');
        var isValid = true;

        for (int i = 0; i < words.Length; i++)
        {
          for (int j = 0; j < words.Length; j++)
          {
            if (j == i)
              continue;
            if (words[j].Length != words[i].Length)
              continue;

            var word1chars = words[j].ToCharArray().ToList();
            var word2chars = words[i].ToCharArray().ToList();

            foreach (var word1char in word1chars)
            {
              if (word2chars.Contains(word1char))
                word2chars.Remove(word1char);
            }

            if (word2chars.Count == 0)
            {
              isValid = false;
              break;
            }
          }

          if (!isValid)
            break;
        }

        if (isValid)
          validPhrases++;
      }

      Console.WriteLine($"Looks like {validPhrases} of the {inputLines.Length} are valid...");
    }

  }
}
