
using System.Net;

namespace AoCbot
{
  internal class Program
  {
    private static HttpClient HttpClient = new HttpClient();

    static void Main(string[] args)
    {
      Console.WriteLine($"Hello. Welcome to AoCbot v{typeof(Program).Assembly.GetName().Version}");
      Console.WriteLine($"  type 'help' to see help... ");
      Console.WriteLine($"  type 'exit', or 'quit' to quit AoCbot... ");

      while (true)
      {
        Console.Write("> ");
        var inp = Console.ReadLine()!;
        var cmd = inp.Split(' ')[0];

        if (cmd == "exit" || cmd == "quit")
          break;
        if (cmd== "help")
          Program.PrintHelp();
        if (cmd == "set-session-id")
          Program.SetSessionCookie(inp);
        if (cmd == "get-data")
          Program.GetData(inp);
        
      }

      if (System.Diagnostics.Debugger.IsAttached)
      {
        Console.WriteLine();
        Console.Write("Press [ENTER] to quit... ");
        Console.ReadLine();
      }
    }

    private static void PrintHelp()
    {
      Console.WriteLine("Available commands:");
      Console.WriteLine("=================================================");
      Console.WriteLine("set-session-id [AoC HTTP 'session' cookie]");
      Console.WriteLine("get-data [year] [dayr]");

    }

    private static void SetSessionCookie(string inp)
    {
      var vals = inp.Split(' ');

      var cc = new CookieContainer();
      var ch = new HttpClientHandler() { CookieContainer = cc };

      Program.HttpClient = new HttpClient(ch);

      cc.Add(new Uri("https://adventofcode.com"), new Cookie("session", vals[1]));
    }

    private static void GetData(string inp)
    {
      var vals = inp.Split(' ');
      if (vals.Length != 3)
      {
        Console.WriteLine("Invalid number of arguments passed: get-data [day] [year]");
        return;
      }

      var aocYear = int.Parse(vals[1]);
      var aocDay = int.Parse(vals[2]);

      // https://adventofcode.com/[year]/day/[day]/input
      var tres = Program.HttpClient.GetStringAsync($"https://adventofcode.com/{aocYear}/day/{aocDay}/input");

      tres.Wait();
      var str = tres.Result;

      Console.WriteLine(str);
    }

  }
}
