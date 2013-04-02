using System;

namespace Euler
{
	public partial class Solutions
	{
	  public static void P005()
	  {
	    int minDiv = 1;
	    int maxDiv = 20;
	    
	    for (int i = maxDiv; ; i += maxDiv)
	    {
	      bool hadFail = false;
	      for (int j = (maxDiv - 1); j >= minDiv; j--)
	      {
	        hadFail = (i % j != 0);
	        
	        if (hadFail)
	          break;
	          
	        if (j == minDiv)
	        {
	          Console.WriteLine(i.ToString());
	          return;
	        }  
	      }
	    }
	  } 
	}
}
