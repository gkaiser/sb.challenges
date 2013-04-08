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

			string[] dataLines = File.ReadAllLines(dataFile);
			
			int puzzleCount = int.Parse(dataLines[0].Trim());
			for (int j = 1; j <= puzzleCount; j++)
			{
				Util.WriteOutput(_outputFile, "Case #" + j.ToString() + ": ");

				foreach (char c in dataLines[j])
					Util.WriteOutput(_outputFile, ec[gc.IndexOf(c)]);

				Util.WriteOutput(_outputFile, Environment.NewLine);
			}
		}

		internal static void SolveB(string dataFile)
		{
			// each indv given a triplet of scores
			// each score 0 - 10 (inclusive)
			// every score will be within 2 of every other score in the triplet
			int[] roundedTotals = new int[] { 0, 3, 6, 9, 12, 15, 18, 21, 24, 27, 30 };
			string[] inputLines = File.ReadAllLines(dataFile);
			int testCases = int.Parse(inputLines[0].Trim());
			for (int i = 1; i <= testCases; i++)
			{
				string[] lineItems = inputLines[i].Split(' ');
				int numGooglers = int.Parse(lineItems[0]);
				int surprises = int.Parse(lineItems[1]);
				int bestRes = int.Parse(lineItems[2]);
				int[] totalScores = new int[numGooglers];

				for (int j = 0; j < numGooglers; j++)
				{
					totalScores[j] = int.Parse(lineItems[3 + j]);
				}
			}
		}
		

	}
}
