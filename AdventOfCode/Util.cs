using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AdventOfCode
{
  internal static class Util
  {
    public static string GetMD5Hash(string input)
    {
      var sb = new StringBuilder();

      using (var md5 = System.Security.Cryptography.MD5.Create())
      {
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var hash = md5.ComputeHash(inputBytes);

        for (int i = 0; i < hash.Length; i++)
          sb.Append(hash[i].ToString("x2"));
      }
      
      return sb.ToString();
    }
  }
}
