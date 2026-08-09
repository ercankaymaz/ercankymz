using System;

namespace UglyToad.PdfPig.Fonts.TrueType.Glyphs;

[Flags]
public enum SimpleGlyphFlags : byte
{
	OnCurve = 1,
	XSingleByte = 2,
	YSingleByte = 4,
	Repeat = 8,
	ThisXIsTheSame = 0x10,
	ThisYIsTheSame = 0x20
}
