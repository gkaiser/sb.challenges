using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.LogoInterpreter
{
  internal static class Extensions
  {
    public static System.Drawing.Rectangle ToRectangle(this System.Drawing.RectangleF rf)
    {
      return new System.Drawing.Rectangle((int)rf.X, (int)rf.Y, (int)rf.Width, (int)rf.Height);
    }

    public static Turtle.Command ToCommand(this string s)
    {
      return Turtle.CommandList.FirstOrDefault(c => c.Names.Contains(s.Trim().ToLower()));
    }

    public static double ToRads(this int a)
    {
      var r = (Math.PI / 180) * a;

      System.Diagnostics.Debug.WriteLine($"ToRads: {a} ==> {r}");

      return r;
    }

  }
}
