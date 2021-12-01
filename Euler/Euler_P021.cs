using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
  public partial class Solutions
  {
    public static void P021()
    {
      var n = 284;
      var d = new List<int>();

      for (int i = n - 1; i > 0; i--)
      {
        if (n % i == 0)
          d.Add(i);
      }

      Console.WriteLine($"{string.Join(", ", d)} ({d.Sum()})");
    }

  }
}
