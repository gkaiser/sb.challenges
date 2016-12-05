using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2016
{
  internal static class Day04
  {
    internal static void Solve_Part1()
    {
      Console.WriteLine("Solving Day 04, Part 1...");

      //var input = System.IO.File.ReadAllLines("04_Test.txt");
      var input = System.IO.File.ReadAllLines("04.txt");
      var validIds = new List<int>();

      foreach (var room in input)
      {
        var idAndSum = room.Split('-').Last();
        var roomId = idAndSum.Substring(0, idAndSum.IndexOf('[')).Replace("[", "").Replace("]", "");
        var roomCkSum = idAndSum.Substring(idAndSum.IndexOf('[')).Replace("[", "").Replace("]", "");
        var roomName = string.Join("", room.Split('-').Where(n => n.IndexOf('[') == -1 && n.IndexOf(']') == -1));
        var dt = new System.Data.DataTable();
        dt.Columns.Add("letter", typeof(string));
        dt.Columns.Add("count", typeof(int));

        for (int i = 0; i < 26; i++)
          dt.Rows.Add(((char)(i + 97)).ToString(), 0);

        foreach (var c in roomName)
        {
          var dra = dt.Select($"letter= '{((char)c).ToString()}'");

          dra[0]["count"] = (int)dra[0]["count"] + 1;
        }

        var draCt = dt.Select("", "count DESC, letter");
        var ckSum = "";
        for (int i = 0; i < 5; i++)
          ckSum += draCt[i]["letter"].ToString();

        if (ckSum == roomCkSum)
          validIds.Add(int.Parse(roomId));
      }

      // correct:
      //   278221

      Console.WriteLine($"I think the sum of valid sector id's is {validIds.Sum()}.");
    }

    internal static void Solve_Part2()
    {
      Console.WriteLine("Solving Day 04, Part 2...");

      //var input = System.IO.File.ReadAllLines("04_Test.txt");
      var input = System.IO.File.ReadAllLines("04.txt");
      var validIds = new List<int>();

      foreach (var room in input)
      {
        var idAndSum = room.Split('-').Last();
        var roomId = idAndSum.Substring(0, idAndSum.IndexOf('[')).Replace("[", "").Replace("]", "");
        var roomCkSum = idAndSum.Substring(idAndSum.IndexOf('[')).Replace("[", "").Replace("]", "");
        var roomName = string.Join("", room.Split('-').Where(n => n.IndexOf('[') == -1 && n.IndexOf(']') == -1));
        var nameAndShift = room.Substring(0, room.IndexOf('['));
        var dt = new System.Data.DataTable();
        dt.Columns.Add("letter", typeof(string));
        dt.Columns.Add("count", typeof(int));

        for (int i = 0; i < 26; i++)
          dt.Rows.Add(((char)(i + 97)).ToString(), 0);

        foreach (var c in roomName)
        {
          var dra = dt.Select($"letter= '{((char)c).ToString()}'");

          dra[0]["count"] = (int)dra[0]["count"] + 1;
        }

        var draCt = dt.Select("", "count DESC, letter");
        var ckSum = "";
        for (int i = 0; i < 5; i++)
          ckSum += draCt[i]["letter"].ToString();

        if (ckSum == roomCkSum)
        {
          var rotCt = int.Parse(nameAndShift.Split('-').Last());
          var words = nameAndShift.Substring(0, nameAndShift.LastIndexOf('-')).Split('-');
          var newWords = new string[words.Length + 1];
          for (int k = 0; k < words.Length; k++)
          {
            var word = words[k];
            for (int i = 0; i < word.Length; i++)
            {
              var c = word[i];
              var intVal = (int)c;
              for (int j = 1; j <= rotCt; j++)
              {
                if ((int)c + 1 < 123)
                  c = (char)((int)c + 1);
                else
                  c = 'a';
              }

              newWords[k] += c.ToString();
            }

            newWords[newWords.Length - 1] = $"({rotCt})";
          }

          if (newWords.Any(w => w.Contains("object")))
            Console.WriteLine(string.Join(" ", newWords));
        }
      }

      // correct:
      //   267
    }

  }
}
