using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  class Algorithms_GradingStudents
  {
    public static void Solve()
    {
      var inp =
        "4\n" +
        "73\n" +
        "67\n" +
        "38\n" +
        "33";
      var lines = inp.Split(new string[] { "\n" }, StringSplitOptions.None);
      var n = int.Parse(lines[0]);
      var lst = new List<int>();
      for (int i = 1; i < lines.Length; i++)
        lst.Add(int.Parse(lines[i]));

      var res = Algorithms_GradingStudents.gradingStudents(lst);

      Console.WriteLine(string.Join(Environment.NewLine, res));
    }

    public static List<int> gradingStudents(List<int> grades)
    {
      var res = new List<int>();

      foreach (var g in grades)
      {
        var nm = g;
        while (nm >= 38 && nm % 5 != 0)
          nm++;

        if (nm - g >= 3)
          nm = g;

        res.Add(nm);
      }

      return res;
    }

  }
}
