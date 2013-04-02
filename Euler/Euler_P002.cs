using System;

namespace Euler
{
	public partial class Solutions
	{
	  public static void P002()
	  {
	    int l = 4000000;
	    int sumOfEvens = 0;

	    for (int i = 0; ; i++)
	    {
	      int f = ComputeFib(i);
	      
	      if (f >= l)
	        break;
	      if (f % 2 == 0)
	        sumOfEvens += f;
	    }

	    Console.WriteLine(sumOfEvens.ToString());
	  }
	  
	}
}