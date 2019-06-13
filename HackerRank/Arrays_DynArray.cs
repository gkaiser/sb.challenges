using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal static class Arrays_DynArray
  {
    public static void Solve()
    {
      var inp =
        "2 5\n" +
        "1 0 5\n" +
        "1 1 7\n" +
        "1 0 3\n" +
        "2 1 0\n" +
        "2 1 1";
      var lines = inp.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
      var nq = lines[0].Split(' ');
      var n = int.Parse(nq[0]);
      var q = int.Parse(nq[1]);
      var queries = new List<List<int>>();

      for (int i = 1; i <= q; i++)
      {
        queries.Add(lines[i].TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
      }

      var result = dynamicArray(n, queries);

      Console.WriteLine(String.Join("\n", result));
    }

    static List<int> dynamicArray(int n, List<List<int>> queries)
    {
      var seq = new List<List<int>>();
      for (int i = 0; i < n; i++)
        seq.Add(new List<int>());

      var res = new List<int>();
      var last = 0;

      foreach (var q in queries)
      {
        var t = q[0];
        var x = q[1];
        var y = q[2];

        if (t == 1)
        {
          var seqIdx = (x ^ last) % n;
          var s = seq[seqIdx];
          s.Add(y);
        }
        if (t == 2)
        {
          var seqIdx = (x ^ last) % n;
          var s = seq[seqIdx];
          var sv = s[y % s.Count];
          last = sv;

          res.Add(last);
        }
      }

      return res;
    }

  }
}
