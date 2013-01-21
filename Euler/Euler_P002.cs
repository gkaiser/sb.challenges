using System;

namespace Euler
{
	public partial class Solutions
	{
	  public static void P002(string[] Args)
	  {
	    int l = (Args.Length > 0 ? Int32.Parse(Args[0]) : 4000000);
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