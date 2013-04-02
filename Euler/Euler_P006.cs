using System;

namespace Euler
{
	public partial class Solutions
	{
	  public static void P006()
	  {
	    DateTime dtStart = DateTime.Now;
	    
	    int countTo = 100;
	    int sumOfSqs = 0;
	    int sqOfSums = 0;
	    
	    for (int i = 1; i <= countTo; i++)
	    {
	       sumOfSqs += i * i;
	       sqOfSums += i;
	    } 
	    
	    int diff = (sqOfSums * sqOfSums) - sumOfSqs;
	    
	    Console.WriteLine(DateTime.Now.Subtract(dtStart).TotalMilliseconds.ToString() + "ms");
	    Console.WriteLine(diff.ToString());
	  } 
	}
}
