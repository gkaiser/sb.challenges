using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCJ2013
{
	class Program
	{
		static void Main(string[] args)
		{
      DateTime dtStart = DateTime.Now;

			//RoundQualification.SolveA("round-qualification-a-sample.in");
			//RoundQualification.SolveA("round-qualification-a-small.in");
      RoundQualification.SolveA("round-qualification-a-large.in");

      Console.WriteLine("==> " + DateTime.Now.Subtract(dtStart).ToString());
			Console.Write("==> DONE, PRESS [ENTER] TO QUIT... ");
			Console.ReadLine();
		}
	}
}
