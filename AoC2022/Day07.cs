using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2022
{
  internal class Day07
  {
    private static string[] TestInput = new[]
    {
      "$ cd /",
      "$ ls",
      "dir a",
      "14848514 b.txt",
      "8504156 c.dat",
      "dir d",
      "$ cd a",
      "$ ls",
      "dir e",
      "29116 f",
      "2557 g",
      "62596 h.lst",
      "$ cd e",
      "$ ls",
      "584 i",
      "$ cd ..",
      "$ cd ..",
      "$ cd d",
      "$ ls",
      "4060174 j",
      "8033020 d.log",
      "5626152 d.ext",
      "7214296 k",
    };

    internal static void SolvePart1()
    {
      //var inp = Day07.TestInput;
      var inp = System.IO.File.ReadAllLines("Day07.txt");

      var fso = new FSO(null, "/", 0);
      var fsoCurr = fso;

      var dirSizes = new Dictionary<string, int>();

      for (int i = 1; i < inp.Length;)
      {
        var inst = inp[i];
        if (inst == "$ ls")
        {
          i++;

          do
          {
            inst = inp[i];
            if (inst.StartsWith("dir "))
              fsoCurr.Children.Add(new FSO(fsoCurr, inst.Split(' ')[1], 0));
            else
              fsoCurr.Children.Add(new FSO(fsoCurr, inst.Split(' ')[1], int.Parse(inst.Split(' ')[0])));

            i++;
          } while (i < inp.Length && !inp[i].StartsWith("$"));
        }
        else if (inst.StartsWith("$ cd "))
        {
          if (inst.Split(' ').Last() == "..")
            fsoCurr = (fsoCurr.Parent ?? fso);
          else
            fsoCurr = fsoCurr.Children.First(f => f.Name == inst.Split(' ').Last());

          i++;
        }
      }

      Day07.PrintDirSize(fso);

      // 1642503
      Console.WriteLine($"The answer is {Day07.Answer}...");
    }

    internal static void SolvePart2()
    {
      //var inp = Day07.TestInput;
      var inp = System.IO.File.ReadAllLines("Day07.txt");

      var fso = new FSO(null, "/", 0);
      var fsoCurr = fso;

      var dirSizes = new Dictionary<string, int>();

      for (int i = 1; i < inp.Length;)
      {
        var inst = inp[i];
        if (inst == "$ ls")
        {
          i++;

          do
          {
            inst = inp[i];
            if (inst.StartsWith("dir "))
              fsoCurr.Children.Add(new FSO(fsoCurr, inst.Split(' ')[1], 0));
            else
              fsoCurr.Children.Add(new FSO(fsoCurr, inst.Split(' ')[1], int.Parse(inst.Split(' ')[0])));

            i++;
          } while (i < inp.Length && !inp[i].StartsWith("$"));
        }
        else if (inst.StartsWith("$ cd "))
        {
          if (inst.Split(' ').Last() == "..")
            fsoCurr = (fsoCurr.Parent ?? fso);
          else
            fsoCurr = fsoCurr.Children.First(f => f.Name == inst.Split(' ').Last());

          i++;
        }
      }

      var totSpace = 70_000_000;
      var reqSpace = 30_000_000;
      Day07.FreeSpace = Day07.TotSpace - fso.FullSize;

      Day07.PrintDirSizeP2(fso);

      // 6999588
      Console.WriteLine($"Size of directory to be removed: {Day07.PossRemoves.Values.Min()}...");
    }

    private static readonly int TotSpace = 70_000_000;
    private static readonly int ReqSpace = 30_000_000;
    private static int FreeSpace = 0;

    private static int Indent = 0;
    private static int Answer = 0;

    private static Dictionary<string, int> PossRemoves = new Dictionary<string, int>();

    private static void PrintDirSize(FSO fso)
    {
      if (fso.Parent != null)
      {
        if (fso.FullSize <= 100_000)
        {
          Console.WriteLine($"{new string(' ', Day07.Indent)}{fso} => {fso.FullSize}");
          Day07.Answer += fso.FullSize;
        }
      }

      foreach (var c in fso.Children)
      {
        if (c.Size == 0)
        {
          Day07.Indent += 2;
          Day07.PrintDirSize(c);
          Day07.Indent -= 2;
        }
      }
    }

    private static void PrintDirSizeP2(FSO fso)
    {
      if (Day07.FreeSpace + fso.FullSize >= Day07.ReqSpace)
        Day07.PossRemoves.Add(fso.Name, fso.FullSize);
      
      foreach (var c in fso.Children)
      {
        if (c.Size == 0)
        {
          Day07.Indent += 2;
          Day07.PrintDirSizeP2(c);
          Day07.Indent -= 2;
        }
      }
    }

    internal class FSO
    {
      public string Name;
      public int Size;
      public FSO Parent;
      public List<FSO> Children = new List<FSO>();

      public FSO() { }

      public FSO(FSO? parent, string name, int sz)
      {
        this.Parent = parent;
        this.Name = name;
        this.Size = sz;
      }

      public int FullSize
      {
        get
        {
          var sz = this.Size;

          foreach (var c in this.Children)
            sz += c.FullSize;

          return sz;
        }
      }

      public override string ToString() => this.Name;

    }

  }
}