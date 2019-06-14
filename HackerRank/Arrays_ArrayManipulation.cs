using System;
using System.Linq;
using System.Collections.Generic;

namespace HackerRank
{
  class Arrays_ArrayManipulation
  {
    internal static void Solve()
    {
      var lines = System.IO.File.ReadAllLines(@"C:\Users\gkaiser\Documents\VS Projects\SB.Challenges\HackerRank\TestData\Crush\crush-testcases\input\test_case_7.txt");

      string[] nm = lines[0].Split(' ');
      int n = Convert.ToInt32(nm[0]);
      int m = Convert.ToInt32(nm[1]);
      int[][] queries = new int[m][];

      for (int i = 0; i < m; i++)
      {
        queries[i] = Array.ConvertAll(lines[i + 1].Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
      }

      var dtBeg = DateTime.Now;
      long result = arrayManipulation(n, queries);

      Console.WriteLine($"{result} is the max value; it took {DateTime.Now.Subtract(dtBeg)} to find it.");
    }

    static long arrayManipulation(int n, int[][] queries)
    {
      Console.WriteLine("Manipulating array...");

      /*
      var arr = new long[n];

      for (int i = 0; i < queries.Length; i++)
      {
        var opDat = queries[i];
        var idxL = opDat[0];
        var idxR = opDat[1];
        var summ = opDat[2];

        if (summ == 0)
          continue;

        for (int j = idxL - 1; j < idxR; j++)
          arr[j] += summ;
      }

      return arr.Max();
      */

      var fake = new SortedDictionary<int, long>();

      for (int i = 0; i < queries.Length; i++)
      {
        var ops = queries[i];
        var idxL = ops[0];
        var idxR = ops[1];
        var summ = ops[2];

        if (summ == 0)
          continue;

        if (!fake.ContainsKey(idxL))
          fake.Add(idxL, summ);
        else
          fake[idxL] += summ;

        if (idxR < n)
        {
          idxR++;
          if (!fake.ContainsKey(idxR))
            fake.Add(idxR, -1 * summ);
          else
            fake[idxR] -= summ;
        }
      }

      var max = 0l;
      var cur = 0l;

      foreach (var mod in fake.Values)
      {
        cur += mod;
        if (cur > max)
          max = cur;
      }

      return max;
    }
  }
}
