using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
  internal static class Day08
  {
    internal static List<string> Input = new List<string>(System.IO.File.ReadAllLines("08.txt"));

    internal static void Process(bool runPart1)
    {
      Console.WriteLine("Day 8");

      if (runPart1)
        Day08.Part1();
      else
        Day08.Part2();
    }

    private static void Part1()
    {
      var escChars = 0;
      for (int i = 0; i < Day08.Input.Count; i++)
      {
        var l = Day08.Input[i].Substring(1, Day08.Input[i].Length -  2);
        var esc = new StringBuilder();
        for (int j = 0; j < l.Length; j++)
        {
          if (l[j] != '\\')
          {
            esc.Append(l[j]);
            continue;
          }

          if (l[j + 1] == '\\')
            esc.Append("\\");
          else if (l[j + 1] == '"')
            esc.Append("\"");
          else if (l[j + 1] == 'x')
          {
            // test if this is a valid hex string
            var hex = int.Parse(l.Substring(j + 2, 2), System.Globalization.NumberStyles.HexNumber);
            var ltr = System.Text.Encoding.ASCII.GetString(new[] { (byte)hex });
            esc.Append(ltr);
            j += 2;
          }

          j++;
        }

        escChars += esc.Length;
      }

      var totChars = Day08.Input.Sum(s => s.Length);

      Console.WriteLine(
        "  " + 
        "Santa's list is a total of " + totChars + " code-characters, and " + escChars + " in-memory-characters. " + 
        "So the answer is " + (totChars - escChars) + ".");

      // wrong:
      //   4860 high - HAHAHA, I DIDNT READ THE QUESTION  (╯°□°)╯︵ ┻━┻
    }

    private static void Part2()
    {
      var encChars = 0;
      for (int i = 0; i < Day08.Input.Count; i++)
      {
        var l = Day08.Input[i];
        var enc = new StringBuilder("\"");
        for (int j = 0; j < l.Length; j++)
        {
          if (l[j] == '\\')
          {
            enc.Append("\\\\");
            continue;
          }
          if (l[j] == '"')
          {
            enc.Append("\\\"");
            continue;
          }

          enc.Append(l[j]);
        }

        enc.Append("\"");

        encChars += enc.Length;
      }

      var totChars = Day08.Input.Sum(s => s.Length);

      Console.WriteLine(
        "  " +
        "Santa's list is a total of " + totChars + " code-characters, and " + encChars + " encoded characters. " +
        "So the answer is " + (encChars - totChars) + ".");

      // correct:
      //   2074
    }

  }
}