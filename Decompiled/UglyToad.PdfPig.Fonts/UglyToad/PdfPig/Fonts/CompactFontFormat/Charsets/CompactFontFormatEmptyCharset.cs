using System;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat.Charsets;

internal class CompactFontFormatEmptyCharset : ICompactFontFormatCharset
{
	private readonly int numberOfCharstrings;

	public bool IsCidCharset { get; } = true;

	public CompactFontFormatEmptyCharset(int numberOfCharstrings)
	{
		this.numberOfCharstrings = numberOfCharstrings;
	}

	public string GetNameByGlyphId(int glyphId)
	{
		throw new NotSupportedException("Cid Charsets do not support named glyphs.");
	}

	public string GetNameByStringId(int stringId)
	{
		throw new NotSupportedException("Cid Charsets do not support named glyphs.");
	}

	public int GetStringIdByGlyphId(int glyphId)
	{
		throw new NotSupportedException("Cid Charsets do not support named glyphs.");
	}

	public int GetGlyphIdByName(string characterName)
	{
		return 0;
	}
}
