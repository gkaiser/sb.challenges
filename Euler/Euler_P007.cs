using System;
using System.Collections.Generic;

namespace Euler
{
	public partial class Solutions
	{
	  public static void P007()
	  {
	    int getPrimeAt = 10001;
	    int primesFound = 0;
	    
	    DateTime dtStart = DateTime.Now;
	    
	    for (int i = 1; ; i++)
	    {
	      if (IsPrime(i))
	      {
	        primesFound++;
	        
	        if (primesFound == getPrimeAt)
	        {
	          Console.WriteLine(DateTime.Now.Subtract(dtStart).TotalMilliseconds.ToString() + "ms");
	          Console.WriteLine(i.ToString());
	          break;
	        }
	      }
	    }
	  } 
	  
	}
}
