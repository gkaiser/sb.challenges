using System.Linq;

namespace AoC2016
{
  public static class Day05
  {
    public static void Solve_Part1()
    {
      var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

      for (int i = 0;; i++)
      {
        var inputBytes = System.Text.Encoding.UTF8.GetBytes("abc" + i);
        var hashBytes = md5.ComputeHash(inputBytes);
        var hashStr = "";

        hashBytes.ToList().ForEach(b => hashStr += b.ToString("X2"));
        if (hashStr.StartsWith("00000"))
        {
          continue;
        }
      }
    }
  }
}