using System;

namespace SPOJ
{
	class SPOJApp
	{
		static void Main(string[] args)
		{
			string st = Console.ReadLine();
			int t = int.Parse(st);
			for (int i = 0; i < t; i++)
			{
				string mnline = Console.ReadLine();
				string sm = mnline.Split(' ')[0];
				string sn = mnline.Split(' ')[1];
				int m = int.Parse(sm);
				int n = int.Parse(sn);

				for (int j = m; j <= n; j++)
					if (IsPrime(i))
						Console.WriteLine(j.ToString());

				Console.WriteLine();
			}
			return;
		}

		private static bool IsPrime(int n)
		{
			if (n < 2 || (n != 2 && n % 2 == 0))
				return false;
			for (int i = 3; i < (int)Math.Sqrt(n); i += 2)
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
			int t = int.Parse(st);
			for (int i = 0; i < t; i++)
			{
				string mnline = Console.ReadLine();
				string sm = mnline.Split(' ')[0];
				string sn = mnline.Split(' ')[1];
				int m = int.Parse(sm);
				int n = int.Parse(sn);

				for (int j = m; j <= n; j++)
					if (IsPrime(i))
						Console.WriteLine(j.ToString());

				Console.WriteLine();
			}
			return;
		}



	}
}
