using System;

namespace AoC2017
{
  internal static class Day01
  {
    internal static void Solve_Part1()
    {
      //var input = "1122";
      //var input = "1111";
      //var input = "1234";
      //var input = "91212129";
      var input = System.IO.File.ReadAllText("Day01_Part1.txt"); /* 1216 */

      var sum = 0;

      for (int i = 0; i < input.Length; i++)
      {
        var digit = int.Parse(input[i].ToString());

        if (i == input.Length - 1)
          sum += (digit == int.Parse(input[0].ToString()) ? digit : 0);
        else if (digit == int.Parse(input[i + 1].ToString()))
          sum += digit;
      }

      Console.WriteLine($"The solution to captcha \"{input}\" is {sum}");
    }

    internal static void Solve_Part2()
    {
      //var input = "1212";
      //var input = "1221";
      //var input = "123425";
      //var input = "123123";
      //var input = "12131415";
      var input = System.IO.File.ReadAllText("Day01_Part1.txt");

      var sum = 0;
      var jumpCt = input.Length / 2;

      for (int i = 0; i < input.Length; i++)
      {
        var digit = int.Parse(input[i].ToString());

        if (i + jumpCt < input.Length)
          if (digit == int.Parse(input[i + jumpCt].ToString()))
            sum += digit;
        if (i + jumpCt >= input.Length)
          if (digit == int.Parse(input[i - jumpCt].ToString()))
          sum += digit;
      }

      Console.WriteLine($"The solution to captcha \"{input}\" is {sum}");
    }

  }
}
