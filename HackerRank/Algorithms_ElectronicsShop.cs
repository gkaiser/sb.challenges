using System;
using System.Linq;

namespace HackerRank
{
  internal class Algorithms_ElectronicsShop
  {
    internal static void Solve()
    {
      
    }

    static int getMoneySpent(int[] keyboards, int[] drives, int b)
    {
      var m = 0;

      for (int i = 0; i < keyboards.Length; i++)
      {
        if (keyboards[i] > b)
          continue;

        for (int j = 0; j < drives.Length; j++)
        {
          if (drives[j] > b)
            continue;

          var p = keyboards[i] + drives[j];

          if (p > b)
            continue;
          if (p > m)
            m = p;
        }
      }

      return (m > 0 ? m : -1);
    }

  }
}