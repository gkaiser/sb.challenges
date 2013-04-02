using System;

namespace Euler
{
	public partial class Solutions
	{
	  public static void P004()
	  {
	    int l = 0;
	    int p = 0;
	    
	    for (int i = 999; i >= 100; i--)
	    {
	      for (int j = 999; j >= 100; j--)
	      {
	        p = i * j;
	        if (IsPalindrome(p.ToString()) && p > l)
	          l = p;
	      } 
	    }
	    
	    Console.WriteLine(l);
	  }
	  
	  private static bool IsPalindrome(string t)
	  {
	    if (t.Length % 2 != 0)
	      return false;
	  
	    for (int i = 0; i < t.Length / 2; i++)
	    {
	      if (i == t.Length - 1 - i)
	        break;
	      if (t[i] != t[t.Length - 1 - i])
	        return false; 
	    }  
	        
	    return true;
	  }
	}
}
