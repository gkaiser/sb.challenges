using System;

namespace SPOJ
{
	class SPOJApp
	{
		static void Main(string[] args)
		{
			//SPOJApp.P001();
			SPOJApp.P002(args);

			return;
		}

		private static bool IsPrime(long n)
		{
			if (n < 2 || (n != 2 && n % 2 == 0))
				return false;
			for (long i = 3; i < (long)Math.Sqrt(n); i += 2)
			{
				if (n % i == 0)
					return false;
			}
			return true;
		}

		private static void P001()
		{
			string input = null;
			do
			{
				if (!string.IsNullOrEmpty(input))
					Console.WriteLine(input);
				input = Console.ReadLine();
			} while (input != "42");
			return;
		}

		private static void P002(string[] args)
		{
			string st = Console.ReadLine();
			long t = long.Parse(st);
			for (long i = 0; i < t; i++)
			{
				string mnline = Console.ReadLine();
				string sm = mnline.Split(' ')[0];
				string sn = mnline.Split(' ')[1];
				long m = long.Parse(sm);
				long n = long.Parse(sn);

				for (long j = m; j <= n; j++)
					if (IsPrime(j))
						Console.WriteLine(j.ToString());

				Console.WriteLine();
			}
			return;
		}

	}
}
