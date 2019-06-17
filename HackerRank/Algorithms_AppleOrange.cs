using System;
using System.Linq;

namespace HackerRank
{
  class Algorithms_AppleOrange
  {
    public static void Solve()
    {
      var inp =
        "7 11\n" +
        "5 15\n" +
        "3 2\n" +
        "-2 2 1\n" +
        "5 -6";
      var lines = inp.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
      var st = lines[0];
      var s = int.Parse(st.Split(' ')[0]);
      var t = int.Parse(st.Split(' ')[1]);
      var ab = lines[1];
      var a = int.Parse(ab.Split(' ')[0]);
      var b = int.Parse(ab.Split(' ')[1]);
      var mn = lines[2];
      var m = int.Parse(mn.Split(' ')[0]);
      var n = int.Parse(mn.Split(' ')[1]);
      var ad = Array.ConvertAll(lines[3].Split(' '), adv => int.Parse(adv)).ToArray();
      var bd = Array.ConvertAll(lines[4].Split(' '), bdv => int.Parse(bdv)).ToArray();

      Algorithms_AppleOrange.countApplesAndOranges(s, t, a, b, ad, bd);
    }

    static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
    {
      var ac = 0;
      var oc = 0;

      foreach (var ad in apples)
      {
        var l = a + ad;
        if (l >= s && l <= t)
          ac++;
      }
      foreach (var od in oranges)
      {
        var l = b + od;
        if (l >= s && l <= t)
          oc++;
      }

      Console.WriteLine(ac);
      Console.WriteLine(oc);
    }

  }
}
