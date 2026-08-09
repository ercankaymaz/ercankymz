using System;
using DSTV.Net.Contracts;

namespace DSTV.Net.Implementations;

internal class PositionNumericSplitter : ISplitter
{
	internal static readonly ISplitter Instance = new Lazy<PositionNumericSplitter>(() => new PositionNumericSplitter()).Value;

	public string[] Split(string input)
	{
		string[] obj = new string[8]
		{
			input.Substring(0, 2),
			input.Substring(2, 1),
			input.Substring(3, 12),
			input.Substring(15, 10),
			input.Substring(25, 6),
			input.Substring(31, 4),
			input.Substring(35, 1),
			null
		};
		obj[7] = input.Substring(36, input.Length - 36);
		return obj;
	}
}
