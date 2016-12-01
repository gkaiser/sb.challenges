using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCJ2016
{
  class Program
  {
    static void Main(string[] args)
    {
      //Qualification.SolveProblemA(@"b-small.in");
      //Qualification.SolveProblemA(@"b-large.in");
      Qualification.SolveProblemB("b-small.in");

      Console.WriteLine();
      Console.Write("DONE, PRESS [ENTER] TO QUIT...");
      Console.ReadLine();
    }
  }
}
