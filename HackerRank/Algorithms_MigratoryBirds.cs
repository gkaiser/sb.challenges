using System;
using System.Linq;
using System.Collections.Generic;


namespace HackerRank
{
  internal class Algorithms_MigratoryBirds
  {
    internal static void Solve()
    {
      Console.WriteLine(migratoryBirds(new List<int> { 1, 2, 3, 4, 5, 4, 3, 2, 1, 3, 4 }));
    }

    static int migratoryBirds(List<int> arr)
    {
      var c = 0;

      var dict = new Dictionary<int, int>();
      arr.Distinct().ToList().ForEach(i => dict.Add(i, 0));

      foreach (var i in arr)
      {
        dict[i]++;
      }

      var max = dict.Values.Max();
      var keys = dict.Keys.ToList();
      keys.Sort();

      foreach (var k in keys)
        if (dict[k] == max)
          return k;

      return c;
    }

  }
}