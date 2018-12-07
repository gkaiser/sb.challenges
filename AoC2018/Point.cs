using System;

namespace AoC2018
{
  public class Point
  {
    public int X;
    public int Y;

    public Point(int x, int y) { this.X = x; this.Y = y; }

    public override bool Equals(object obj) => obj != null && obj is Point && this.X == ((Point)obj).X && this.Y == ((Point)obj).Y;

    public override int GetHashCode() => unchecked(this.X ^ this.Y);

    public override string ToString() => $"{{{this.X}, {this.Y}}}";

    public int GetManhattanDistanceFromPoint(Point pDest)
    {
      return Math.Abs(pDest.X - this.X) + Math.Abs(pDest.Y - this.Y);
    }

  }

}
