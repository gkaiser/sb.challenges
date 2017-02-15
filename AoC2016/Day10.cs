using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2016
{
  internal static class Day10
  {
    private class Bot
    {
      public int Id;
      public List<int> Chips;
      public List<int> History;

      public Bot(int id, int initValue)
      {
        this.Id = id;

        this.Chips = new List<int>(new[] { initValue });
        this.History = new List<int>(new[] { initValue });
      }

      public void GiveChip(int value)
      {
        if (this.Chips.Count == 2)
          throw new NotSupportedException("Already have 2 chips...");

        this.Chips.Add(value);

        if (!this.History.Contains(value))
          this.History.Add(value);
      }
    }

    internal static void Solve_Part1()
    {
      Console.WriteLine("Solving Day 10, Parts 1 & 2...");

      //var input = new[]
      //{
      //  "value 5 goes to bot 2",
      //  "bot 2 gives low to bot 1 and high to bot 0",
      //  "value 3 goes to bot 1",
      //  "bot 1 gives low to output 1 and high to bot 0",
      //  "bot 0 gives low to output 2 and high to output 0",
      //  "value 2 goes to bot 2",
      //};
      var input = System.IO.File.ReadAllLines("10.txt");

      var bots = new List<Bot>();
      var output = new Dictionary<int, int>();

      // initialize bots with values
      for (int i = 0; i < input.Length; i++)
      {
        if (!input[i].StartsWith("value "))
          continue;

        var inputLn = input[i];
        var values = inputLn.Split(' ');
        var botId = int.Parse(values[5]);
        var chipValue = int.Parse(values[1]);

        var bot = bots.FirstOrDefault(b => b.Id == botId);
        if (bot == null)
        {
          bot = new Bot(botId, chipValue);
          bots.Add(bot);
          continue;
        }

        bot.GiveChip(chipValue);
      }

      do
      {
        // process other instructions
        for (int i = 0; i < input.Length; i++)
        {
          var instruct = input[i];
          if (instruct.StartsWith("value "))
            continue;

          var values = instruct.Split(' ');

          var giverBotId = int.Parse(values[1]);
          var giverBot = bots.FirstOrDefault(b => b.Id == giverBotId);
          if (giverBot == null)
            continue;
          if (giverBot.Chips.Count < 2)
            continue;

          var loValue = giverBot.Chips.Min();
          var hiValue = giverBot.Chips.Max();

          var firstRecipType = values[5];
          var firstRecipId = int.Parse(values[6]);
          if (firstRecipType == "bot")
          {
            var recipBot = bots.FirstOrDefault(b => b.Id == firstRecipId);
            if (recipBot == null)
            {
              giverBot.Chips.Remove(loValue);

              recipBot = new AoC2016.Day10.Bot(firstRecipId, loValue);
              bots.Add(recipBot);
            }
            else
            {
              giverBot.Chips.Remove(loValue);

              recipBot.GiveChip(loValue);
            }
          }
          else
          {
            if (!output.ContainsKey(firstRecipId))
              output.Add(firstRecipId, 0);

            output[firstRecipId] = loValue;
          }

          var secndRecipType = values[10];
          var secndRecipId = int.Parse(values[11]);
          if (secndRecipType == "bot")
          {
            var recipBot = bots.FirstOrDefault(b => b.Id == secndRecipId);
            if (recipBot == null)
            {
              giverBot.Chips.Remove(hiValue);

              recipBot = new AoC2016.Day10.Bot(secndRecipId, hiValue);
              bots.Add(recipBot);
            }
            else
            {
              giverBot.Chips.Remove(hiValue);

              recipBot.GiveChip(hiValue);
            }
          }
          else
          {
            if (!output.ContainsKey(secndRecipId))
              output.Add(secndRecipId, 0);

            output[secndRecipId] = hiValue;
          }
        }
      } while (
        bots.FirstOrDefault(b => b.History.Contains(17) && b.History.Contains(61)) == null || 
        !output.Keys.Contains(0) || !output.Keys.Contains(1) || !output.Keys.Contains(2));

      var theBot = bots.FirstOrDefault(b => b.History.Contains(17) && b.History.Contains(61));
      Console.WriteLine($"Bot {theBot.Id} compares value-{theBot.History.Min()} chips with value-{theBot.History.Max()} chips.");

      var out0 = output[0];
      var out1 = output[1];
      var out2 = output[2];
      Console.WriteLine($"The result of multiplying the values of outputs 0, 1, and 2 is {out0 * out1 * out2}.");

      // Part 1 correct:
      //   181
      // Part 2 correct:
      //   12567
    }

  }
}
