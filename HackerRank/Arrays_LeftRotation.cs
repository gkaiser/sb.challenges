using System;

namespace HackerRank
{
  class Arrays_LeftRotation
  {
    public static void Solve()
    {
      var inp =
        "5 4\n" +
        "1 2 3 4 5";
      var lines = inp.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
      var nd = lines[0].Split(' ');
      var n = int.Parse(nd[0]);
      var d = int.Parse(nd[1]);
      int[] a = Array.ConvertAll(lines[1].Split(' '), aTemp => Convert.ToInt32(aTemp));

      var dest = new int[a.Length];

      Array.ConstrainedCopy(a, d, dest, 0, a.Length - d);
      Array.ConstrainedCopy(a, 0, dest, a.Length - d, d);

      Console.WriteLine(string.Join(" ", dest));
    }

  }
}
