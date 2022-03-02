using System;
using System.Linq;
using System.Collections.Generic;


namespace AoC2021
{
  internal static class Day08
  {
    internal class Digit
    {
      internal static Digit D0 = new Digit(0, new List<string> { "aaaa", "bb", "cc", "ee", "ff", "gggg" });
      internal static Digit D1 = new Digit(1, new List<string> { "cc", "ff" });
      internal static Digit D2 = new Digit(2, new List<string> { "aaaa", "cc", "dddd", "ee", "gggg" });
      internal static Digit D3 = new Digit(3, new List<string> { "aaaa", "cc", "dddd", "ff", "gggg" });
      internal static Digit D4 = new Digit(4, new List<string> { "bb", "cc", "dddd", "ff" });
      internal static Digit D5 = new Digit(5, new List<string> { "aaaa", "bb", "dddd", "ff", "gggg" });
      internal static Digit D6 = new Digit(6, new List<string> { "aaaa", "bb", "dddd", "ee", "ff", "gggg" });
      internal static Digit D7 = new Digit(7, new List<string> { "aaaa", "cc", "ff" });
      internal static Digit D8 = new Digit(8, new List<string> { "aaaa", "bb", "cc", "dddd", "ee", "ff", "gggg" });
      internal static Digit D9 = new Digit(9, new List<string> { "aaaa", "bb", "cc", "dddd", "ff", "gggg" });

      internal int Num;
      internal List<string> Segments;

      private Digit(int n, List<string> s)
      {
        this.Num = n;
        this.Segments = s;
      }

      public static implicit operator Digit(string s)
      {
        if (string.IsNullOrWhiteSpace(s) || s.Length > 2)
          throw new ArgumentException($"Nah, bruv...");

        var d = (s.Length == 2 ? s.Substring(1) : s);
        switch (d)
        {
          case "0":
            return Digit.D0;
          case "1":
            return Digit.D0;
          case "2":
            return Digit.D0;
          case "3":
            return Digit.D0;
          case "4":
            return Digit.D0;
          case "5":
            return Digit.D0;
          case "6":
            return Digit.D0;
          case "7":
            return Digit.D0;
          case "8":
            return Digit.D0;
          case "9":
            return Digit.D0;
          default:
            throw new ArgumentException($"Nah, bruv...");
        }
      }

      public override string ToString() => $"{this.Num}";
    }

    internal static void SolvePart1()
    {
      var strLenToDigitMap = new Dictionary<int, int>
      {
        //strlen digit
        { 2,     1 },
        { 4,     4 },
        { 3,     7 },
        { 7,     8 },
      };

      //var inp = new[]
      //{
      //  "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
      //  "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
      //  "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
      //  "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
      //  "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
      //  "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
      //  "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
      //  "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
      //  "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
      //  "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce",
      //};
      var inp = System.IO.File.ReadAllLines("Day08.txt");

      var digitCounts = new Dictionary<int, int>
      {
        { 0, 0 },
        { 1, 0 },
        { 2, 0 },
        { 3, 0 },
        { 4, 0 },
        { 5, 0 },
        { 6, 0 },
        { 7, 0 },
        { 8, 0 },
        { 9, 0 },
      };

      foreach (var l in inp)
      {
        var ovs = l.Split('|').Last().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(d => d.Trim()).ToList();

        foreach (var ov in ovs)
        {
          if (strLenToDigitMap.ContainsKey(ov.Length))
            digitCounts[strLenToDigitMap[ov.Length]]++;
        }
      }

      foreach (var k in digitCounts.Keys)
      {
        Console.WriteLine($"{k} => {digitCounts[k]}");
      }

      Console.WriteLine($"Total use of 1, 4, 7, 8: {digitCounts[1] + digitCounts[4] + digitCounts[7] + digitCounts[8]}");
    }

    internal static void SolvePart2()
    {
      //var inp = new[]
      //{
      //  "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
      //  "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
      //  "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
      //  "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
      //  "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
      //  "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
      //  "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
      //  "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
      //  "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
      //  "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce",
      //};
      var inp = System.IO.File.ReadAllLines("Day08.txt");
      var sum = 0L;

      var sw = System.Diagnostics.Stopwatch.StartNew();

      foreach (var l in inp)
      {
        var patt = new List<string>();
        foreach (var p in l.Split(" | ")[0].Split(' '))
        {
          var pa = p.ToCharArray();

          Array.Sort(pa);

          patt.Add(new string(pa));
        }

        var outs = new List<string>();
        foreach (var o in l.Split(" | ")[1].Split(' '))
        {
          var oa = o.ToCharArray();

          Array.Sort(oa);

          outs.Add(new string(oa));
        }

        var oneStr = patt.Where(p => p.Length == 2).First();
        var fourStr = patt.Where(p => p.Length == 4).First();
        var sevenStr = patt.Where(p => p.Length == 3).First();
        var eightStr = patt.Where(p => p.Length == 7).First();

        var pattToDigitMap = new Dictionary<string, int>
        {
          { oneStr, 1 },
          { fourStr, 4 },
          { sevenStr, 7 },
          { eightStr, 8 },
        };

        // find the "fourL" characters that differentiate between 1 & 4
        var fourL = fourStr.Where(c => !oneStr.Contains(c)).ToArray();

        // this is 5 of 9's 6 characters. if we find a 6 character string
        // with all 5 of these characters, then we've found 9.
        var nineSearch = (fourStr + sevenStr).Distinct().ToArray();

        // find the pattern that is 6 chars in length, and that contains
        // all of the "nineSearch" characters
        var nineStr = patt.Where(p => p.Length == 6).Where(p => nineSearch.All(n => p.Contains(n))).First();
        pattToDigitMap.Add(nineStr, 9);

        // find the 5 character long pattern that contains BOTH of the 4's "L" characters
        var fiveStr = patt.Where(p => p.Length == 5).Where(p => fourL.All(f => p.Contains(f))).First();
        pattToDigitMap.Add(fiveStr, 5);

        // find the 3 pattern by looking for a 5 character long pattern that
        // contains both the characters in the 1-string
        var threeStr = patt.Where(p => p.Length == 5).Where(p => oneStr.All(o => p.Contains(o))).First();
        pattToDigitMap.Add(threeStr, 3);

        // the 2 pattern is 5 characters long and is the only 5 char long
        // pattern that isn't five and three
        var twoStr = patt.Where(p => p.Length == 5).Where(p => p != threeStr && p != fiveStr).First();
        pattToDigitMap.Add(twoStr, 2);

        // we should look about like this regarding numbers found:
        // X 1 2 3 4 5 X 7 8 9
        // so we're only missing 0 and 6 at this point

        // find the 0 pattern by looking for a 6 char long pattern where
        // it's not equal to the "nineStr", and contains both "oneStr" chars
        var zeroStr = patt.Where(p => p.Length == 6).Where(p => p != nineStr && oneStr.All(o => p.Contains(o))).First();
        pattToDigitMap.Add(zeroStr, 0);

        // find the 6 pattern by just looking for another 6 char long
        // pattern that's not equal to our nineStr or zeroStr values
        var sixStr = patt.Where(p => p.Length == 6).Where(p => p != nineStr && p != zeroStr).First();
        pattToDigitMap.Add(sixStr, 6);

        var ov = "";
        foreach (var o in outs)
          ov += $"{pattToDigitMap[o]}";

        sum += int.Parse(ov);
      }

      sw.Stop();

      Console.WriteLine($"Output of all values totals {sum} ({sw.Elapsed.GetFriendlyDuration()})...");
    }

  }
}
