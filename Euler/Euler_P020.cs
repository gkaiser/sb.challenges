using System;
using System.Numerics;

namespace Euler
{
  public partial class Solutions
  {
    public static void P020()
    {
      BigInteger val = 100;

      for (var i = val - 1; i > 0; i--)
      {
        val *= i;
      }

      var sum = 0;
      foreach (var c in $"{val}")
      {
        sum += int.Parse($"{c}");
      }

      Console.WriteLine($"The sum of the digits in 100! is {sum}.");
    }

  }
}
