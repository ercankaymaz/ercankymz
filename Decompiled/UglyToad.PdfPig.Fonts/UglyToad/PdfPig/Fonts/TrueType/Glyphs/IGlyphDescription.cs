using System.Collections.Generic;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.TrueType.Glyphs;

internal interface IGlyphDescription : IMergeableGlyph, ITransformableGlyph
{
	bool IsSimple { get; }

	PdfRectangle Bounds { get; }

	byte[] Instructions { get; }

	ushort[] EndPointsOfContours { get; }

	GlyphPoint[] Points { get; }

	bool IsEmpty { get; }

	bool TryGetGlyphPath(out IReadOnlyList<PdfSubpath> subpaths);

	IGlyphDescription DeepClone();
}
