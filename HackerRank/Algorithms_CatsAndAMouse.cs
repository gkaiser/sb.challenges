using System;
using System.Linq;

namespace HackerRank
{
  internal class Algorithms_CatsAndAMouse
  {
    internal static void Solve()
    {

    }

    static string catAndMouse(int x, int y, int z)
    {
      // x = cat a posn
      // y = cat b posn
      // z = mouse posn

      if (Math.Abs(z - x) < Math.Abs(z - y))
        return "Cat A";
      if (Math.Abs(z - y) < Math.Abs(z - x))
        return "Cat B";

      return "Mouse C";
    }

  }
}