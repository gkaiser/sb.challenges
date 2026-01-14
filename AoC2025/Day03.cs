using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace AoC2025
{
	internal static class Day03
	{
		internal static void SolvePart1()
		{
			var inp = System.IO.File.ReadAllLines("Day03.txt");
			var sum = 0;

			foreach (var l in inp)
			{
				var fdi = -1;
				var sdi = -1;

				for (int i = 9; fdi == -1; i--)
				{
					fdi = l.Substring(0, l.Length - 1).IndexOf((char)(48 + i));
				}
				for (int i = 9; i >= 0 && sdi == -1; i--)
				{
					sdi = l.IndexOf((char)(48 + i), fdi + 1);
				}
				
				var num = int.Parse($"{l[fdi]}{l[sdi]}");

				sum += num;
			}

			Console.WriteLine($"{sum}");
		}

		internal static void SolvePart2()
		{
			var inp = new[]
			{
				"987654321111111",
				"811111111111119",
				"234234234234278",
				"818181911112111",
			};
			//var inp = System.IO.File.ReadAllLines("Day03.txt");
			var sum = (ulong)0;
			var len = 12;

			foreach (var l in inp)
			{
				var spos = 0;
				var strx = "";

				while (strx.Length < 12)
				{
					//     l.lenth - (len - 1)
					// 4 = 15 - 11;
					//     14 
					var maxtake = l.Length - len - 1;
					var ss = l.Substring(spos + strx.Length, l.Length - (spos + strx.Length));

					strx += ss.ToArray().Max();

					spos++;
				}

				Console.WriteLine(strx);

				sum += ulong.Parse(strx);
			}

			Console.WriteLine($"{sum}");
		}

	}
}
