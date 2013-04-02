using System;

namespace Euler
{
	public partial class Solutions
	{
	  public static void P003()
	  {
	    long f = 600851475143;
	    long b = 2;
	    long k = 0;

	    for (long i = 1; i < (long)Math.Sqrt(f); i++)
	    {
	      if (f % i != 0)
	        continue;
	  
	      k = f / i;
	      
	      if (k > b && IsPrime(k))
	        b = k;
	      if (i > b && IsPrime(i))
	        b = i;
	    }

	    Console.WriteLine(String.Format(
	      "Largest Prime factor of {0} is {1}.", f, b));
	  }

	}
}
