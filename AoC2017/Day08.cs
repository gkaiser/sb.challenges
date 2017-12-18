using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2017
{
  internal static class Day08
  {
    internal static void Solve_Part1()
    {
      //var input = new[]
      //{
      //  "b inc 5 if a > 1",
      //  "a inc 1 if b < 5",
      //  "c dec -10 if a >= 1",
      //  "c inc -20 if c == 10",
      //};
      var input = System.IO.File.ReadAllLines("Day08_Part1.txt"); // 3880

      var registers = new List<Register>();

      foreach (var l in input)
      {
        var words = l.Split(' ');
        var regNames = new List<string> { words[0], words[4] };

        foreach (var regName in regNames)
        {
          if (registers.FirstOrDefault(r => r.Name == regName) == null)
            registers.Add(new Register(regName));
        }
      }
      foreach (var l in input)
      {
        var words = l.Split(' ');
        var regModName = words[0];
        var modType = words[1];
        var modVal = int.Parse(words[2]);
        var condRegName = words[4];
        var condOp = words[5];
        var condValue = int.Parse(words[6]);

        var modReg = registers.First(r => r.Name == regModName);
        var condReg = registers.First(r => r.Name == condRegName);
        var shouldMod = false;

        switch(condOp)
        {
          case "<":
            shouldMod = condReg.Value < condValue;
            break;
          case "<=":
            shouldMod = condReg.Value <= condValue;
            break;
          case ">":
            shouldMod = condReg.Value > condValue;
            break;
          case ">=":
            shouldMod = condReg.Value >= condValue;
            break;
          case "==":
            shouldMod = condReg.Value == condValue;
            break;
          case "!=":
            shouldMod = condReg.Value != condValue;
            break;
          default:
            throw new Exception("shit's fucked up yo!");
        }

        if (shouldMod)
          modReg.Value = modReg.Value + (modType == "inc" ? modVal : modVal * -1);
      }

      Console.WriteLine($"The largest value in any register is {registers.Max(r => r.Value)}...");
    }

    internal static void Solve_Part2()
    {
      //var input = new[]
      //{
      //  "b inc 5 if a > 1",
      //  "a inc 1 if b < 5",
      //  "c dec -10 if a >= 1",
      //  "c inc -20 if c == 10",
      //}; // 10
      var input = System.IO.File.ReadAllLines("Day08_Part1.txt"); // 5035

      var registers = new List<Register>();
      var maxDuringProc = 0;

      foreach (var l in input)
      {
        var words = l.Split(' ');
        var regNames = new List<string> { words[0], words[4] };

        foreach (var regName in regNames)
        {
          if (registers.FirstOrDefault(r => r.Name == regName) == null)
            registers.Add(new Register(regName));
        }
      }
      foreach (var l in input)
      {
        var words = l.Split(' ');
        var regModName = words[0];
        var modType = words[1];
        var modVal = int.Parse(words[2]);
        var condRegName = words[4];
        var condOp = words[5];
        var condValue = int.Parse(words[6]);

        var modReg = registers.First(r => r.Name == regModName);
        var condReg = registers.First(r => r.Name == condRegName);
        var shouldMod = false;

        switch (condOp)
        {
          case "<":
            shouldMod = condReg.Value < condValue;
            break;
          case "<=":
            shouldMod = condReg.Value <= condValue;
            break;
          case ">":
            shouldMod = condReg.Value > condValue;
            break;
          case ">=":
            shouldMod = condReg.Value >= condValue;
            break;
          case "==":
            shouldMod = condReg.Value == condValue;
            break;
          case "!=":
            shouldMod = condReg.Value != condValue;
            break;
          default:
            throw new Exception("shit's fucked up yo!");
        }

        if (shouldMod)
        {
          modReg.Value = modReg.Value + (modType == "inc" ? modVal : modVal * -1);
          var maxCurr = registers.Max(r => r.Value);

          if (maxCurr > maxDuringProc)
            maxDuringProc = maxCurr;
        }
      }

      Console.WriteLine($"The largest value during processing is {maxDuringProc}...");
    }

    private class Register
    {
      public string Name;
      public int Value = 0;

      public Register(string name)
      {
        this.Name = name;
      }
    }

  }

}
