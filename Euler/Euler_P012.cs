using System;

namespace Euler
{
	public partial class Solutions
	{
	  public static void P012()
	  {
	    int divGoal = 500;
	    int currTriNo = 0;
	    
	    for (int i = 1;  ; i++)
	    {
	      currTriNo += i;
	      
	      if (CountDivisors(currTriNo) > divGoal)
	        break;
	    } 
	    
	    Console.WriteLine(currTriNo.ToString());
	  } 
	  
	  static int CountDivisors(int n)
	  {
	    int divCount = 0;
	    
	    for (int i = 1; i <= Math.Sqrt((double)n); i++)
	    {
	      if (n % i == 0)
	        divCount++; 
	    } 
	    
	    return divCount * 2;
	  }
	}
}
