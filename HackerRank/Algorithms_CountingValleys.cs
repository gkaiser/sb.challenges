using System;
using System.Linq;


namespace HackerRank
{
  internal class Algorithms_CountingValleys
  {
    internal static void Solve()
    {
      //Console.WriteLine(countingValleys(8, "UDDDUDUU"));
      Console.WriteLine(countingValleys(12, "DDUUDDUDUUUD"));
    }

    static int countingValleys(int n, string s)
    {
      // n = number of steps
      // s = path

      var lvl = 0;
      var vct = 0;
      var inv = false;

      for (int i = 0; i < s.Length; i++)
      {
        if (s[i] == 'U')
          lvl++;
        else if (s[i] == 'D')
          lvl--;

        if (lvl < 0 && !inv)
        {
          inv = true;
          vct++;
        }
        if (lvl >= 0 && inv)
          inv = false;
      }

      return vct;
    }

  }
}