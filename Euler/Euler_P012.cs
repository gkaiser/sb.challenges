using System;

namespace Euler
{
	public partial class Solutions
	{
	  public static void P012(string[] AppArgs)
	  {
	    if (AppArgs == null || AppArgs.Length < 1)
	      AppArgs = new string[] { "500" };
	    
	    int divGoal = Int32.Parse(AppArgs[0]);
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
