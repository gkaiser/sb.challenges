using System;
using System.Linq;
using System.Collections.Generic;

namespace HackerRank
{
  internal class Algorithms_SockMerchant
  {
    internal static void Solve()
    {
      //Console.WriteLine(sockMerchant(7, new[] { 1, 2, 1, 2, 1, 3, 2 }));
      Console.WriteLine(sockMerchant(9, new[] { 10, 20, 20, 10, 10, 30, 50, 10, 20 }));
    }

    static int sockMerchant(int n, int[] ar)
    {
      var pairs = 0;
      var dict = new Dictionary<int, int>();

      ar.Distinct().ToList().ForEach(c => dict.Add(c, 0));

      foreach (var c in ar)
        dict[c]++;

      foreach (var c in dict.Keys)
        if (dict[c] > 1)
          pairs += dict[c] / 2;

      return pairs;
    }

  }
}