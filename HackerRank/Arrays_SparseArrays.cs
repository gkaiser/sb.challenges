using System;
using System.Collections.Generic;

namespace HackerRank
{
  class Arrays_SparseArrays
  {
    public static void Solve()
    {
      var inp =
        "13\n" +
        "abcde\n" +
        "sdaklfj\n" +
        "asdjf\n" +
        "na\n" +
        "basdn\n" +
        "sdaklfj\n" +
        "asdjf\n" +
        "na\n" +
        "asdjf\n" +
        "na\n" +
        "basdn\n" +
        "sdaklfj\n" +
        "asdjf\n" +
        "5\n" +
        "abcde\n" +
        "sdaklfj\n" +
        "asdjf\n" +
        "na\n" +
        "basdn";
      var lines = inp.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

      var readIdx = 0;
      int stringsCount = Convert.ToInt32(lines[readIdx]);
      readIdx++;

      string[] strings = new string[stringsCount];

      for (int i = 0; i < stringsCount; i++)
      {
        string stringsItem = lines[i + readIdx];
        strings[i] = stringsItem;
      }
      readIdx += stringsCount;

      int queriesCount = Convert.ToInt32(lines[readIdx]);
      readIdx++;

      string[] queries = new string [queriesCount];

      for (int i = 0; i < queriesCount; i++)
      {
        string queriesItem = lines[i + readIdx];
        queries[i] = queriesItem;
      }

      int[] res = matchingStrings(strings, queries);

      Console.WriteLine(string.Join("\n", res));
    }

    static int[] matchingStrings(string[] strings, string[] queries)
    {
      var qc = new int[queries.Length];
      var ds = new Dictionary<string, int>();

      foreach (var s in strings)
      {
        if (!ds.ContainsKey(s))
          ds.Add(s, 0);
        ds[s]++;
      }
      for (int i = 0; i < queries.Length; i++)
      {
        var q = queries[i];

        if (ds.ContainsKey(q))
          qc[i] += ds[q];
      }

      return qc;
    }

  }
}
