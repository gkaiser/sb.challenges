using System;
using System.IO;

namespace AoC2025
{
	internal static class Day01
	{
		internal static void SolvePart1()
		{
			//var inp = new[] {
			//	"L68",
			//	"L30",
			//	"R48",
			//	"L5",
			//	"R60",
			//	"L55",
			//	"L1",
			//	"L99",
			//	"R14",
			//	"L82",
			//};
			var inp = File.ReadAllLines("Day01.txt");

			var zct = 0;
			var curr = 50;

			foreach (var l in inp)
			{
				var dir = l[0];
				var mvst = l.Substring(1);
				var move = int.Parse(mvst) % 100;

				curr += (move * (dir == 'L' ? -1 : 1));
				curr = (curr < 0 ? 100 : 0) + (curr % 100);

				if (curr == 0)
					zct++;
			}

			Program.WriteOut($"The password is {zct}...");
		}

		internal static void SolvePart2()
		{
			//var inp = new[] {
			//	"L68",
			//	"L30",
			//	"R48",
			//	"L5",
			//	"R60",
			//	"L55",
			//	"L1",
			//	"L99",
			//	"R14",
			//	"L82",
			//};
			var inp = File.ReadAllLines("Day01.txt");

			var zct = 0;
			var curr = 50;

			foreach (var l in inp)
			{
				var dir = l[0];
				var mvst = l.Substring(1);
				var move = int.Parse(mvst);

				for (int i = 0; i < move; i++)
				{
					curr += 1 * (dir == 'L' ? -1 : 1);

					if (dir == 'L' && curr == -1)
						curr = 99;
					if (dir == 'R' && curr == 100)
						curr = 0;

					if (curr == 0)
						zct++;
				}
			}

			Console.WriteLine($"{zct}");
		}

	}
}
