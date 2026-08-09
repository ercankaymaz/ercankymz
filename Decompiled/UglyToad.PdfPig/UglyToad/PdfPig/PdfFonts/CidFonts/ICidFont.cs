using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Geometry;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.CidFonts;

internal interface ICidFont
{
	NameToken Type { get; }

	NameToken SubType { get; }

	NameToken BaseFont { get; }

	CharacterIdentifierSystemInfo SystemInfo { get; }

	FontDetails Details { get; }

	TransformationMatrix FontMatrix { get; }

	CidFontType CidFontType { get; }

	FontDescriptor Descriptor { get; }

	double GetWidthFromDictionary(int cid);

	double GetWidthFromFont(int characterIdentifier);

	PdfRectangle GetBoundingBox(int characterIdentifier);

	PdfVector GetPositionVector(int characterIdentifier);

	PdfVector GetDisplacementVector(int characterIdentifier);

	TransformationMatrix GetFontMatrix(int characterIdentifier);

	double GetDescent();

	double GetAscent();

	bool TryGetPath(int characterCode, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path);

	bool TryGetPath(int characterCode, Func<int, int?> characterCodeToGlyphId, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path);

	bool TryGetNormalisedPath(int characterCode, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path);

	bool TryGetNormalisedPath(int characterCode, Func<int, int?> characterCodeToGlyphId, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path);
}
