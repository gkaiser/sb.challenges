using System;

namespace HackerRank
{
  internal class Algorithms_DivisibleSumPairs
  {
    internal static void Solve()
    {
      var inp =
        "6 3\n" + 
        "1 3 2 6 1 2";

      var nk = inp.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)[0];
      var n = int.Parse(nk.Split(' ')[0]);
      var k = int.Parse(nk.Split(' ')[1]);
      var ar = Array.ConvertAll(inp.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' '), arv => int.Parse(arv));

      Console.WriteLine(divisibleSumPairs(n, k, ar));
    }

    private static int divisibleSumPairs(int n, int k, int[] ar)
    {
      var ct = 0;

      for (int i = 0; i < ar.Length; i++)
      {
        var vi = ar[i];
        for (int j = 0; j < ar.Length; j++)
        {
          if (j == i)
            continue;

          var vj = ar[j];

          if (i < j && (vi + vj) % k == 0)
            ct++;
        }
      }

      return ct;
    }

  }
}