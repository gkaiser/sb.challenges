using System;
using System.Linq;

namespace AoC2023
{
  internal class Pt
  {
    public int X;
    public int Y;

    public Pt(int x, int y)
    {
      this.X = x;
      this.Y = y;
    }

    public override string ToString() => $"{this.X}, {this.Y}";

    public static bool operator ==(Pt p1, Pt p2)
    {
      if (object.ReferenceEquals(p1, p2))
        return true;
      if (p1 is null || p2 is null)
        return false;

      return p1.X == p2.X && p1.Y == p2.Y;
    }

    public static bool operator !=(Pt p1, Pt p2) => !(p1 == p2);

    public override bool Equals(object? obj) => this == (obj as Pt);

    public override int GetHashCode()
    {
      unchecked
      {
        var hc = 1455329;
        hc = hc * 2235067 ^ this.X.GetHashCode();
        hc = hc * 2235067 ^ this.Y.GetHashCode();
        return hc;
      }
    }

  }
}
