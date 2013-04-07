using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCJ2012
{
	internal static class RoundQualification
	{
		private static string _outputFile = 
			typeof(RoundQualification).Name + "-" + 
			Math.Floor(DateTime.Now.TimeOfDay.TotalSeconds).ToString() + ".txt";
		
		internal static void SolveA(string dataFile)
		{
			string alpha = "abcdefghijklmnopqrstuvwxyz";
			string sExG = 
				"ejp mysljylc kd kxveddknmc re jsicpdrysi rbcpc ypc rtcsra dkh wyfrepkym " + 
				"veddknkmkrkcd de kr kd eoya kw aej tysr re ujdr lkgc jv qz";
			string sExE = 
				"our language is impossible to understand there are twenty six factorial " + 
				"possibilities so it is okay if you want to just give up zq";

			string gc = string.Empty;
			string ec = string.Empty;

			for (int i = 0; i < sExG.Length; i++)
				if (gc.IndexOf(sExG[i]) == -1)
				{
					gc += sExG[i];
					ec += sExE[i];
				}

			if (gc.Length != 27 || ec.Length != 27)
			{
				string missing = "";
				foreach (char c in alpha)
					if (sExE.IndexOf(c) == -1)
						missing += c;
				throw new FormatException("gc: " + gc.Length.ToString() + " ec: " + ec.Length.ToString() + " missing: \"" + missing + "\"");
			}

			string[] dataLines = File.ReadAllLines(dataFile);
			
			int puzzleCount = int.Parse(dataLines[0].Trim());
			for (int j = 1; j <= puzzleCount; j++)
			{
				WriteOutput("Case #" + j.ToString() + ": ");

				foreach (char c in dataLines[j])
					WriteOutput(ec[gc.IndexOf(c)]);

				WriteOutput(Environment.NewLine);
			}
		}

		private static void WriteOutput(char c) { WriteOutput(c.ToString()); }

		public static void WriteOutput(string s)
		{
			System.IO.File.AppendAllText(_outputFile, s);
			Console.Write(s);
		}

	}
}
