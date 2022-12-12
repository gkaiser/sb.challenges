using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2022
{
  internal class Day11
  {
    private static string[] TestInput = new[]
    {
      "Monkey 0:",
      "  Starting items: 79, 98",
      "  Operation: new = old * 19",
      "  Test: divisible by 23",
      "    If true: throw to monkey 2",
      "    If false: throw to monkey 3",
      "",
      "Monkey 1:",
      "  Starting items: 54, 65, 75, 74",
      "  Operation: new = old + 6",
      "  Test: divisible by 19",
      "    If true: throw to monkey 2",
      "    If false: throw to monkey 0",
      "",
      "Monkey 2:",
      "  Starting items: 79, 60, 97",
      "  Operation: new = old * old",
      "  Test: divisible by 13",
      "    If true: throw to monkey 1",
      "    If false: throw to monkey 3",
      "",
      "Monkey 3:",
      "  Starting items: 74",
      "  Operation: new = old + 3",
      "  Test: divisible by 17",
      "    If true: throw to monkey 0",
      "    If false: throw to monkey 1",
    };

    internal static void SolvePart1()
    {
      //var inp = Day11.TestInput;
      var inp = System.IO.File.ReadAllLines("Day11.txt");

      var monkeys = new List<Monkey>();

      for (int i = 0; i < inp.Length;)
      {
        var l = inp[i];
        if (string.IsNullOrWhiteSpace(l))
        {
          i++;
          continue;
        }

        if (l.StartsWith("Monkey "))
          monkeys.Add(new Monkey(int.Parse(l.Split(' ')[1].TrimEnd(':'))));

        monkeys.Last().Items.AddRange(inp[i + 1].Split(':')[1].Split(',').Select(ili => int.Parse(ili.Trim())));
        monkeys.Last().OpExpression = inp[i + 2].Split('=').Last().Trim();
        monkeys.Last().TestMod = int.Parse(inp[i + 3].Split(' ').Last());
        monkeys.Last().TestTrueRecipId = int.Parse(inp[i + 4].Split(' ').Last());
        monkeys.Last().TestFalseRecipId = int.Parse(inp[i + 5].Split(' ').Last());

        i += 6;
      }

      for (int r = 0; r < 20; r++)
      {
        for (int i = 0; i < monkeys.Count; i++)
        {
          var items = monkeys[i].InspectItems();

          foreach (var item in items)
            monkeys.First(m => m.Id == item[0]).Items.Add(item[1]);
        }
      }

      monkeys = monkeys.OrderByDescending(m => m.InspectedCount).ToList();

      // 112815
      Console.WriteLine($"The monkey-business level is {monkeys[0].InspectedCount * monkeys[1].InspectedCount}...");
    }

    public class Monkey
    {
      public int Id;
      public List<int> Items = new List<int>();
      public string OpExpression;
      public int TestMod;
      public int TestTrueRecipId;
      public int TestFalseRecipId;
      public int InspectedCount;

      public Monkey(int id) { this.Id = id; }

      public bool OpIsAdd => this.OpExpression.Contains('+');

      public List<int[]> InspectItems()
      {
        var lst = new List<int[]>();

        for (int i = 0; i < this.Items.Count; i++)
        {
          var item = this.Items[i];
          var opVals = this.OpExpression.Split(' ');
          var term1 = (opVals[0] == "old" ? this.Items[i] : int.Parse(opVals[0]));
          var term2 = (opVals.Last() == "old" ? this.Items[i] : int.Parse(opVals.Last()));

          var nv = 0;
          if (this.OpIsAdd)
            nv = (int)Math.Floor((term1 + term2) / 3m);
          else
            nv = (int)Math.Floor((term1 * term2) / 3m);

          var recip = (nv % TestMod == 0 ? this.TestTrueRecipId : this.TestFalseRecipId);

          lst.Add(new[] { recip , nv });

          this.InspectedCount++;
        }

        this.Items.Clear();

        return lst;
      }


    }


    internal static void SolvePart2()
    {
      //var inp = Day11.TestInput;
      var inp = System.IO.File.ReadAllLines("Day11.txt");

      var monkeys = new List<Monkey2>();

      for (int i = 0; i < inp.Length;)
      {
        var l = inp[i];
        if (string.IsNullOrWhiteSpace(l))
        {
          i++;
          continue;
        }

        if (l.StartsWith("Monkey "))
          monkeys.Add(new Monkey2(int.Parse(l.Split(' ')[1].TrimEnd(':'))));

        monkeys.Last().Items.AddRange(inp[i + 1].Split(':')[1].Split(',').Select(ili => ulong.Parse(ili.Trim())));
        monkeys.Last().OpExpression = inp[i + 2].Split('=').Last().Trim();
        monkeys.Last().TestMod = ulong.Parse(inp[i + 3].Split(' ').Last());
        monkeys.Last().TestTrueRecipId = int.Parse(inp[i + 4].Split(' ').Last());
        monkeys.Last().TestFalseRecipId = int.Parse(inp[i + 5].Split(' ').Last());

        i += 6;
      }

      var magicMod = monkeys.Select(m => m.TestMod).Aggregate((ulong)1, (a, b) => a * b);

      var inspectRounds = new[] { 1, 20, 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };

      for (int r = 0; r < 10_000; r++)
      {
        for (int i = 0; i < monkeys.Count; i++)
        {
          var items = monkeys[i].InspectItems(magicMod);

          foreach (var item in items)
            monkeys.First(m => m.Id == (int)item[0]).Items.Add((ulong)item[1]);
        }
      }

      monkeys = monkeys.OrderByDescending(m => m.InspectedCount).ToList();

      // 25738411485
      Console.WriteLine($"The monkey-business level is {monkeys[0].InspectedCount * monkeys[1].InspectedCount}...");
    }

    public class Monkey2
    {
      public int Id;
      public List<ulong> Items = new List<ulong>();
      public string OpExpression;
      public ulong TestMod;
      public int TestTrueRecipId;
      public int TestFalseRecipId;
      public ulong InspectedCount;

      public Monkey2(int id) { this.Id = id; }

      public bool OpIsAdd => this.OpExpression.Contains('+');

      public List<object[]> InspectItems(ulong magicMod)
      {
        var lst = new List<object[]>();

        for (int i = 0; i < this.Items.Count; i++)
        {
          var item = this.Items[i];
          var opVals = this.OpExpression.Split(' ');
          var term1 = (opVals[0] == "old" ? item : ulong.Parse(opVals[0]));
          var term2 = (opVals.Last() == "old" ? item : ulong.Parse(opVals.Last()));

          var nv = (this.OpIsAdd ? term1 + term2 : term1 * term2) % magicMod;
          var recip = (nv % this.TestMod == 0 ? this.TestTrueRecipId : this.TestFalseRecipId);

          lst.Add(new object[] { recip, nv });

          this.InspectedCount++;
        }

        this.Items.Clear();

        return lst;
      }


    }

  }
}