using System;

namespace HackerRank
{
  internal class Algorithms_DayOfTheProgrammer
  {
    internal static void Solve()
    {
      //Console.WriteLine(dayOfProgrammer(2017));
      //Console.WriteLine(dayOfProgrammer(2016));
      Console.WriteLine(dayOfProgrammer(1918));
    }

    static string dayOfProgrammer(int year)
    {
      Func<int, bool> isLeapYear = delegate(int y)
      {
        if (y < 1918)
          return y % 4 == 0;

        return y % 400 == 0 || (y % 4 == 0 && y % 100 != 0);
      };

      var dt = 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31;
      if (isLeapYear(year))
        dt++;

      dt = 256 - dt;

      if (year == 1918)
        dt += 13;

      return $"{dt}.09.{year}";
    }

  }
}