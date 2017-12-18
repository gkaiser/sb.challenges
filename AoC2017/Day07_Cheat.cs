using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2017
{
  public class Day07_Cheat
  {
    public static void Solve_Part2()
    {
      var lines = System.IO.File.ReadAllLines(@"Day07_Part1.txt");

      var discs = lines.Select(x => new Disc(x)).ToList();
      discs.ForEach(x => x.AddChildDiscs(discs));

      var disc = discs.First(d => d.Parent == null);
      var targetWeight = 0;

      while (!disc.IsBalanced())
      {
        var t = disc.GetUnbalancedChild();

        disc = t.Item1;
        targetWeight = t.Item2;
      }

      var weightDiff = targetWeight - disc.GetTotalWeight();

      Console.WriteLine((disc.Weight + weightDiff).ToString());
    }

  }

  public class Disc
  {
    public int Weight;
    public string Name;
    public List<string> ChildNames;
    public List<Disc> ChildDiscs;
    public Disc Parent;

    public Disc(string input)
    {
      var words = input.Split(' ').ToList();

      this.Name = words[0];
      this.Weight = int.Parse(words[1].Replace("(", "").Replace(")", ""));
      this.ChildNames = new List<string>();

      for (var i = 3; i < words.Count; i++)
      {
        this.ChildNames.Add(words[i].TrimEnd(','));
      }
    }

    public void AddChildDiscs(IEnumerable<Disc> discs)
    {
      this.ChildDiscs = ChildNames.Select(x => discs.First(y => y.Name == x)).ToList();
      this.ChildDiscs.ForEach(x => x.Parent = this);
    }

    public int GetTotalWeight()
    {
      var childSum = this.ChildDiscs.Sum(x => x.GetTotalWeight());
      return childSum + this.Weight;
    }

    public bool IsBalanced()
    {
      var groups = this.ChildDiscs.GroupBy(x => x.GetTotalWeight());

      return groups.Count() == 1;
    }

    public Tuple<Disc, int> GetUnbalancedChild()
    {
      var groups = this.ChildDiscs.GroupBy(x => x.GetTotalWeight());
      var targetWeight = groups.First(x => x.Count() > 1).Key;
      var unbalancedChild = groups.First(x => x.Count() == 1).First();

      return new Tuple<Disc, int>(unbalancedChild, targetWeight);
    }

  }

}
