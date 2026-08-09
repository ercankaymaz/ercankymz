using System;
using DSTV.Net.Contracts;

namespace DSTV.Net.Implementations;

internal class FineSplitter : ISplitter
{
	internal static readonly ISplitter Instance = new Lazy<FineSplitter>(() => new FineSplitter()).Value;

	private static readonly char[] SplitSeparators = new char[1] { ' ' };

	public string[] Split(string input)
	{
		return input.Split(SplitSeparators, StringSplitOptions.RemoveEmptyEntries);
	}
}
