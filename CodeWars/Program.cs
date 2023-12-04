using System;

namespace CodeWars
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      //new List<string>
      //{
      //  "477 073 360",
      //  "5422 0148 5514",
      //  "8314 7046 0245",
      //  "6654 6310 43044",
      //  "0768 2757 5685 6340",
      //  "7164 6207 74042",
      //  "8383 7332 3570 8514",
      //  "481 135",
      //  "355 032 5363",
      //}.ForEach(ccv => Console.WriteLine($"{ccv} ==> {new ValidateCreditCardNumber().validate(ccv)}"));

      if (System.Diagnostics.Debugger.IsAttached)
      {
        Console.WriteLine();
        Console.Write("Done, press [ENTER] to quit... ");
        Console.ReadLine();
      }
    }

    private class ValidateCreditCardNumber
    {
      public bool validate(string n)
      {
        var c = n.Replace(" ", "");
        var v = new int[c.Length];

        for (int i = 0; i < c.Length; i++)
        {
          v[i] = c[i] - 0x30;

          if (c.Length % 2 == 0 && i % 2 == 0 && i != c.Length - 1)
            v[i] *= 2;
          if (c.Length % 2 == 1 && i % 2 == 1 && i != c.Length - 1)
            v[i] *= 2;

          if (v[i] > 9)
            v[i] = v[i] - 9;
        }

        var h = v.Sum();

        return h % 10 == 0;
      }
    }

    private class NotPrimeNumbers
    {
      private HashSet<int> Primes;


    }

  }

}