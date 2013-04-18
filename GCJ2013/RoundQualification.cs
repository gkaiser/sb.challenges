﻿using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace GCJ2013
{
	internal static class RoundQualification
	{
		private static string _currOutFile = "";

		public static void SolveA(string inputFile)
		{
			_currOutFile = inputFile.Replace(".in", ".out");
			if (File.Exists(_currOutFile))
				File.Delete(_currOutFile);

			string[] fileLines = File.ReadAllLines(inputFile);
			int caseCount = int.Parse(fileLines[0]);
			List<string> caseLines = new List<string>();

			for (int i = 1; i < fileLines.Length; i++)
			{
				if (!string.IsNullOrEmpty(fileLines[i].Trim()))
					caseLines.Add(fileLines[i]);
			}
			
			List<char[,]> lstCases = new List<char[,]>();

			for (int i = 0; i < caseLines.Count; i += 4)
			{
				char[,] testCase = new char[4, 4];

				for (int j = 0; j < 4; j++)
				{
					for (int k = 0; k < 4; k++)
					{
						testCase[j, k] = caseLines[i + j][k];
					}
				}

				lstCases.Add(testCase);
			}

			for (int i = 0; i < lstCases.Count; i++)
			{
				File.AppendAllText(_currOutFile, "Case #" + (i + 1).ToString() + ": ");
				RoundQualification.DetermineBoardStatus(lstCases[i]);
			}

			return;
		}

		private static void DetermineBoardStatus(char[,] board)
		{
			string currLine = "";

			// TEST COLUMNS
			for (int i = 0; i < board.Length / (board.Rank * board.Rank); i++)
			{
				currLine = "";
				for (int j = 0; j < board.Length / (board.Rank * board.Rank); j++)
				{
					currLine += board[i, j];
				}
				if (IsWinningLine(currLine, 'X'))
				{
					File.AppendAllText(_currOutFile, "X won\n");
					return;
				}
				else if (IsWinningLine(currLine, 'O'))
				{
					File.AppendAllText(_currOutFile, "O won\n");
					return;
				}
			}

			// TEST ROWS
			for (int i = 0; i < board.Length / (board.Rank * board.Rank); i++)
			{
				currLine = "";
				for (int j = 0; j < board.Length / (board.Rank * board.Rank); j++)
				{
					currLine += board[j, i];
				}
				if (IsWinningLine(currLine, 'X'))
				{
					File.AppendAllText(_currOutFile, "X won\n");
					return;
				}
				else if (IsWinningLine(currLine, 'O'))
				{
					File.AppendAllText(_currOutFile, "O won\n");
					return;
				}
			}

			// TEST DIAGONALS
			// 0,0 1,1 2,2 3,3
			// 3,0 2,1 1,2 0,3
			currLine = "";
			for (int i = 0; i < board.Length / (board.Rank * board.Rank); i++)
			{
				currLine += board[i, i];
			}
			if (IsWinningLine(currLine, 'X'))
			{
				File.AppendAllText(_currOutFile, "X won\n");
				return;
			}
			else if (IsWinningLine(currLine, 'O'))
			{
				File.AppendAllText(_currOutFile, "O won\n");
				return;
			}

			currLine = "";
			for (int i = 3; i >= 0; i--)
			{
				currLine += board[i, 3 - i];
			}
			if (IsWinningLine(currLine, 'X'))
			{
				File.AppendAllText(_currOutFile, "X won\n");
				return;
			}
			else if (IsWinningLine(currLine, 'O'))
			{
				File.AppendAllText(_currOutFile, "O won\n");
				return;
			}
			
			bool foundBlank = false;
			for (int i = 0; i < board.Length / (board.Rank * board.Rank); i++)
			{
				for (int j = 0; j < board.Length / (board.Rank * board.Rank); j++)
				{
					if (board[i, j] == '.')
					{
						File.AppendAllText(_currOutFile, "Game has not completed\n");
						return;
					}
				}
			}

			File.AppendAllText(_currOutFile, "Draw\n");
		}

		private static bool IsWinningLine(string line, char player)
		{
			return line.All(c => c == player || c == 'T');
		}


    public static void SolveB(string inputFile)
    {
      string[] fileLines = File.ReadAllLines(inputFile);
      int testCaseCount = int.Parse(fileLines[0]);
      int startDataLine = 1;

      for (int i = 0; i < testCaseCount; i++)
      {
        int lineCount = int.Parse(fileLines[i + startDataLine].Split(' ')[0]);
        int pattCount = int.Parse(fileLines[i + startDataLine].Split(' ')[1]);

        int[,] board = new int[lineCount, pattCount];

        for (int j = 0; j < lineCount; j++)
        {
          
        }


      }

    }

	}
}
