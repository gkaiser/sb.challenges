using System;

namespace AoC2024
{
  internal static class Day04
  {
    internal static void SolvePart1()
    {
      //var inp = new string[]
      //{
      //  "MMMSXXMASM",
      //  "MSAMXMSMSA",
      //  "AMXSXMAAMM",
      //  "MSAMASMSMX",
      //  "XMASAMXAMM",
      //  "XXAMMXXAMA",
      //  "SMSMSASXSS",
      //  "SAXAMASAAA",
      //  "MAMMMXMMMM",
      //  "MXMXAXMASX",
      //};
      var inp = System.IO.File.ReadAllLines("Day04.txt");
      var ct = 0;

      for (int i = 0; i < inp.Length; i++)
      {
        for (int j = 0; j < inp[i].Length; j++)
        {
          if (inp[i][j] != 'X')
            continue;

          var canTestFwd = (j + 3) < inp.Length;
          if (canTestFwd && inp[i][j + 1] == 'M' && inp[i][j + 2] == 'A' && inp[i][j + 3] == 'S')
            ct++;

          var canTestBack = (j - 3) >= 0;
          if (canTestBack && inp[i][j - 1] == 'M' && inp[i][j - 2] == 'A' && inp[i][j - 3] == 'S')
            ct++;

          var canTestDown = (i + 3) < inp.Length;
          if (canTestDown && inp[i + 1][j] == 'M' && inp[i + 2][j] == 'A' && inp[i + 3][j] == 'S')
            ct++;

          var canTestUp = (i - 3) >= 0;
          if (canTestUp && inp[i - 1][j] == 'M' && inp[i - 2][j] == 'A' && inp[i - 3][j] == 'S')
            ct++;

          // diag fwd up
          if (canTestFwd && canTestUp && inp[i - 1][j + 1] == 'M' && inp[i - 2][j + 2] == 'A' && inp[i - 3][j + 3] == 'S')
            ct++;

          // diag back up
          if (canTestBack && canTestUp && inp[i - 1][j - 1] == 'M' && inp[i - 2][j - 2] == 'A' && inp[i - 3][j - 3] == 'S')
            ct++;

          // diag fwd down
          if (canTestFwd && canTestDown && inp[i + 1][j + 1] == 'M' && inp[i + 2][j + 2] == 'A' && inp[i + 3][j + 3] == 'S')
            ct++;

          // diag back down
          if (canTestBack && canTestDown && inp[i + 1][j - 1] == 'M' && inp[i + 2][j - 2] == 'A' && inp[i + 3][j - 3] == 'S')
            ct++;
        }
      }

      Console.WriteLine(ct);
    }

    internal static void SolvePart2()
    {
      //var inp = new string[]
      //{
      //  "MMMSXXMASM",
      //  "MSAMXMSMSA",
      //  "AMXSXMAAMM",
      //  "MSAMASMSMX",
      //  "XMASAMXAMM",
      //  "XXAMMXXAMA",
      //  "SMSMSASXSS",
      //  "SAXAMASAAA",
      //  "MAMMMXMMMM",
      //  "MXMXAXMASX",
      //};
      var inp = System.IO.File.ReadAllLines("Day04.txt");
      var ct = 0;

      for (int i = 0; i < inp.Length; i++)
      {
        for (int j = 0; j < inp[i].Length; j++)
        {
          // cant test diags if we're at the edges
          if (i == 0 || i == inp.Length - 1 || j == 0 || j == inp.Length - 1)
            continue;

          if (inp[i][j] != 'A')
            continue;

          var haveFirstCross = false;
          var haveSecndCross = false;

          if ((inp[i - 1][j - 1] == 'M' && inp[i + 1][j + 1] == 'S') ||
              (inp[i - 1][j - 1] == 'S' && inp[i + 1][j + 1] == 'M'))
            haveFirstCross = true;

          if ((inp[i - 1][j + 1] == 'M' && inp[i + 1][j - 1] == 'S') ||
              (inp[i - 1][j + 1] == 'S' && inp[i + 1][j - 1] == 'M'))
            haveSecndCross= true;

          if (haveFirstCross && haveSecndCross)
            ct++;
        }
      }

      Console.WriteLine(ct);
    }

  }
}