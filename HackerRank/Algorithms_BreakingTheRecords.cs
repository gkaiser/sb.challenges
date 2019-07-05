using System;

namespace HackerRank
{
  internal class Algorithms_BreakingTheRecords
  {
    internal static void Solve()
    {
      var inp =
        "9\n" +
        "10 5 20 20 4 5 2 25 1";

      var scores = Array.ConvertAll("3 4 21 36 10 28 35 5 24 42".Split(' '), arv => int.Parse(arv));
      var ret = breakingRecords(scores);

      Console.WriteLine(string.Join(" ", ret));
    }

    private static int[] breakingRecords(int[] scores)
    {
      var min = 0;
      var max = 0;
      var mc = new int[2];

      for (int i = 0; i < scores.Length; i++)
      {
        var s = scores[i];
        if (i == 0)
        {
          max = min = s;
          continue;
        }

        if (s > max)
        {
          max = s;
          mc[0]++;
        }
        if (s < min)
        {
          min = s;
          mc[1]++;
        }
      }

      return mc;
    }

  }
}