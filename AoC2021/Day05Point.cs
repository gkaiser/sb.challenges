using System;

namespace AoC2021
{
  internal class Day05Point
  {
    public int X;
    public int Y;

    public Day05Point(int x, int y)
    {
      this.X = x;
      this.Y = y;
    }

    public override string ToString() => $"{this.X},{this.Y}";

    public override bool Equals(object obj)
    {
      if (obj == null || obj is not Day05Point pt)
        return false;

      return pt.X == this.X && pt.Y == this.Y;
    }

    public override int GetHashCode() => HashCode.Combine(this.X, this.Y);

    public Day05Point Copy() => new Day05Point(this.X, this.Y);
    

  }

}
