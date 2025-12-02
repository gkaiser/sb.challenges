namespace StackOverflowChallenges
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var sw = System.Diagnostics.Stopwatch.StartNew();

			var fn = @"C:\Users\gkaiser\Downloads\1M_random_numbers.txt";
			var lines = File.ReadAllLines(fn);

			var ints = lines.Select(x => int.Parse(x.Trim()));

			var g = ints.GroupBy(x => x);

			var og = g.OrderByDescending(x => x.Count());

			var mostComm = og.Select(g => g.Key).First();

			sw.Stop();

			Console.WriteLine($"Found most common value ({mostComm}) in {sw.Elapsed}...");
		}
	}
}
