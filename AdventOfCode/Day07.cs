using System;
using System.Collections.Generic;

namespace AdventOfCode
{
  internal static class Day07
  {
    internal static List<string> Input = new List<string>(System.IO.File.ReadAllLines("07.txt"));

    internal static void Process(bool runPart1)
    {
      Console.WriteLine("Day 7 - Part " + (runPart1 ? 1 : 2));

      if (runPart1)
        Day07.Part1();
      else
        Day07.Part2();
    }

    private static void Part1()
    {
      var dWires = new Dictionary<string, ushort>();
      var reloop = new List<string>();

      for (int i = 0; i < Day07.Input.Count; i++)
      {
        var s = Day07.Input[i];

        if (!Day07.ProcessOpLine(s, dWires))
          reloop.Add(s);
      }

      while (reloop.Count > 0)
      {
        var tmpArr = new string[reloop.Count];
        reloop.CopyTo(tmpArr);
        var tmpReloop = new List<string>(tmpArr);

        reloop = new List<string>();

        for (int i = 0; i < tmpReloop.Count; i++)
        {
          var s = tmpReloop[i];

          if (!Day07.ProcessOpLine(s, dWires))
            reloop.Add(s);
        }
      }

      var wire = "a";
      Console.WriteLine("  Wire \"" + wire + "\" is recieving signal " + dWires[wire] + "...");
    }

    private static void Part2()
    {
      var dWires = new Dictionary<string, ushort>();
      var reloop = new List<string>();

      for (int i = 0; i < Day07.Input.Count; i++)
      {
        var s = Day07.Input[i];

        // the instructions for this bit are nearly 
        // impossible to friggin' figure out. what 
        // is written, does not result in the below
        // 2 lines, but that's what they want.
        if (char.IsDigit(s[0]) && s.EndsWith(" -> b"))
          s = "46065 -> b";

        if (!Day07.ProcessOpLine(s, dWires))
          reloop.Add(s);
      }

      while (reloop.Count > 0)
      {
        var tmpArr = new string[reloop.Count];
        reloop.CopyTo(tmpArr);
        var tmpReloop = new List<string>(tmpArr);

        reloop = new List<string>();

        for (int i = 0; i < tmpReloop.Count; i++)
        {
          var s = tmpReloop[i];

          if (!Day07.ProcessOpLine(s, dWires))
            reloop.Add(s);
        }
      }

      var wire = "a";
      Console.WriteLine("  Wire \"" + wire + "\" is recieving signal " + dWires[wire] + "...");

      // wrong
      //   46880 high
    }

    private static bool ProcessOpLine(string s, Dictionary<string, ushort> dWires)
    {
      var bop = s.Split(new[] { " -> " }, StringSplitOptions.None)[0];
      var tgt = s.Split(new[] { " -> " }, StringSplitOptions.None)[1];
      ushort value = 0;

      if (bop.Contains(" AND "))
      {
        var ro1 = bop.Split(new[] { " AND " }, StringSplitOptions.None)[0];
        var ro2 = bop.Split(new[] { " AND " }, StringSplitOptions.None)[1];

        if (!char.IsDigit(ro1[0]) && !dWires.ContainsKey(ro1))
          return false;
        if (!char.IsDigit(ro2[0]) && !dWires.ContainsKey(ro2))
          return false;

        var op1 = (char.IsDigit(ro1[0]) ? ushort.Parse(ro1) : dWires[ro1]);
        var op2 = (char.IsDigit(ro2[0]) ? ushort.Parse(ro2) : dWires[ro2]);

        value = (ushort)(op1 & op2);
      }
      else if (bop.Contains(" OR "))
      {
        var ro1 = bop.Split(new[] { " OR " }, StringSplitOptions.None)[0];
        var ro2 = bop.Split(new[] { " OR " }, StringSplitOptions.None)[1];

        if (!char.IsDigit(ro1[0]) && !dWires.ContainsKey(ro1))
          return false;
        if (!char.IsDigit(ro2[0]) && !dWires.ContainsKey(ro2))
          return false;

        var op1 = (char.IsDigit(ro1[0]) ? ushort.Parse(ro1) : dWires[ro1]);
        var op2 = (char.IsDigit(ro2[0]) ? ushort.Parse(ro2) : dWires[ro2]);

        value = (ushort)(op1 | op2);
      }
      else if (bop.Contains(" LSHIFT "))
      {
        var ro1 = bop.Split(new[] { " LSHIFT " }, StringSplitOptions.None)[0];
        var ro2 = bop.Split(new[] { " LSHIFT " }, StringSplitOptions.None)[1];

        if (!dWires.ContainsKey(ro1))
          return false;

        var op1 = ro1;
        var op2 = ushort.Parse(ro2);

        value = (ushort)(dWires[op1] << op2);
      }
      else if (bop.Contains(" RSHIFT "))
      {
        var ro1 = bop.Split(new[] { " RSHIFT " }, StringSplitOptions.None)[0];
        var ro2 = bop.Split(new[] { " RSHIFT " }, StringSplitOptions.None)[1];

        if (!dWires.ContainsKey(ro1))
          return false;

        var op1 = ro1;
        var op2 = ushort.Parse(ro2);

        value = (ushort)(dWires[op1] >> op2);
      }
      else if (bop.Contains("NOT "))
      {
        var ro1 = bop.Split(new[] { ' ' }, StringSplitOptions.None)[0];
        var ro2 = bop.Split(new[] { ' ' }, StringSplitOptions.None)[1];

        if (!dWires.ContainsKey(ro2))
          return false;

        value = (ushort)(~dWires[ro2]);
      }
      else
      {
        if (char.IsDigit(bop[0]))
          value = ushort.Parse(bop);
        else
        {
          if (!dWires.ContainsKey(bop))
            return false;

          value = dWires[bop];
        }
      }

      if (!dWires.ContainsKey(tgt))
        dWires.Add(tgt, 0);

      dWires[tgt] = value;

      return true;
    }

  }
}
