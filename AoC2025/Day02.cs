using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AoC2025
{
	internal static class Day02
	{
		internal static void SolvePart1()
		{
			//var inp = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,\r\n1698522-1698528,446443-446449,38593856-38593862,565653-565659,\r\n824824821-824824827,2121212118-2121212124";
			var inp = File.ReadAllText("Day02.txt").Trim();
			var sw = System.Diagnostics.Stopwatch.StartNew();
			var tot = 0L;

			foreach (var ir in inp.Split(','))
			{
				var beg = long.Parse(ir.Split('-')[0]);
				var end = long.Parse(ir.Split('-')[1]);

				for (long i = beg; i <= end; i++)
				{
					if (Day02.IsAPart1Pattern($"{i}"))
						tot += i;
				}
			}

			Console.WriteLine($"{tot} (in {sw.Elapsed})");
		}

		private static bool IsAPart1Pattern(string pp)
		{
			if (pp.Length % 2 != 0)
				return false;
			if (pp.All(pc => pc == pp[0]))
				return true;

			var fh = pp.Substring(0, pp.Length / 2);
			var sh = pp.Substring(pp.Length / 2);

			return fh == sh;
		}

		internal static void SolvePart2()
		{
			//var inp = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,\r\n1698522-1698528,446443-446449,38593856-38593862,565653-565659,\r\n824824821-824824827,2121212118-2121212124";
			var inp = File.ReadAllText("Day02.txt").Trim();
			var sw = System.Diagnostics.Stopwatch.StartNew();
			var tot = 0L;

			foreach (var ir in inp.Split(','))
			{
				var beg = long.Parse(ir.Split('-')[0]);
				var end = long.Parse(ir.Split('-')[1]);

				for (long i = beg; i <= end; i++)
				{
					if (Day02.IsAPart2Pattern($"{i}"))
						tot += i;
				}
			}

			Console.WriteLine($"{tot} (in {sw.Elapsed})");
		}

		private static bool IsAPart2Pattern(string pp)
		{
			if (pp.Length < 2)
				return false;
			if (pp.All(pc => pc == pp[0]))
				return true;

			var len = pp.Length;

			for (var i = 2; i <= len / 2; i++)
			{
				if (len % i != 0)
					continue;
				
				var chklen = len / i;
				var lst = new List<string>();

				for (var j = 0; j < i; j++)
					lst.Add(pp.Substring(j * chklen, chklen));

				if (lst.All(chunk => chunk == lst[0]))
					return true;
			}
			
			return false;
		}


	}
}
