using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode
{
  internal static class Day05
  {
    internal static List<string> Input = new List<string>(System.IO.File.ReadAllLines("05.txt"));

    internal static void Process(bool runPart1)
    {
      Console.WriteLine("Day 5 - Part " + (runPart1 ? 1 : 2));

      if (runPart1)
        Day05.Part1();
      else
        Day05.Part2();
    }

    private static void Part1()
    {
      var vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
      var disallowed = new List<string> { "ab", "cd", "pq", "xy" };
      var nice = 0;

      foreach (string s in Day05.Input)
      {
        // if not at least 3 chars long then we can't have 3 vowels
        if (s.Length < 3)
          continue;

        // check for any disallowed strings
        bool foundDisallowed = false;
        for (int i = 0; i < disallowed.Count; i++)
        {
          if (s.IndexOf(disallowed[i]) != -1)
          {
            foundDisallowed = true;
            break;
          }
        }
        if (foundDisallowed)
          continue;

        // check that we can find at least 3 vowels
        if (s.Where(c => vowels.Contains(c)).Count() < 3)
          continue;

        // look for dupe-chars
        bool foundDupe = false;
        for (int i = 0; i < s.Length; i++)
        {
          if (i != s.Length - 1 && s[i] == s[i + 1])
          {
            foundDupe = true;
            break;
          }
        }

        if (!foundDupe)
          continue;

        nice++;
      }

      Console.WriteLine("  Santa's list contains " + nice + " nice strings (out of " + Day05.Input.Count + " strings)...");

      // wrong:
      //   269 high (pt1)
      // correct:
      //   255 (pt1)    
    }

    private static void Part2()
    {
      var nice = 0;

      foreach (string s in Day05.Input)
      {
        // shorter than 4 doesn't allow a letter-pair repeating
        if (s.Length < 4)
          continue;

        // check for repeating w/ 1 off inbetween
        bool foundRepeating = false;
        for (int i = 0; i < s.Length; i++)
        {
          if (i < s.Length - 2 && s[i] == s[i + 2])
          {
            foundRepeating = true;
            break;
          }
        }
        if (!foundRepeating)
          continue;

        bool foundTwoPairs = false;
        for (int i = 0; i < s.Length; i++)
        {
          if (i > s.Length - 4)
            break;

          var pair = s.Substring(i, 2);
          if (s.IndexOf(pair, i + 2) != -1)
          {
            foundTwoPairs = true;
            break;
          }
        }
        if (!foundTwoPairs)
          continue;

        nice++;
      }

      Console.WriteLine("  Santa's list contains " + nice + " nice strings (out of " + Day05.Input.Count + " strings)...");
    }

  }
}
