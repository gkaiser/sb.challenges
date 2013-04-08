using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCJ2012
{
	public static class Util
	{
		public static void WriteOutput(string filename, char output) { WriteOutput(filename, output.ToString()); }

		public static void WriteOutput(string filename, string output)
		{
			System.IO.File.AppendAllText(filename, output);
			Console.Write(output);
		}

	}
}
