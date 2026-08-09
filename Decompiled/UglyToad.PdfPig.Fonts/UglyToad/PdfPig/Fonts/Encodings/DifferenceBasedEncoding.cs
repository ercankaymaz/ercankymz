using System;
using System.Collections.Generic;
using System.Linq;

namespace UglyToad.PdfPig.Fonts.Encodings;

public sealed class DifferenceBasedEncoding : Encoding
{
	public override string EncodingName { get; } = "Difference Encoding";

	public DifferenceBasedEncoding(Encoding baseEncoding, IReadOnlyList<(int, string)> differences)
	{
		if (baseEncoding == null)
		{
			throw new ArgumentNullException("baseEncoding");
		}
		if (differences == null)
		{
			throw new ArgumentNullException("differences");
		}
		EncodingName = "Difference " + baseEncoding.EncodingName;
		foreach (var difference in differences)
		{
			Add(difference.Item1, difference.Item2);
		}
		foreach (KeyValuePair<int, string> pair in baseEncoding.CodeToNameMap)
		{
			if (differences.All<(int, string)>(((int, string) x) => x.Item1 != pair.Key))
			{
				Add(pair.Key, pair.Value);
			}
		}
	}
}
