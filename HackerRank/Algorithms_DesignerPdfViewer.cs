using System;
using System.Linq;

namespace HackerRank
{
  internal class Algorithms_DesignerPdfViewer
  {
    internal static void Solve()
    {
      //var arr = new[] { 1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
      //var w = "abc";
      var arr = new[] { 1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7 };
      var w = "zaba";

      Console.WriteLine(designerPdfViewer(arr, w));
    }

    static int designerPdfViewer(int[] h, string word)
    {
      var mh = 0;
      for (int i = 0; i < word.Length; i++)
      {
        /*
        var wc = word[i];
        var ci = (int)wc;
        var ai = ci - 97;
        var ch = h[ai];
        */
        if (h[(int)word[i] - 97] > mh)
          mh = h[(int)word[i] - 97];
      }

      return mh * word.Length;
    }

  }
}