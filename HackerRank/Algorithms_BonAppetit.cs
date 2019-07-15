using System;
using System.Linq;
using System.Collections.Generic;

namespace HackerRank
{
  internal class Algorithms_BonAppetit
  {
    internal static void Solve()
    {
      //bonAppetit(new[] { 2, 4, 6 }.ToList(), 2, 3);
      bonAppetit(new[] { 3, 10, 2, 9 }.ToList(), 1, 12);
    }

    static void bonAppetit(List<int> bill, int k, int b)
    {
      var tot = bill.Sum() - bill[k];
      var split = tot / 2;

      if (split == b)
        Console.WriteLine("Bon Appetit");
      else
        Console.WriteLine((bill.Sum() / 2) - split);
    }

  }
}