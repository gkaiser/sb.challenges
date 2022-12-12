using System;
using System.Linq;

namespace AoC2022
{
  internal class Day10
  {
    private static string[] TestInput1 = new[]
    {
      "noop",
      "addx 3",
      "addx -5",
    };
    private static string[] TestInput2 = new[]
    {
      "addx 15",
      "addx -11",
      "addx 6",
      "addx -3",
      "addx 5",
      "addx -1",
      "addx -8",
      "addx 13",
      "addx 4",
      "noop",
      "addx -1",
      "addx 5",
      "addx -1",
      "addx 5",
      "addx -1",
      "addx 5",
      "addx -1",
      "addx 5",
      "addx -1",
      "addx -35",
      "addx 1",
      "addx 24",
      "addx -19",
      "addx 1",
      "addx 16",
      "addx -11",
      "noop",
      "noop",
      "addx 21",
      "addx -15",
      "noop",
      "noop",
      "addx -3",
      "addx 9",
      "addx 1",
      "addx -3",
      "addx 8",
      "addx 1",
      "addx 5",
      "noop",
      "noop",
      "noop",
      "noop",
      "noop",
      "addx -36",
      "noop",
      "addx 1",
      "addx 7",
      "noop",
      "noop",
      "noop",
      "addx 2",
      "addx 6",
      "noop",
      "noop",
      "noop",
      "noop",
      "noop",
      "addx 1",
      "noop",
      "noop",
      "addx 7",
      "addx 1",
      "noop",
      "addx -13",
      "addx 13",
      "addx 7",
      "noop",
      "addx 1",
      "addx -33",
      "noop",
      "noop",
      "noop",
      "addx 2",
      "noop",
      "noop",
      "noop",
      "addx 8",
      "noop",
      "addx -1",
      "addx 2",
      "addx 1",
      "noop",
      "addx 17",
      "addx -9",
      "addx 1",
      "addx 1",
      "addx -3",
      "addx 11",
      "noop",
      "noop",
      "addx 1",
      "noop",
      "addx 1",
      "noop",
      "noop",
      "addx -13",
      "addx -19",
      "addx 1",
      "addx 3",
      "addx 26",
      "addx -30",
      "addx 12",
      "addx -1",
      "addx 3",
      "addx 1",
      "noop",
      "noop",
      "noop",
      "addx -9",
      "addx 18",
      "addx 1",
      "addx 2",
      "noop",
      "noop",
      "addx 9",
      "noop",
      "noop",
      "noop",
      "addx -1",
      "addx 2",
      "addx -37",
      "addx 1",
      "addx 3",
      "noop",
      "addx 15",
      "addx -21",
      "addx 22",
      "addx -6",
      "addx 1",
      "noop",
      "addx 2",
      "addx 1",
      "noop",
      "addx -10",
      "noop",
      "noop",
      "addx 20",
      "addx 1",
      "addx 2",
      "addx 2",
      "addx -6",
      "addx -11",
      "noop",
      "noop",
      "noop",
    };

    internal static void SolvePart1()
    {
      //var inp = Day10.TestInput1.ToList();
      //var inp = Day10.TestInput2.ToList();
      var inp = System.IO.File.ReadAllLines(@"Day10.txt").ToList();
      var enm = inp.GetEnumerator();

      var register = 1;
      var cycle = 0;

      //var obsCycles = new[] { 
      //  18, 19, 20, 21, 22,
      //  58, 59, 60, 61, 62, 
      //  98, 99, 100, 101, 102, 
      //  138, 139, 140, 141, 142, 
      //  178, 179, 180, 181, 182, 
      //  218, 219, 220, 221, 222 };
      var obsCycles = new[] { 20, 60, 100, 140, 180, 220 };
      var clst = "";
      var clen = 0;
      var ss = 0;

      for (int i = 0; ; i++)
      {
        if (i > obsCycles.Max())
          break;
        if (obsCycles.Contains(i))
        {
          Console.WriteLine($"Cycle: {i:000} X: {register}");

          ss += i * register;
        }

        if (clen != 0)
        {
          clen--;
          continue;
        }
        if (clen == 0)
        {
          if (clst.StartsWith("addx "))
            register += int.Parse(clst.Split(' ')[1]);
        }

        if (!enm.MoveNext())
        {
          enm = inp.GetEnumerator();
          enm.MoveNext();
        }

        clst = enm.Current;
        if (clst.StartsWith("noop"))
          clen = 0;
        else
          clen = 1;
      }

      // 14360
      Console.WriteLine($"The sum of the signal strengths is {ss}...");
    }

    internal static void SolvePart2()
    {
      //var inp = Day10.TestInput1.ToList();
      //var inp = Day10.TestInput2.ToList();
      var inp = System.IO.File.ReadAllLines(@"Day10.txt").ToList();
      var enm = inp.GetEnumerator();
      enm.MoveNext();

      var register = 1;

      var clst = enm.Current;
      var clen = (clst.StartsWith("noop") ? 0 : 1);

      var h = 6;
      var w = 40;

      var crt = new string[h,w];
      for (int i = 0; i < h; i++)
      {
        for (int j = 0; j < w; j++)
        {
          crt[i, j] = ".";
        }
      }

      for (int i = 0; i < 240; i++)
      {
        var crtx = i % 40;
        if (crtx == 0)
          Console.WriteLine();

        var crty = 0;
        if (i >= 200)
          crty = 5;
        else if (i >= 160)
          crty = 4;
        else if (i >= 120)
          crty = 3;
        else if (i >= 080)
          crty = 2;
        else if (i >= 040)
          crty = 1;

        var spritepts = new int[3];
        spritepts[0] = Math.Max(0, register - 1);
        spritepts[1] = register;
        spritepts[2] = Math.Min(register + 1, 39);

        crt[crty, crtx] = (spritepts.Contains(crtx) ? "#" : ".");
        Console.Write((spritepts.Contains(crtx) ? "#" : "."));

        if (clen != 0)
        {
          clen--;
          continue;
        }
        if (clen == 0)
        {
          if (clst.StartsWith("addx "))
            register += int.Parse(clst.Split(' ')[1]);
        }

        if (!enm.MoveNext())
        {
          enm = inp.GetEnumerator();
          enm.MoveNext();
        }

        clst = enm.Current;
        if (clst.StartsWith("noop"))
          clen = 0;
        else
          clen = 1;
      }

      // BGKAEREZ
    }


  }
}