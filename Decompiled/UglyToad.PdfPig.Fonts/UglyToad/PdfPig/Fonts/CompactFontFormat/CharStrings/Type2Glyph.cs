using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat.CharStrings;

internal sealed class Type2Glyph
{
	public IReadOnlyList<PdfSubpath> Path { get; }

	public double? Width { get; }

	public Type2Glyph(IReadOnlyList<PdfSubpath> path, double? width)
	{
		Path = path ?? throw new ArgumentNullException("path");
		Width = width;
	}
}
