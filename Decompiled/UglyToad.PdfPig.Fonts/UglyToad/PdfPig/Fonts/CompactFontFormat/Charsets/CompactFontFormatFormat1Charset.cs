using System;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat.Charsets;

internal sealed class CompactFontFormatFormat1Charset : CompactFontFormatCharset
{
	public CompactFontFormatFormat1Charset(ReadOnlySpan<(int glyphId, int stringId, string name)> data)
		: base(data)
	{
	}
}
