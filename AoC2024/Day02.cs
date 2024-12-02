using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2024
{
  internal static class Day02
  {
    internal static void SolvePart1()
    {
      var inp = System.IO.File.ReadAllLines("Day02.txt");
      var reports = inp.Select(il => il).Select(lv => lv.Split(' ').Select(int.Parse).ToArray()).ToList();
      var safeCt = 0;

      foreach (var rpt in reports)
      {
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
              break;
            }
          }

          if (arrSafe)
            safeCt++;
        }
      }

      Console.WriteLine(safeCt);
    }

    internal static void SolvePart2()
    {
      var inp = System.IO.File.ReadAllLines("Day02.txt");
      var reports = inp.Select(il => il).Select(lv => lv.Split(' ').Select(int.Parse).ToArray()).ToList();
      var safeCt = 0;

      foreach (var rpt in reports)
      {
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
            safeCt++;
          
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
      var testArr = new int[arr.Length];

      Array.Copy(arr, testArr, arr.Length);
      Array.Sort(testArr);

      if (Day02.ArraysEqual(testArr, arr))
        return true;

      Array.Reverse(testArr);

      return Day02.ArraysEqual(testArr, arr);
    }

    private static bool ArraysEqual(int[] a1, int[] a2)
    {
      if (a1 == null || a2 == null || a1.Length != a2.Length)
        return false;

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
