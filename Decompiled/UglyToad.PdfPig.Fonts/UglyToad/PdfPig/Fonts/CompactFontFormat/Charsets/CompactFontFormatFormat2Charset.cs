using System;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat.Charsets;

internal class CompactFontFormatFormat2Charset : CompactFontFormatCharset
{
	public CompactFontFormatFormat2Charset(ReadOnlySpan<(int glyphId, int stringId, string name)> data)
		: base(data)
	{
	}
}
