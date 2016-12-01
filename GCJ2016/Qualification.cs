using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCJ2016
{
  internal static class Qualification
  {
    internal static void SolveProblemA(string infile)
    {
      var lines = System.IO.File.ReadAllLines(infile);

      var caseCt = int.Parse(lines[0]);

      var sb = new StringBuilder();

      for (int i = 1; i <= caseCt; i++)
      {
        var seen = new List<bool>
        {
          false, false, false, false, false,
          false, false, false, false, false,
        };

        sb.Append("Case #" + i + ": ");

        var n = ulong.Parse(lines[i]);
        if (n == 0)
        {
          sb.AppendLine("INSOMNIA");
          continue;
        }

        for (ulong j = 1; ; j++)
        {
          var t = n * j;
          var s = t.ToString();

          foreach (var c in s)
            seen[int.Parse(c.ToString())] = true;

          if (seen.All(sn => sn == true))
          {
            sb.AppendLine(t.ToString());
            break;
          }
        }

        System.IO.File.WriteAllText(infile.Replace(".in", ".out"), sb.ToString());
      }
    }

    internal static void SolveProblemB(string infile)
    {
      var dbg = true;
      var lines = System.IO.File.ReadAllLines(infile);
      var caseCt = int.Parse(lines[0]);
      var sb = new StringBuilder();

      for (int i = 1; i < lines.Length; i++)
      {
        sb.Append($"Case #{i}: ");

        var cakes = lines[i];
        Console.WriteLine(cakes);
        
        for (int j = 0; ; j++)
        {
          Console.WriteLine($"Move {j} ==> " + cakes);

          var last = cakes.LastIndexOf('-');
          if (last == -1)
          {
            sb.AppendLine(j.ToString());
            break;
          }

          if (cakes[0] == '+')
          {
            cakes = "-" + cakes.Substring(1);
            continue;
          }

          var flip = new StringBuilder();
          for (int k = cakes.Length - 1; k >= 0; k--)
          {
            if (k <= last)
              flip.Append(cakes[k] == '+' ? "-" : "+");
            else
              flip.Append(cakes[k]);
          }

          cakes = flip.ToString();
        }

        Console.WriteLine();
      }

      System.IO.File.WriteAllText(infile.Replace(".in", ".out"), sb.ToString());
    }

  }
}
