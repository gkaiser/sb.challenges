using System;
using System.Linq;

namespace AoC2016
{
  public static class Day05
  {
    public static void Solve_Part1()
    {
      var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
      var input = System.IO.File.ReadAllText("05.txt").Trim();
      //var input = "abc";
      var pwd = "";

      for (uint i = 0;; i++)
      {
        var inputBytes = System.Text.Encoding.UTF8.GetBytes(input + i);
        var hashBytes = md5.ComputeHash(inputBytes);
        var hashStr = "";

        var bail = false;
        for (int j = 0; j < hashBytes.Length; j++)
        {
          hashStr += hashBytes[j].ToString("X2");
          if (hashStr.Length >= 6 && !hashStr.StartsWith("00000"))
          {
            bail = true;
            break;
          }
        }

        if (bail)
          continue;

        if (hashStr.StartsWith("00000"))
        {
          if (pwd.Length < 8)
            pwd += hashStr[5];
          if (pwd.Length >= 8)
            break;
        }
      }

      // correct:
      //   f97c354d

      System.Console.WriteLine($"The password is \"{pwd}\"!");
    }

    public static void Solve_Part2()
    {
      var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
      var input = System.IO.File.ReadAllText("05.txt").Trim();
      //var input = "abc";
      var pwd = new string[] { null, null, null, null, null, null, null, null };

      for (uint i = 0; ; i++)
      {
        var inputBytes = System.Text.Encoding.UTF8.GetBytes(input + i);
        var hashBytes = md5.ComputeHash(inputBytes);
        
        if (hashBytes[0] != 0 || hashBytes[1] != 0 || !hashBytes[2].ToString("X2").StartsWith("0"))
          continue;

        var hashStr = "";
        hashBytes.ToList().ForEach(b => hashStr += b.ToString("x2"));

        var posn = 0;
        if (!int.TryParse(hashStr[5].ToString(), out posn))
          continue;

        if (posn < pwd.Length && pwd[posn] == null)
        {
          pwd[posn] += hashStr[6];
          if (pwd.All(p => p != null))
            break;
        }
        else
          continue;
      }

      // wrong:
      //   05ace8e3 (hurr durr, this was the test-input)
      // correct:
      //   863dde27

      var pwdStr = pwd.Aggregate((work, next) => work += next);
      System.Console.WriteLine($"The password is \"{pwdStr}\"!");
    }

  }
}