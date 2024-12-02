using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024
{
  internal static class Day02
  {
    internal static void SolvePart1()
    {
      //var inp = new[]
      //{
      //  "7 6 4 2 1",
      //  "1 2 7 8 9",
      //  "9 7 6 2 1",
      //  "1 3 2 4 5",
      //  "8 6 4 4 1",
      //  "1 3 6 7 9",
      //};
      var inp = System.IO.File.ReadAllLines("Day02.txt");

      var reports = new List<int[]>();
      foreach (var l in inp)
      {
        var arr = l.Split(' ').Select(int.Parse).ToArray();

        reports.Add(arr);
      }

      var safeCt = 0;
      foreach (var rpt in reports)
      {
        var sortedLowToHigh = new int[rpt.Length];
        var sortedHighToLow = new int[rpt.Length];

        Array.Copy(rpt, sortedLowToHigh, rpt.Length);
        Array.Copy(rpt, sortedHighToLow, rpt.Length);
        
        Array.Sort(sortedHighToLow);
        Array.Copy(sortedHighToLow, sortedLowToHigh, rpt.Length);
        Array.Reverse(sortedLowToHigh);

        var arrSafe = Day02.ArraysEqual(sortedHighToLow, rpt) || Day02.ArraysEqual(sortedLowToHigh, rpt);
        if (arrSafe)
        {
          // possibly safe, now check distances
          for (int i = 0; i < rpt.Length; i++)
          {
            if (i == rpt.Length - 1)
              break;

            var gap = Math.Abs(rpt[i] - rpt[i + 1]);
            if (gap < 1 || gap > 3)
            {
              arrSafe = false;
              break;
            }
            if (!arrSafe)
              break;
          }
        }

        if (arrSafe)
          safeCt++;
      }

      Console.WriteLine(safeCt);
    }

    internal static void SolvePart2()
    {
      //var inp = new[]
      //{
      //  "7 6 4 2 1",
      //  "1 2 7 8 9",
      //  "9 7 6 2 1",
      //  "1 3 2 4 5",
      //  "8 6 4 4 1",
      //  "1 3 6 7 9",
      //};
      var inp = System.IO.File.ReadAllLines("Day02.txt");

      var reports = new List<int[]>();
      foreach (var l in inp)
      {
        var arr = l.Split(' ').Select(int.Parse).ToArray();

        reports.Add(arr);
      }

      var safeCt = 0;
      foreach (var rpt in reports)
      {
        var sortedLowToHigh = new int[rpt.Length];
        var sortedHighToLow = new int[rpt.Length];

        Array.Copy(rpt, sortedLowToHigh, rpt.Length);
        Array.Sort(sortedLowToHigh);

        Array.Copy(sortedLowToHigh, sortedHighToLow, rpt.Length);
        Array.Reverse(sortedHighToLow);

        // if array is sorted and does not contain duplicates...
        if (Day02.ArrayIsSorted(rpt) && !Day02.ArrayContainsDupes(rpt))
        {
          var arrSafe = true;

          // possibly safe, now check distances
          for (int i = 0; i < rpt.Length; i++)
          {
            if (i == rpt.Length - 1)
              break;

            var gap = Math.Abs(rpt[i] - rpt[i + 1]);
            if (gap < 1 || gap > 3)
            {
              arrSafe = false;
              goto tryRemoveElement;
            }
          }

          if (arrSafe)
          {
            //Console.WriteLine($"{string.Join(", ", rpt)} is safe.");
            safeCt++;
          }

          continue;
        }

        tryRemoveElement:
        // find out if we can remove an element to make the array legit
        for (int i = 0; i < rpt.Length; i++)
        {
          var newLst = new List<int>(rpt.Where((item, index) => index != i));

          var newArr = newLst.ToArray();
          if (!Day02.ArrayIsSorted(newArr))
            continue;
          if (Day02.ArrayContainsDupes(newArr))
            continue;

          var arrSafe = true;

          for (int j = 0; j < newArr.Length; j++)
          {
            if (j == newArr.Length - 1)
              break;

            var gap = Math.Abs(newArr[j] - newArr[j + 1]);
            if (gap < 1 || gap > 3)
            {
              arrSafe = false;
              break;
            }
          }

          if (arrSafe)
          {
            safeCt++;
            break;
          }
        }
      }

      // 753 too high
      // 688 too high
      // 535 too low
      // 536 CORRECT

      Console.WriteLine($"{safeCt}");
    }

    private static bool ArrayIsSorted(int[] arr)
    {
      var lowToHigh = new int[arr.Length];
      var highToLow = new int[arr.Length];

      Array.Copy(arr, lowToHigh, arr.Length);
      Array.Sort(lowToHigh);

      Array.Copy(lowToHigh, highToLow, arr.Length);
      Array.Reverse(highToLow);

      return (Day02.ArraysEqual(arr, lowToHigh) || Day02.ArraysEqual(arr, highToLow));
    }

    private static bool ArraysEqual(int[] a1, int[] a2)
    {
      for (int i = 0; i < a1.Length; i++)
      {
        if (a1[i] != a2[i])
          return false;
      }

      return true;
    }

    private static bool ArrayContainsDupes(int[] arr)
    {
      var dict = new Dictionary<int, int>();

      foreach (var e in arr)
      {
        if (!dict.ContainsKey(e))
          dict.Add(e, 0);

        dict[e]++;
      }

      foreach (var k in dict.Keys)
        if (dict[k] > 1)
          return true;

      return false;
    }

  }
}
