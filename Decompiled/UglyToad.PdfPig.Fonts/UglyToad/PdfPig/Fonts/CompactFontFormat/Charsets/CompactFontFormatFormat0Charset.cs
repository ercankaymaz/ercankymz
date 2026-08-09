using System;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat.Charsets;

internal sealed class CompactFontFormatFormat0Charset : CompactFontFormatCharset
{
	public CompactFontFormatFormat0Charset(ReadOnlySpan<(int glyphId, int stringId, string name)> data)
		: base(data)
	{
	}
}
