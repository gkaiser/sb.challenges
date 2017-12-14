using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2017
{
  internal static class Day07
  {
    internal static void Solve_Part1()
    {
      //var input = new[]
      //{
      //  "pbga (66)",
      //  "xhth (57)",
      //  "ebii (61)",
      //  "havc (66)",
      //  "ktlj (57)",
      //  "fwft (72) -> ktlj, cntj, xhth",
      //  "qoyq (66)",
      //  "padx (45) -> pbga, havc, qoyq",
      //  "tknk (41) -> ugml, padx, fwft",
      //  "jptl (61)",
      //  "ugml (68) -> gyxo, ebii, jptl",
      //  "gyxo (61)",
      //  "cntj (57)",
      //};
      var input = System.IO.File.ReadAllLines("Day07_Part1.txt"); // airlri

      // start by creating nodes
      var lstNodes = new List<Node>();

      foreach (var l in input)
      {
        var vals = l.Split(' ');
        var name = vals[0];
        var weight = int.Parse(vals[1].Replace("(", "").Replace(")", ""));

        lstNodes.Add(new Node(name, weight));
      }
      foreach (var l in input)
      {
        if (l.IndexOf("->") == -1)
          continue;

        var parentName = l.Split(' ').First();
        var childNames = l.Substring(l.IndexOf("->") + 3).Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var childName in childNames)
        {
          var parent = lstNodes.First(n => n.Name == parentName);
          var child = lstNodes.First(n => n.Name == childName);

          child.Parent = parent;

          parent.Children.Add(lstNodes.First(n => n.Name == childName));
        }
      }

      var baseNode = lstNodes.First(n => n.Parent == null);

      Console.WriteLine($"Is {baseNode.Name} the base node?");
    }

    internal static void Solve_Part2()
    {
      //var input = new[]
      //{
      //  "pbga (66)",
      //  "xhth (57)",
      //  "ebii (61)",
      //  "havc (66)",
      //  "ktlj (57)",
      //  "fwft (72) -> ktlj, cntj, xhth",
      //  "qoyq (66)",
      //  "padx (45) -> pbga, havc, qoyq",
      //  "tknk (41) -> ugml, padx, fwft",
      //  "jptl (61)",
      //  "ugml (68) -> gyxo, ebii, jptl",
      //  "gyxo (61)",
      //  "cntj (57)",
      //};
      var input = System.IO.File.ReadAllLines("Day07_Part1.txt"); // airlri

      // start by creating nodes
      var lstNodes = new List<Node>();

      foreach (var l in input)
      {
        var vals = l.Split(' ');
        var name = vals[0];
        var weight = int.Parse(vals[1].Replace("(", "").Replace(")", ""));

        lstNodes.Add(new Node(name, weight));
      }
      foreach (var l in input)
      {
        if (l.IndexOf("->") == -1)
          continue;

        var parentName = l.Split(' ').First();
        var childNames = l.Substring(l.IndexOf("->") + 3).Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var childName in childNames)
        {
          var parent = lstNodes.First(n => n.Name == parentName);
          var child = lstNodes.First(n => n.Name == childName);

          child.Parent = parent;

          parent.Children.Add(lstNodes.First(n => n.Name == childName));
        }
      }

      var baseNode = lstNodes.First(n => n.Parent == null);

      var imb = baseNode.FindImbalancedChild();
      foreach (var cn in imb.Parent.Children)
      {
        Console.WriteLine($"  {cn.Name} ==> {cn.Weight}");
      }
    }

    private class Node
    {
      public string Name;
      public int Weight;
      public Node Parent;
      public List<Node> Children;

      public Node(string name, int weight)
      {
        this.Name = name;
        this.Weight = weight;
        this.Children = new List<Node>();
      }

      public int GetTotalWeight()
      {
        if (this.Children.Count == 0)
          return this.Weight;

        var chWeight = 0;
        foreach (var cn in this.Children)
        {
          chWeight += cn.GetTotalWeight();
        }

        return this.Weight + chWeight;
      }

      public Node FindImbalancedChild()
      {
        var weightDict = Node.BuildWeightDictionary(this);
        foreach (var dKey in weightDict.Keys)
        {
          if (weightDict[dKey].Count > 1)
            continue;

          var imb = weightDict[dKey][0];
          if (imb.Children.Count == 0)
            return imb;

          return imb.FindImbalancedChild();
        }

        return this;
      }

      public static Dictionary<int, List<Node>> BuildWeightDictionary(Node n)
      {
        var weightDict = new Dictionary<int, List<Node>>();

        foreach (var cn in n.Children)
        {
          var weight = cn.GetTotalWeight();

          if (!weightDict.ContainsKey(weight))
            weightDict.Add(weight, new List<Node>());

          weightDict[weight].Add(cn);
        }

        return weightDict;
      }
    }

  }
}
