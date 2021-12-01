using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
  public partial class Solutions
  {
    public static void P019()
    {
      var minDate = DateTime.Parse("01/01/1901");
      var maxDate = DateTime.Parse("12/31/2000");
      var dt = minDate;
      var ct = 0;

      for (int i = 0; ; i++)
      {
        if (minDate.AddMonths(i) >= maxDate)
          break;
        
        if (minDate.AddMonths(i).DayOfWeek == DayOfWeek.Sunday)
          ct++;
      }

      Console.WriteLine($"There were {ct} Sundays on the first of the month in the twentieth century.");
    }

  }
}
