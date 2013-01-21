using System;
using System.Collections.Generic;

namespace Euler
{
	public partial class Solutions
	{
	  public static void P010()
	  {
	    long sumOfPrimes = 0;

	    for (int i = 1; i < 2000000; i++)
	    {
	      if (Solutions.IsPrime(i))
	        sumOfPrimes += i;
	    }
	    
	    Console.WriteLine(sumOfPrimes.ToString());
	    Console.WriteLine("Done, press enter to quit...");
	    Console.ReadLine();
	  }

	  
	}
}
