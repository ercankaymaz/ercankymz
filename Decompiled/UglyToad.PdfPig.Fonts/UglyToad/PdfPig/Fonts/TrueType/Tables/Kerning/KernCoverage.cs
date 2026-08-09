using System;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables.Kerning;

[Flags]
internal enum KernCoverage
{
	Horizontal = 1,
	Minimum = 2,
	CrossStream = 4,
	Override = 8
}
