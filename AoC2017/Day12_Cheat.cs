using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2017
{
  public static class Day12_Cheat
  {
    public static void Solve_Part1()
    {
      var pipes = System.IO.File.ReadAllLines("Day12_Part1.txt");
      var programs = pipes.Select(x => new PipeProgram(x)).ToList();
      programs.ForEach(x => x.AddConnections(programs));

      Console.WriteLine($"There are {programs.First(x => x.Id == 0).GetGroup().Count} connections to 0...");
    }

    public static void Solve_Part2()
    {
      var pipes = System.IO.File.ReadAllLines("Day12_Part1.txt");
      var programs = pipes.Select(x => new PipeProgram(x)).ToList();
      programs.ForEach(x => x.AddConnections(programs));

      var groupCount = 0;

      while (programs.Any())
      {
        var group = programs.First().GetGroup();
        programs.RemoveAll(x => group.Contains(x));
        groupCount++;
      }

      Console.WriteLine($"There are {groupCount} groups...");
    }
  }

  public class PipeProgram
  {
    public int Id { get; set; }
    public string Input { get; set; }
    public List<PipeProgram> Connections { get; set; }

    public PipeProgram(string input)
    {
      var words = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
      Connections = new List<PipeProgram>();

      Id = int.Parse(words[0]);
      Input = input;
    }

    public void AddConnections(List<PipeProgram> pipeList)
    {
      var words = Input.Split(new[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries).ToList();

      for (var i = 2; i < words.Count; i++)
      {
        var connectionId = int.Parse(words[i]);
        var connectedProgram = pipeList.First(x => x.Id == connectionId);

        AddConnection(connectedProgram);
        connectedProgram.AddConnection(this);
      }
    }

    private void AddConnection(PipeProgram connectedProgram)
    {
      if (!Connections.Contains(connectedProgram))
      {
        Connections.Add(connectedProgram);
      }
    }

    private void GetGroup(List<PipeProgram> groupPrograms)
    {
      groupPrograms.Add(this);

      foreach (var c in Connections)
      {
        if (!groupPrograms.Contains(c))
        {
          c.GetGroup(groupPrograms);
        }
      }
    }

    public List<PipeProgram> GetGroup()
    {
      var groupPrograms = new List<PipeProgram>();
      GetGroup(groupPrograms);
      return groupPrograms;
    }
  }
}
