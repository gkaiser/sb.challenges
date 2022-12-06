using System;
using System.Linq;

namespace AoC2022
{
  internal class Day06
  {
    private static string TestInput1 = "mjqjpqmgbljsphdztnvjfqwrcgsmlb";
    private static string TestInput2 = "bvwbjplbgvbhsrlpgdmjqwftvncz";
    private static string TestInput3 = "nppdvjthqldpwncqszvftbrmjlhg";
    private static string TestInput4 = "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg";
    private static string TestInput5 = "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw";

    internal static void SolvePart1()
    {
      //var inp = Day06.TestInput5;
      var inp = System.IO.File.ReadAllText("Day06.txt").Trim();

      for (int i = 0; i < inp.Length; i++)
      {
        var arr = inp.Substring(i, 4);
        var pairs = arr.GroupBy(x => x);

        if (pairs.All(p => p.Count() == 1))
        {
          // 1175
          Console.WriteLine($"Start-of-packet marker detected after the {i + 1 + 3}(th|nd|rd) character...");
          break;
        }
      }
    }

    internal static void SolvePart2()
    {
      //var inp = Day06.TestInput2;
      var inp = System.IO.File.ReadAllText("Day06.txt").Trim();

      for (int i = 0; i < inp.Length; i++)
      {
        var arr = inp.Substring(i, 14);
        var pairs = arr.GroupBy(x => x);

        if (pairs.All(p => p.Count() == 1))
        {
          // 3217
          Console.WriteLine($"Start-of-message marker detected after the {i + 1 + 13}(th|nd|rd) character...");
          break;
        }
      }
    }

  }
}