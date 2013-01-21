using System;
using System.Collections.Generic;

namespace Euler
{
	public partial class Solutions
	{
	  public static void P009(string[] AppArgs)
	  {
	    if (AppArgs == null || AppArgs.Length < 1)
	      AppArgs = new string[] { "1000" };
	    
	    int goalValue = Int32.Parse(AppArgs[0]);
	    
	    List<int> lstSquares = new List<int>();
	    
	    for (int i = goalValue; i > 0; i--)
	    {
	      if (!IsPerfectSquare(i))
	        continue;
	      
	      lstSquares.Add(i);
	    }
	    
	    lstSquares.Sort();
	    int[] lstPythag;
	    
	    for (int i = lstSquares.Count - 1; i >= 0; i--)
	    {
	      lstPythag = new int[3];
	      lstPythag[0] = lstSquares[i];
	       
	      for (int j = 0; j <= i; j++)
	      {
	        lstPythag[1] = lstSquares[j];
	        
	        if (SummedList(lstPythag) >= goalValue)
	        {
	          Console.WriteLine("Continuing");
	          continue;
	        }
	          
	        for (int k = 1; k < i; k++)
	        {
	          lstPythag[2] = lstSquares[k];
	            
	          if (SummedList(lstPythag) == goalValue)
	          {
	            for (int l = 0; l < lstPythag.Length; l++)
	              Console.WriteLine(l.ToString() + ", ");
	              
	            System.Environment.Exit(0); 
	          }  
	        }
	      }
	    }
	    
	    Console.WriteLine();
	  } 
	  
	  static bool IsPerfectSquare(int n)
	  {
	    return (Math.Sqrt(n) == Math.Floor(Math.Sqrt(n))); 
	  }
	  
	  static int SummedList(int[] SumList)
	  {
	    int i = 0;
	    
	    for (int j = 0; i < SumList.Length; i++)
	    {
	      i += SumList[j];
	      Console.Write(SumList[j].ToString() + " + ");
	    }
	    
	    Console.WriteLine(" = " + i.ToString());
	    
	    return i;  
	  }
	}
}
