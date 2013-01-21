using System;

namespace Euler
{
	public partial class Solutions
	{
	  public static void P014(string[] AppArgs)
	  {
	    DateTime dtStart = DateTime.Now;
	    
	    int s = (AppArgs.Length < 1 ? 1000000 : Int32.Parse(AppArgs[0]));
	    
	    int causesBigChain = 0;
	    int biggestChainSteps = 0;
	    for (int i = 1; i < s; i++)
	    {
	      int valueSteps = GetCollatzTermsToOne(i);
	      if (biggestChainSteps < valueSteps)
	      {
	        biggestChainSteps = valueSteps;
	        causesBigChain = i;
	      }
	    }
	    
	    DateTime dtStop = DateTime.Now;
	    
	    Console.WriteLine(
	      causesBigChain.ToString() + " causes " + 
	      biggestChainSteps.ToString() + " steps");
	    Console.WriteLine(
	      dtStop.Subtract(dtStart).TotalMilliseconds.ToString() + "ms");
	  } 
	  
	  static int GetCollatzTermsToOne(int n)
	  {
	    long nCopy = n;
	    int stepCount = 1;
	    
	    while(nCopy != 1)
	    {
	      if (nCopy % 2 == 0)
	        nCopy = nCopy / 2;
	      else
	        nCopy = (nCopy * 3) + 1;
	       
	       stepCount++;
	    }

	    return stepCount; 
	  }
	}
}
