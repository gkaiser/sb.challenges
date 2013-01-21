using System;

namespace Euler
{
	public partial class Solutions
	{
	  public static void P001()
	  {
	    int derSum = 0;
	    for (int i = 1; i < 1000; i++)
	    {
	      if (i % 3 == 0 || i % 5 == 0)
	        derSum += i;
	    }

	    Console.WriteLine(derSum.ToString());
	  }
	}
}