using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.PdfFonts.CidFonts;

internal interface ICidFontProgram
{
	FontDetails Details { get; }

	bool TryGetBoundingBox(int characterIdentifier, out PdfRectangle boundingBox);

	bool TryGetBoundingBox(int characterIdentifier, Func<int, int?> characterCodeToGlyphId, out PdfRectangle boundingBox);

	bool TryGetBoundingAdvancedWidth(int characterIdentifier, Func<int, int?> characterCodeToGlyphId, out double width);

	bool TryGetBoundingAdvancedWidth(int characterIdentifier, out double width);

	double? GetDescent();

	double? GetAscent();

	bool TryGetPath(int characterCode, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path);

	bool TryGetPath(int characterCode, Func<int, int?> characterCodeToGlyphId, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path);

	int GetFontMatrixMultiplier();

	bool TryGetFontMatrix(int characterCode, [NotNullWhen(true)] out TransformationMatrix? matrix);
}
