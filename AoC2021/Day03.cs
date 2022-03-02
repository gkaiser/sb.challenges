using System;
using System.Collections.Generic;

namespace AoC2021
{
  internal static class Day03
  {
    internal static void SolvePart1()
    {
      //var lines = new[]
      //{
      //  "00100",
      //  "11110",
      //  "10110",
      //  "10111",
      //  "10101",
      //  "01111",
      //  "00111",
      //  "11100",
      //  "10000",
      //  "11001",
      //  "00010",
      //  "01010",
      //};
      var lines = System.IO.File.ReadAllLines("Day03.txt");
      var g = new int[lines[0].Length];
      var e = new int[lines[0].Length];

      for (int i = 0; i < lines[0].Length; i++)
      {
        var ct0 = 0;
        var ct1 = 0;

        foreach (var l in lines)
        {
          if (l[i] == '0')
            ct0++;
          else
            ct1++;
        }

        if (ct0 > ct1)
        {
          g[i] = 0;
          e[i] = 1;
        }
        else
        {
          g[i] = 1;
          e[i] = 0;
        }
      }

      Console.WriteLine($"G: {string.Join("", g)} ({g.BinArrToLong()})");
      Console.WriteLine($"E: {string.Join("", e)} ({e.BinArrToLong()})");
      Console.WriteLine($"Power consumption is {g.BinArrToLong() * e.BinArrToLong()}...");
    }

    internal static void SolvePart2()
    {
      //var lines = new[]
      //{
      //  "00100",
      //  "11110",
      //  "10110",
      //  "10111",
      //  "10101",
      //  "01111",
      //  "00111",
      //  "11100",
      //  "10000",
      //  "11001",
      //  "00010",
      //  "01010",
      //};
      var lines = System.IO.File.ReadAllLines("Day03.txt");
      var g = new int[lines[0].Length];
      var e = new int[lines[0].Length];

      var ogrNums = new List<string>(lines);
      var csrNums = new List<string>(lines);

      for (int i = 0; i < lines[0].Length; i++)
      {
        var oct0 = 0;
        var oct1 = 0;
        var cct0 = 0;
        var cct1 = 0;

        foreach (var l in ogrNums)
        {
          if (l[i] == '0')
            oct0++;
          else
            oct1++;
        }
        foreach (var l in csrNums)
        {
          if (l[i] == '0')
            cct0++;
          else
            cct1++;
        }

        // ogr : keep with most common
        // csr : keep with least common

        if (oct0 > oct1 && ogrNums.Count > 1)
          ogrNums.RemoveAll(ogr => ogr[i] != '0');
        else if (ogrNums.Count > 1)
          ogrNums.RemoveAll(ogr => ogr[i] != '1');

        if (cct0 > cct1 && csrNums.Count > 1)
          csrNums.RemoveAll(csr => csr[i] != '1');
        else if (csrNums.Count > 1)
          csrNums.RemoveAll(csr => csr[i] != '0');
      }

      var ogr = ogrNums[0];
      var csr = csrNums[0];
      Console.WriteLine($"OGR is {ogr} ({ogr.BinStrToLong()}), CO²GR is {csr} ({csr.BinStrToLong()}), making the life support rating {ogr.BinStrToLong() * csr.BinStrToLong()}");
    }

  }
}
