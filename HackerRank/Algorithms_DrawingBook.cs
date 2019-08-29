using System;
using System.Linq;
using System.Collections.Generic;

namespace HackerRank
{
  internal class Algorithms_DrawingBook
  {
    internal static void Solve()
    {
      //Console.WriteLine(pageCount(6, 2));
      //Console.WriteLine(pageCount(5, 4));
      //Console.WriteLine(pageCount(7, 4));
      //Console.WriteLine(pageCount(95073, 17440));
      //Console.WriteLine(pageCount(6, 5));
    }

    static int pageCount(int n, int p)
    {
      // n = pages in book
      // p = page to turn to 

      return Math.Min(p / 2, n / 2 - p / 2);

      var visf = new List<int> { 1 };
      var visb = new List<int> { n - 1, n };

      if (visf.Contains(p) || visb.Contains(p))
        return 0;

      for (int i = 1; ; i++)
      {
        visf = (i == 1 ? new List<int> { 2, 3 } : new List<int> { visf[0] + 2, visf[1] + 2 });
        visb = new List<int> { visb[0] - 2, visb[1] - 2 };

        if (visf.Contains(p) || visb.Contains(p))
          return i;
      }
    }

  }
}