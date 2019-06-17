using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  class Algorithms_Kangaroo
  {
    public static void Solve()
    {
      //var inp = "0 3 4 2";
      //var inp = "0 2 5 3";
      var inp = "21 6 47 3";
      var vals = inp.Split(' ');
      var x1 = int.Parse(vals[0]);
      var v1 = int.Parse(vals[1]);
      var x2 = int.Parse(vals[2]);
      var v2 = int.Parse(vals[3]);

      Console.WriteLine(kangaroo(x1, v1, x2, v2));
    }

    static string kangaroo(int x1, int v1, int x2, int v2)
    {
      var x1p = (long)x1;
      var x2p = (long)x2;

      if (x2p > x1p && v2 > v1)
        return "NO";
      
      for (int i = 0; i < int.MaxValue; i++)
      {
        if (x1p == x2p)
          return "YES";
        if (x1p + v1 >= int.MaxValue || x2p + v2 >= int.MaxValue)
          return "NO";

        x1p += v1;
        x2p += v2;
      }

      return "NO";
    }

  }
}
