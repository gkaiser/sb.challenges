using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2020
{
  public static class Day04
  {
    private class Passport 
    {
      private Dictionary<string, string> DictKvp;

      public bool HasByr => this.DictKvp != null && this.DictKvp.ContainsKey("byr");
      public bool HasIyr => this.DictKvp != null && this.DictKvp.ContainsKey("iyr");
      public bool HasEyr => this.DictKvp != null && this.DictKvp.ContainsKey("eyr");
      public bool HasHgt => this.DictKvp != null && this.DictKvp.ContainsKey("hgt");
      public bool HasHcl => this.DictKvp != null && this.DictKvp.ContainsKey("hcl");
      public bool HasEcl => this.DictKvp != null && this.DictKvp.ContainsKey("ecl");
      public bool HasPid => this.DictKvp != null && this.DictKvp.ContainsKey("pid");
      public bool HasCid => this.DictKvp != null && this.DictKvp.ContainsKey("cid");

      public Passport(string ptxt) 
      { 
        this.DictKvp = new Dictionary<string, string>();
        var kvp = ptxt.Split(' ');

        foreach (var kv in kvp)
        {
          if (string.IsNullOrWhiteSpace(kv))
            continue;

          var k = kv.Split(':')[0].ToLower().Trim();
          var v = kv.Split(':')[1].ToLower().Trim();

          if (k == "byr")
            this.DictKvp.Add(k, v);
          else if (k == "iyr")
            this.DictKvp.Add(k, v);
          else if (k == "eyr")
            this.DictKvp.Add(k, v);
          else if (k == "hgt")
            this.DictKvp.Add(k, v);
          else if (k == "hcl")
            this.DictKvp.Add(k, v);
          else if (k == "ecl")
            this.DictKvp.Add(k, v);
          else if (k == "pid")
            this.DictKvp.Add(k, v);
          else if (k == "cid")
            this.DictKvp.Add(k, v);
        }
      }

      public bool IsValid => this.HasByr && this.HasIyr && this.HasEyr && this.HasHgt && this.HasHcl && this.HasEcl && this.HasPid;

      public bool IsValidP2
      {
        get
        {
          return 
            (this.HasByr &&
            this.DictKvp["byr"].Length == 4 &&
            int.TryParse(this.DictKvp["byr"], out var byr) && 
            byr >= 1920 && byr <= 2002) 
            &&
            (this.HasIyr &&
            this.DictKvp["iyr"].Length == 4 && 
            int.TryParse(this.DictKvp["iyr"], out var iry) &&
            iry >= 2010 && iry <= 2020) 
            &&
            (this.HasEyr &&
            this.DictKvp["eyr"].Length == 4 &&
            int.TryParse(this.DictKvp["eyr"], out var eyr) &&
            eyr >= 2020 && eyr <= 2030)
            &&
            (this.HasHgt && this.IsValidHgt())
            &&
            (this.HasHcl &&
            this.DictKvp["hcl"][0] == '#' && 
            this.IsValidHex(this.DictKvp["hcl"].Substring(1)))
            &&
            (this.HasEcl &&
            new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(this.DictKvp["ecl"]))
            &&
            (this.HasPid &&
            this.DictKvp["pid"].Length == 9);
        }
      }

      private bool IsValidHex(string s)
      {
        foreach(var c in s)
        {
          var isHex = ((c >= '0' && c <= '9') || 
                       (c >= 'a' && c <= 'f') || 
                       (c >= 'A' && c <= 'F'));

          if(!isHex)
            return false;
        }

        return true;
      }

      private bool IsValidHgt()
      {
        var hgt = this.DictKvp["hgt"].Trim().ToLower();
        if (hgt.EndsWith("cm") && int.TryParse(hgt.Replace("cm", ""), out var hgtcm))
          return hgtcm >= 150 && hgtcm <= 193;
        if (hgt.EndsWith("in") && int.TryParse(hgt.Replace("in", ""), out var hgtin))
          return hgtin >= 59 && hgtin <= 76;

        return false;
      }

    }

    public static void SolvePart1()
    {
      // var lines = new[] {
      //   "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd", 
      //   "byr:1937 iyr:2017 cid:147 hgt:183cm", 
      //   "", 
      //   "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884", 
      //   "hcl:#cfa07d byr:1929", 
      //   "", 
      //   "hcl:#ae17e1 iyr:2013", 
      //   "eyr:2024", 
      //   "ecl:brn pid:760753108 byr:1931", 
      //   "hgt:179cm", 
      //   "", 
      //   "hcl:#cfa07d eyr:2025 pid:166559648", 
      //   "iyr:2011 ecl:brn hgt:59in", 
      // };
      var lines = new string[0];
      if (System.IO.File.Exists("Day04.txt"))
        lines = System.IO.File.ReadAllLines(@"Day04.txt");
      else
        lines = System.IO.File.ReadAllLines(@"bin\Debug\netcoreapp3.1\Day04.txt");

      var valCt = 0;

      for (int i = 0; i < lines.Length; i++)
      {
        var ptxt = lines[i];

        while (i + 1 < lines.Length && !string.IsNullOrWhiteSpace(lines[i + 1]))
        {
          i++;
          ptxt += $" {lines[i]}";
        }

        //System.Console.WriteLine($"==> {ptxt}");
        var p = new Passport(ptxt);
        if (p.IsValid)
          valCt++;
      }

      Console.WriteLine($"Found {valCt} valid passports...");
    }

    public static void SolvePart2()
    {
      // var lines = new[] {
      //   "pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980", 
      //   "hcl:#623a2f", 
      //   "", 
      //   "eyr:2029 ecl:blu cid:129 byr:1989", 
      //   "iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm", 
      //   "", 
      //   "hcl:#888785", 
      //   "hgt:164cm byr:2001 iyr:2015 cid:88", 
      //   "pid:545766238 ecl:hzl", 
      //   "eyr:2022", 
      //   "", 
      //   "iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719", 
      // };
      var lines = new string[0];
      if (System.IO.File.Exists("Day04.txt"))
        lines = System.IO.File.ReadAllLines(@"Day04.txt");
      else
        lines = System.IO.File.ReadAllLines(@"bin\Debug\netcoreapp3.1\Day04.txt");

      var valCt = 0;

      for (int i = 0; i < lines.Length; i++)
      {
        var ptxt = lines[i];

        while (i + 1 < lines.Length && !string.IsNullOrWhiteSpace(lines[i + 1]))
        {
          i++;
          ptxt += $" {lines[i]}";
        }

        var p = new Passport(ptxt);
        if (p.IsValidP2)
          valCt++;
      }

      // 155 LOW

      Console.WriteLine($"Found {valCt} valid passports...");
    }
  }
}