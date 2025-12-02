using System;
using System.IO;

namespace AoC2025
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Day01.SolvePart1();
			//Day01.SolvePart2();
			Day02.SolvePart1();
			Day02.SolvePart2();

			if (System.Diagnostics.Debugger.IsAttached)
			{
				Console.Write($"DONE, press [ENTER] to quit...");
				Console.ReadLine();
			}
		}

		internal static void WriteOut(string msg)
		{
			Console.WriteLine(msg);

			File.AppendAllText(
				@"C:\Users\gkaiser\source\repos\SB.Challenges\AoC2025\bin\Debug\net10.0\AoC2025.Program.log", 
				$"{msg.TrimEnd()}{Environment.NewLine}");
		}

	}
}
