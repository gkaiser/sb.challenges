using System;

namespace Euler
{
	public partial class Solutions
	{
		
	  public static int ComputeFib(int n)
	  {
	    if (n == 0)
	      return 0;
	    if (n == 1)
	      return 1;
	      
	    return ComputeFib(n - 2) + ComputeFib(n - 1);
	  }

		public static bool IsPrime(long n)
		{
			if (n < 2 || (n != 2 && n % 2 == 0))
				return false;

			for (int i = 3; i <= Math.Sqrt(n); i += 2)
			{
				if (n % i == 0)
					return false;
			}

			return true;
		}

	}
}