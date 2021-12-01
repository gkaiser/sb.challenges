using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
  public partial class Solutions
  {
    public static void P018()
    {
      var tri = new int[][]
      {
        //new int[] { 3, },
        //new int[] { 7, 4, }, 
        //new int[] { 2, 4, 6, },
        //new int[] { 8, 5, 9, 3, },

        new[] { 75, },
        new[] { 95, 64, },
        new[] { 17, 47, 82, },
        new[] { 18, 35, 87, 10, },
        new[] { 20, 04, 82, 47, 65, },
        new[] { 19, 01, 23, 75, 03, 34, },
        new[] { 88, 02, 77, 73, 07, 63, 67, },
        new[] { 99, 65, 04, 28, 06, 16, 70, 92, },
        new[] { 41, 41, 26, 56, 83, 40, 80, 70, 33, },
        new[] { 41, 48, 72, 33, 47, 32, 37, 16, 94, 29, },
        new[] { 53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14, },
        new[] { 70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57, },
        new[] { 91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48, },
        new[] { 63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31, },
        new[] { 04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23, },
      };

      var vals = new List<int>();
      var midx = -1;

      for (int i = 0; i < tri.Length; i++)
      {
        var canTest = (midx == -1 ? new[] { 0 } : new[] { midx, midx + 1});

        if (tri[i].Length == 1)
        {
          vals.Add(tri[i][0]);
          midx = 0;
        }
        else if (tri[i][canTest[0]] > tri[i][canTest[1]])
        {
          vals.Add(tri[i][canTest[0]]);
          midx = canTest[0];
        }
        else
        {
          vals.Add(tri[i][canTest[1]]);
          midx = canTest[1];
        }
        
        Console.WriteLine($"{i:00} ==> {vals.Last()}");
      }

      Console.WriteLine($"Sum: {vals.Sum()}");
    }

    public static void P018_MathBlogDk()
    {
      var tri = new int[][]
      {
        //new int[] { 3, },
        //new int[] { 7, 4, }, 
        //new int[] { 2, 4, 6, },
        //new int[] { 8, 5, 9, 3, },

        new[] { 75, },
        new[] { 95, 64, },
        new[] { 17, 47, 82, },
        new[] { 18, 35, 87, 10, },
        new[] { 20, 04, 82, 47, 65, },
        new[] { 19, 01, 23, 75, 03, 34, },
        new[] { 88, 02, 77, 73, 07, 63, 67, },
        new[] { 99, 65, 04, 28, 06, 16, 70, 92, },
        new[] { 41, 41, 26, 56, 83, 40, 80, 70, 33, },
        new[] { 41, 48, 72, 33, 47, 32, 37, 16, 94, 29, },
        new[] { 53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14, },
        new[] { 70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57, },
        new[] { 91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48, },
        new[] { 63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31, },
        new[] { 04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23, },
      };
      var rows = tri.Length;
      var vals = new int[rows];

      for (int i = 0; i < rows; i++)
      {
        vals[i] = tri[rows - 1][i];
      }

      for (int i = rows - 2; i >= 0; i--)
      {
        for (int j = 0; j <= i; j++)
        {
          vals[j] = tri[i][j] + Math.Max(vals[j], vals[j + 1]);
        }
      }

      Console.WriteLine(vals[0]);
    }

  }
}
