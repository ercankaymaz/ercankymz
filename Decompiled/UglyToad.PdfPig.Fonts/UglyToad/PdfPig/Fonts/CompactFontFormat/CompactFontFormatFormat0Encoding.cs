using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat;

internal sealed class CompactFontFormatFormat0Encoding : CompactFontFormatBuiltInEncoding
{
	public CompactFontFormatFormat0Encoding(ReadOnlySpan<(int code, int sid, string str)> values, IReadOnlyList<Supplement> supplements)
		: base(supplements)
	{
		Add(0, 0, ".notdef");
		ReadOnlySpan<(int, int, string)> readOnlySpan = values;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			(int, int, string) tuple = readOnlySpan[i];
			Add(tuple.Item1, tuple.Item2, tuple.Item3);
		}
	}
}
