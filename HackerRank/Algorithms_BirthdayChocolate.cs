using System;
using System.Linq;
using System.Collections.Generic;

namespace HackerRank
{
  internal class Algorithms_BirthdayChocolate
  {
    internal static void Solve()
    {
      //Console.WriteLine(birthday(new List<int> { 1, 2, 1, 3, 2 }, 3, 2));
      //Console.WriteLine(birthday(new List<int> { 4 }, 4, 1));
      Console.WriteLine(birthday(new List<int> { 2, 5, 1, 3, 4, 4, 3, 5, 1, 1, 2, 1, 4, 1, 3, 3, 4, 2, 1 }, 18, 7));
    }

    static int birthday(List<int> s, int d, int m)
    {
      var c = 0;

      for (int i = 0; i < s.Count; i++)
      {
        if (i + m > s.Count())
          break;

        if (m == 1 && s[i] == d)
          c++;
        else if (s.GetRange(i, m).Sum() == d)
          c++;
      }

      return c;
    }

  }
}